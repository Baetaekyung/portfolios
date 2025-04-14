// Decompiled with JetBrains decompiler
// Type: HPItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HPItem : MonoBehaviour
{
  private int HpUpPer = 20;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.CompareTag("Player"))
      return;
    GameManager.instance.PlayerHPUp(this.HpUpPer);
    Object.Destroy((Object) this.gameObject);
  }
}
