// Decompiled with JetBrains decompiler
// Type: PlayBtn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using DG.Tweening;
using UnityEngine;

#nullable disable
public class PlayBtn : MonoBehaviour, IBottonClick
{
  [SerializeField]
  private EscapeBtn escapeBtn;

  public void BottonClickEvent()
  {
    if (this.escapeBtn.isclicked)
      return;
    this.escapeBtn.panel.transform.DOScaleX(0.0f, this.escapeBtn.panelOpenTime);
    this.escapeBtn.isclicked = true;
    Singleton<GameManager>.Instance.InitTimeCount();
  }
}
