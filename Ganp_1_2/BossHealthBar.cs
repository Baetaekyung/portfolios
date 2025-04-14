// Decompiled with JetBrains decompiler
// Type: BossHealthBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class BossHealthBar : MonoBehaviour
{
  [SerializeField]
  private Slider healthSlider;

  private void Start() => this.gameObject.SetActive(false);
}
