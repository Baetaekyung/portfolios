// Decompiled with JetBrains decompiler
// Type: BossPatterns
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class BossPatterns : Enemy
{
  public int currentHp;
  [SerializeField]
  private float patternDelay;
  [SerializeField]
  private float crashdelay;
  [SerializeField]
  private float shotDelay;
  [SerializeField]
  private float moveSpeed;
  [SerializeField]
  private Transform[] shotPos;
  [SerializeField]
  private GameObject bossBullet;
  [SerializeField]
  private GameObject bossStone;
  [SerializeField]
  private GameObject DeathParticle;
  [SerializeField]
  private BossHealthBar bossHealthBar;
  private Animator animator;
  private BossPatterns.Patterns patterns;
  private WaitForSeconds crashDelay;
  private WaitForSeconds stoneShotDelay;
  private Transform playerPos;
  private GameObject player;
  private Rigidbody2D rigid;
  private SpriteRenderer spriteRenderer;
  private float currentPatternDelay;
  private bool delayCheck;

  private void Awake()
  {
    this.animator = this.GetComponent<Animator>();
    this.rigid = this.GetComponent<Rigidbody2D>();
    this.spriteRenderer = this.GetComponent<SpriteRenderer>();
  }

  private void OnEnable()
  {
    this.playerPos = Object.FindObjectOfType<Player>().transform;
    this.player = Object.FindObjectOfType<Player>().gameObject;
  }

  private void Start()
  {
    this.patterns = BossPatterns.Patterns.NONE;
    this.crashDelay = new WaitForSeconds(this.crashdelay);
    this.stoneShotDelay = new WaitForSeconds(this.shotDelay);
    this.delayCheck = true;
  }

  private void Update()
  {
    this.spriteRenderer.color = new Color(1f, (float) this.hp / 100f, (float) this.hp / 100f, 1f);
    if ((double) this.playerPos.position.x < (double) this.gameObject.transform.position.x)
      this.spriteRenderer.flipX = true;
    else if ((double) this.playerPos.position.x >= (double) this.gameObject.transform.position.x)
      this.spriteRenderer.flipX = false;
    this.currentHp = this.hp;
    this.None();
    if (this.isDead)
      return;
    this.Think();
  }

  private void None()
  {
    if (this.patterns != BossPatterns.Patterns.NONE)
      return;
    this.FollowPlayer();
  }

  private void FollowPlayer()
  {
    this.rigid.velocity = (Vector2) ((this.player.transform.position - this.gameObject.transform.position).normalized * this.moveSpeed);
    this.animator.SetFloat("velocity", this.rigid.velocity.magnitude);
  }

  private void StartPattern() => this.rigid.velocity = (Vector2) Vector3.zero;

  public void CrashPatternEvent()
  {
    for (int index = 0; index < this.shotPos.Length; ++index)
    {
      Singleton<PoolManager>.Instance.GetSpawn("PoisionAtk").transform.position = this.shotPos[index].position;
      this.delayCheck = false;
    }
  }

  public void DeathCheck()
  {
    if (this.hp > 0)
      return;
    this.BossDeath();
  }

  private void BossDeath()
  {
    this.animator.SetTrigger("dead");
    this.isDead = true;
  }

  public void DeathEvent()
  {
    Singleton<GameManager>.Instance.gameClear = true;
    Singleton<UIManager>.Instance.GameClearPanelOn();
    Singleton<PoolManager>.Instance.DestroyObj(this.gameObject);
  }

  private void Think()
  {
    this.currentPatternDelay += Time.deltaTime;
    if ((double) this.currentPatternDelay < (double) this.patternDelay)
      return;
    switch (Random.Range(1, 4))
    {
      case 1:
        this.patterns = BossPatterns.Patterns.CRASH;
        this.Do(this.patterns);
        break;
      case 2:
        this.patterns = BossPatterns.Patterns.HEAL;
        this.Do(this.patterns);
        break;
      case 3:
        this.patterns = BossPatterns.Patterns.SHOTSTONE;
        this.Do(this.patterns);
        break;
    }
  }

  private void Do(BossPatterns.Patterns curPattern)
  {
    this.StartPattern();
    switch (curPattern)
    {
      case BossPatterns.Patterns.CRASH:
        this.StartCoroutine("CrashRand");
        break;
      case BossPatterns.Patterns.HEAL:
        this.DoHeal();
        break;
      case BossPatterns.Patterns.SHOTSTONE:
        this.StartCoroutine("ShotStone");
        break;
    }
    this.currentPatternDelay = 0.0f;
  }

  public void InitPattern()
  {
    this.patterns = BossPatterns.Patterns.NONE;
    this.animator.SetTrigger("endpattern");
  }

  private void DoHeal()
  {
    this.hp += 15;
    this.hp = Mathf.Clamp(this.hp, 0, 100);
    this.animator.SetTrigger("SelfHeal");
    Debug.Log((object) this.hp);
  }

  private IEnumerator ShotStone()
  {
    for (int index = 0; index < 10; ++index)
    {
      Singleton<PoolManager>.Instance.GetSpawn("BossStone").transform.position = this.playerPos.position;
      yield return (object) this.stoneShotDelay;
    }
  }

  private IEnumerator CrashRand()
  {
    for (int index = 0; index < 6; ++index)
    {
      if (this.delayCheck)
      {
        this.animator.SetTrigger("RandCrush");
        this.delayCheck = false;
      }
      yield return (object) this.crashDelay;
      this.delayCheck = true;
    }
  }

  public enum Patterns
  {
    NONE,
    CRASH,
    HEAL,
    SHOTSTONE,
  }
}
