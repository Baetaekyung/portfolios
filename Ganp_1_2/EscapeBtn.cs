// Decompiled with JetBrains decompiler
// Type: EscapeBtn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#nullable disable
public class EscapeBtn : BottonClick, IBottonClick
{
  [SerializeField]
  private float panelXScale;

  public void BottonClickEvent()
  {
    if (this.isclicked)
      return;
    this.panel.transform.DOScaleX(0.0f, this.panelOpenTime);
    this.isclicked = true;
  }

  private void Start()
  {
    this.panel.transform.DOScaleX(0.0f, this.panelOpenTime);
    this.isclicked = false;
  }

  private void Update()
  {
    this.KeyBoardBtnClick();
    if (Input.GetKeyDown(KeyCode.Escape))
      this.isclicked = !this.isclicked;
    if (!this.isclicked)
      Time.timeScale = 0.0f;
    else
      Time.timeScale = 1f;
  }

  public void KeyBoardBtnClick()
  {
    if (Input.GetKeyDown(KeyCode.Escape) && this.isclicked)
      this.panel.transform.DOScaleX(this.panelXScale, this.panelOpenTime).SetUpdate<TweenerCore<Vector3, Vector3, VectorOptions>>(true);
    if (!Input.GetKeyDown(KeyCode.Escape) || this.isclicked)
      return;
    this.panel.transform.DOScaleX(0.0f, this.panelOpenTime).SetUpdate<TweenerCore<Vector3, Vector3, VectorOptions>>(true);
  }
}
