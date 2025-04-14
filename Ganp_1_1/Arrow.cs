// Decompiled with JetBrains decompiler
// Type: Arrow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Arrow : MonoBehaviour
{
  private GameObject player;
  private Rigidbody2D rigid;
  private int damage = 5;
  private Vector3 dir;

  private void Start()
  {
    this.player = GameObject.FindWithTag("Player");
    this.rigid = this.GetComponent<Rigidbody2D>();
    this.SetDir();
    this.rigid.AddForce((Vector2) (this.dir * 0.03f), ForceMode2D.Force);
    Object.Destroy((Object) this.gameObject, 1f);
  }

  private void Update()
  {
  }

  private void SetDir()
  {
    this.dir = (this.player.transform.position - this.transform.position).normalized;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.CompareTag("Player"))
      return;
    GameManager.instance.PlayerHit(this.damage);
    Object.Destroy((Object) this.gameObject);
  }
}
