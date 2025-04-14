// Decompiled with JetBrains decompiler
// Type: PlayerAttack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PlayerAttack : MonoBehaviour
{
  [SerializeField]
  private GameObject hitParticle;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if ((bool) (Object) collision.GetComponent<Enemy>())
    {
      --collision.gameObject.GetComponent<Enemy>().hp;
      Object.Instantiate<GameObject>(this.hitParticle, collision.transform.position, Quaternion.identity);
    }
    if (!(bool) (Object) collision.GetComponent<BossPatterns>())
      return;
    collision.GetComponent<BossPatterns>().DeathCheck();
  }
}
