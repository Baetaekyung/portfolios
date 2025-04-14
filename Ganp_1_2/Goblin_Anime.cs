// Decompiled with JetBrains decompiler
// Type: Goblin_Anime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Goblin_Anime : MonoBehaviour
{
  [SerializeField]
  private WaitForSeconds attackWfs;
  [SerializeField]
  private float attackCooltime;
  private Animator animator;
  private Rigidbody2D rb;
  private bool isAttacking;

  private void Awake()
  {
    this.animator = this.gameObject.GetComponent<Animator>();
    this.rb = this.gameObject.GetComponent<Rigidbody2D>();
  }

  private void Start() => this.attackWfs = new WaitForSeconds(this.attackCooltime);

  private void Update() => this.animator.SetFloat("isMove", this.rb.velocity.magnitude);

  private void OnCollisionStay2D(Collision2D collision)
  {
    if (!collision.transform.CompareTag("Player") || this.isAttacking)
      return;
    this.StartCoroutine("Attack");
  }

  private IEnumerator Attack()
  {
    this.isAttacking = true;
    this.animator.SetTrigger("attack");
    yield return (object) this.attackWfs;
    this.isAttacking = false;
  }
}
