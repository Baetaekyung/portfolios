// Decompiled with JetBrains decompiler
// Type: PlayerAnimations
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class PlayerAnimations : MonoBehaviour
{
  public float shieldCoolTime = 2f;
  [SerializeField]
  private float invisibleTime = 1.5f;
  [SerializeField]
  private GameObject col;
  [SerializeField]
  private bool canAttack;
  [SerializeField]
  private AudioSource attackSound;
  [SerializeField]
  private AudioSource walkAudio;
  private float currentTime;
  private float walkSoundTime = 0.4f;
  private bool canShield;
  private WaitForSeconds shieldWfs;
  private Rigidbody2D rb;
  private PlayerInput inputs;
  private Animator animator;

  private void Awake()
  {
    this.inputs = this.GetComponent<PlayerInput>();
    this.rb = this.GetComponent<Rigidbody2D>();
    this.animator = this.GetComponent<Animator>();
  }

  private void Start()
  {
    this.canAttack = true;
    this.canShield = true;
    this.shieldWfs = new WaitForSeconds(this.shieldCoolTime);
    this.col.SetActive(false);
  }

  private void OnEnable()
  {
    this.inputs.onMovementChanged += new Action<Vector2>(this.AnimationPlayer);
    this.inputs.onAttack += new Action(this.PlayerAttack);
    this.inputs.onShield += new Action(this.PlayerShield);
  }

  private void OnDestroy()
  {
    this.inputs.onMovementChanged -= new Action<Vector2>(this.AnimationPlayer);
    this.inputs.onAttack -= new Action(this.PlayerAttack);
    this.inputs.onShield -= new Action(this.PlayerShield);
  }

  private void AnimationPlayer(Vector2 direction)
  {
    this.animator.SetFloat("ismove", direction.magnitude);
    if ((double) direction.magnitude == 0.0)
      return;
    this.currentTime += Time.deltaTime;
    if ((double) this.currentTime < (double) this.walkSoundTime)
      return;
    this.walkAudio.Play();
    this.currentTime = 0.0f;
  }

  private void PlayerAttack()
  {
    if (!this.canAttack)
      return;
    this.animator.SetTrigger("attack");
    this.attackSound.Play();
    this.canAttack = false;
  }

  private void PlayerShield()
  {
    if (!this.canShield)
      return;
    this.animator.SetTrigger("shield");
    Singleton<ShieldCoolT>.Instance.currentTime = 0.0f;
    Singleton<GameManager>.Instance.isInvisible = 1;
    this.StartCoroutine(this.InvisibleRoutine());
    this.StartCoroutine("ShieldCoolTime");
    this.canShield = false;
  }

  private void Update()
  {
    if (Singleton<GameManager>.Instance.isDead)
      return;
    this.StartCoroutine(this.AttackCoolTime());
    if (Singleton<GameManager>.Instance.PlayerHp > 0)
      return;
    this.animator.SetTrigger("isDead");
    this.rb.velocity = Vector2.zero;
    Singleton<GameManager>.Instance.isDead = true;
  }

  private IEnumerator InvisibleRoutine()
  {
    yield return (object) new WaitForSeconds(this.invisibleTime);
    Singleton<GameManager>.Instance.isInvisible = 0;
  }

  public void AttackEndEvent()
  {
    this.animator.SetTrigger("attackFin");
    this.col.SetActive(false);
  }

  public void AttackStartEvent() => this.col.SetActive(true);

  public void ShieldFinEvent() => this.animator.SetTrigger("shieldFin");

  private IEnumerator ShieldCoolTime()
  {
    yield return (object) this.shieldWfs;
    this.canShield = true;
  }

  private IEnumerator AttackCoolTime()
  {
    if (!this.canAttack)
    {
      yield return (object) new WaitForSeconds(0.3f);
      this.canAttack = true;
    }
  }
}
