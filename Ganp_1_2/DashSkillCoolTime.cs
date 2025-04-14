// Decompiled with JetBrains decompiler
// Type: DashSkillCoolTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class DashSkillCoolTime : Singleton<DashSkillCoolTime>
{
  private Image dashCoolImage;
  public float currentCool;
  [SerializeField]
  private PlayerController playerController;

  private void Awake()
  {
    this.dashCoolImage = this.GetComponent<Image>();
    this.currentCool = this.playerController.dashCooltime;
  }

  private void Update()
  {
    this.currentCool += Time.deltaTime;
    this.dashCoolImage.fillAmount = this.currentCool / this.playerController.dashCooltime;
  }
}
