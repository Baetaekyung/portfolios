// Decompiled with JetBrains decompiler
// Type: UIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using TMPro;
using UnityEngine;

#nullable disable
public class UIManager : Singleton<UIManager>
{
  [SerializeField]
  private GameObject overPanel;
  [SerializeField]
  private GameObject clearPanel;
  [SerializeField]
  private TextMeshProUGUI leftEnemyCountText;
  [SerializeField]
  private TextMeshProUGUI playTimeText;

  private void Start()
  {
    this.overPanel.SetActive(false);
    this.clearPanel.SetActive(false);
  }

  public void GameOverPanelOn() => this.overPanel.SetActive(true);

  public void GameClearPanelOn()
  {
    this.clearPanel.SetActive(true);
    this.playTimeText.text = string.Format("걸린 시간 {0} : {1}", (object) Singleton<GameManager>.Instance.playTimeMin, (object) Singleton<GameManager>.Instance.playTimeSec);
  }

  private void Update()
  {
    this.leftEnemyCountText.text = "남은 적 : " + Singleton<GameManager>.Instance.leftMonster.ToString();
  }
}
