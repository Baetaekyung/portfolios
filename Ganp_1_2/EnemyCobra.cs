// Decompiled with JetBrains decompiler
// Type: EnemyCobra
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class EnemyCobra : Enemy
{
  [SerializeField]
  private float attackSpeed;
  [SerializeField]
  private GameObject poision;
  private Animator animator;
  private Rigidbody2D rigid;
  private WaitForSeconds dirWfs;
  private bool canAttack;
  private int r;
  private int u;

  private void Awake()
  {
    this.animator = this.gameObject.GetComponent<Animator>();
    this.rigid = this.gameObject.GetComponent<Rigidbody2D>();
    this.dirWfs = new WaitForSeconds(0.5f);
    this.canAttack = true;
  }

  private void Update()
  {
    if (!this.playerFind)
    {
      this.Ai(this.speed, this.rigid, this.r, this.u);
      this.StartCoroutine("SetDir");
    }
    this.Death();
  }

  private void Death()
  {
    if (this.hp > 0)
      return;
    this.DropHeart(this.gameObject.transform);
    this.GenerateBoss(this.gameObject.transform);
    --Singleton<GameManager>.Instance.leftMonster;
    this.isDead = true;
    Singleton<PoolManager>.Instance.DestroyObj(this.gameObject);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (!collision.CompareTag("Player"))
      return;
    if (this.canAttack)
      this.StartCoroutine("PoisionAttack");
    if (this.canAttack)
      return;
    this.FindPlayer(collision.transform, this.rigid);
    if ((double) collision.transform.position.x > (double) this.transform.position.x)
      this.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
    else
      this.transform.localScale = new Vector3(-0.6f, 0.6f, 1f);
  }

  private IEnumerator SetDir()
  {
    this.r = Random.Range(0, 2);
    this.u = Random.Range(0, 2);
    yield return (object) this.dirWfs;
  }

  private IEnumerator PoisionAttack()
  {
    EnemyCobra enemyCobra = this;
    enemyCobra.animator.SetTrigger("Cobra_Attack");
    enemyCobra.canAttack = false;
    yield return (object) new WaitForSeconds(0.7f);
    Singleton<PoolManager>.Instance.GetSpawn("PoisionAtk").transform.position = enemyCobra.gameObject.transform.position;
    yield return (object) new WaitForSeconds(enemyCobra.attackSpeed);
    enemyCobra.canAttack = true;
  }
}
