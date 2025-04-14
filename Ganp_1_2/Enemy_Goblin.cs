// Decompiled with JetBrains decompiler
// Type: Enemy_Goblin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Enemy_Goblin : Enemy
{
  [SerializeField]
  private Vector3 monsterScale;
  [SerializeField]
  private Vector3 flipScale;
  private Rigidbody2D rb;
  private WaitForSeconds dirWfs;
  private int r;
  private int u;

  private void Awake()
  {
    this.rb = this.gameObject.GetComponent<Rigidbody2D>();
    this.dirWfs = new WaitForSeconds(0.8f);
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

  public void AttackEvent()
  {
    RaycastHit2D raycastHit2D = Physics2D.Raycast((Vector2) this.transform.position, (Vector2) new Vector3(this.transform.localScale.x, 0.0f, 0.0f), 1f, LayerMask.GetMask("HitBox"));
    Debug.DrawRay(this.transform.position, new Vector3(this.transform.localScale.x, 0.0f, 0.0f), Color.red);
    if (!(bool) raycastHit2D)
      return;
    Singleton<PlayerHealth>.Instance.PlayerHit();
  }

  private void Update()
  {
    if (!this.playerFind)
    {
      this.StartCoroutine(this.FindDir());
      this.Ai(this.speed * 0.9f, this.rb, this.r, this.u);
    }
    this.Death();
  }

  private IEnumerator FindDir()
  {
    this.r = Random.Range(0, 2);
    this.u = Random.Range(0, 2);
    yield return (object) this.dirWfs;
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (!collision.CompareTag("Player"))
      return;
    this.FindPlayer(collision.transform, this.rb);
    if ((double) collision.transform.position.x > (double) this.transform.position.x)
      this.transform.localScale = this.monsterScale;
    else
      this.transform.localScale = this.flipScale;
  }

  private void OnTriggerExit2D(Collider2D collision) => this.playerFind = false;
}
