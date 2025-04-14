// Decompiled with JetBrains decompiler
// Type: GameManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public TextMeshProUGUI scoreTxt;
  public Image hpBar;
  private int maxPlayerHp = 100;
  public int currentPlayerHp = 100;
  public int playerDmg = 1;
  public int _score;

  public int PlayerDmg
  {
    get => this.playerDmg;
    set
    {
      if (this.playerDmg >= 3)
        this.PlayerDmg = 3;
      else
        this.PlayerDmg = value;
    }
  }

  private void Awake()
  {
    if ((Object) GameManager.instance == (Object) null)
      GameManager.instance = this;
    else
      Object.Destroy((Object) this.gameObject);
  }

  private void Start()
  {
  }

  private void Update()
  {
    this.scoreTxt.text = "SCORE : " + this._score.ToString();
    this.HpBarManage();
  }

  public void HpBarManage()
  {
    this.hpBar.fillAmount = (float) this.currentPlayerHp / (float) this.maxPlayerHp;
  }

  public void PlayerHit(int damage) => this.currentPlayerHp -= damage;

  public void PlayerHPUp(int postion) => this.currentPlayerHp += postion;

  public void ScoreUp(int score) => this._score += score;

  public void HpZero() => this.currentPlayerHp = 0;
}
