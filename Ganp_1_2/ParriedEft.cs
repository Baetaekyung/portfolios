// Decompiled with JetBrains decompiler
// Type: ParriedEft
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ParriedEft : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!(bool) (Object) collision.GetComponent<Enemy>())
      return;
    if (collision.CompareTag("Enemy"))
    {
      Vector3 normalized = (collision.transform.position - this.transform.position).normalized;
      Rigidbody2D component1 = collision.GetComponent<Rigidbody2D>();
      Enemy component2 = collision.GetComponent<Enemy>();
      component1.velocity = (Vector2) Vector3.zero;
      component1.AddForce((Vector2) (normalized * 30f), ForceMode2D.Impulse);
      --component2.hp;
    }
    else
    {
      if (!collision.CompareTag("Boss"))
        return;
      --collision.GetComponent<BossPatterns>().hp;
    }
  }

  public void EndEvent() => Singleton<PoolManager>.Instance.DestroyObj(this.gameObject);
}
