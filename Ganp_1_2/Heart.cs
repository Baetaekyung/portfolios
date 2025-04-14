// Decompiled with JetBrains decompiler
// Type: Heart
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Heart : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.CompareTag("Player"))
      return;
    ++Singleton<GameManager>.Instance.PlayerHp;
    Singleton<PlayerHealth>.Instance.CheckHp();
    Object.Destroy((Object) this.gameObject);
  }
}
