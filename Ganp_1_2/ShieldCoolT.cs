// Decompiled with JetBrains decompiler
// Type: ShieldCoolT
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ShieldCoolT : Singleton<ShieldCoolT>
{
  [SerializeField]
  private PlayerAnimations playerAnim;
  public float currentTime;
  private Image coolTimeImage;

  private void Awake()
  {
    this.coolTimeImage = this.GetComponent<Image>();
    this.currentTime = this.playerAnim.shieldCoolTime;
  }

  private void Update() => this.CoolDown();

  public void CoolDown()
  {
    this.currentTime += Time.deltaTime;
    this.coolTimeImage.fillAmount = this.currentTime / this.playerAnim.shieldCoolTime;
  }
}
