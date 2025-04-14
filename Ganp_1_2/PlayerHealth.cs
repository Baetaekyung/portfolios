// Decompiled with JetBrains decompiler
// Type: PlayerHealth
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class PlayerHealth : Singleton<PlayerHealth>
{
  private Image healthBarImage;
  [SerializeField]
  private Sprite[] sourceImage;
  [SerializeField]
  private Sprite emptyHpBar;
  [SerializeField]
  private GameObject enemyAttackEff;
  private GameManager gm;
  private Player p;

  private void Awake()
  {
    this.gm = Singleton<GameManager>.Instance;
    this.healthBarImage = this.GetComponent<Image>();
    this.p = GameObject.Find("Player").GetComponent<Player>();
  }

  public void PlayerHit()
  {
    if (Singleton<GameManager>.Instance.isInvisible == 0)
    {
      --this.gm.PlayerHp;
      Object.Instantiate<GameObject>(this.enemyAttackEff, this.p.transform.position, Quaternion.identity);
      this.StartCoroutine(this.p.InvisibleRoutine());
      this.CheckHp();
    }
    else
    {
      if (Singleton<GameManager>.Instance.isInvisible != 1)
        return;
      Singleton<PoolManager>.Instance.GetSpawn("Parried").transform.position = this.p.transform.position;
    }
  }

  public void CheckHp()
  {
    this.healthBarImage.sprite = this.sourceImage[this.gm.PlayerHp];
    Debug.Log((object) this.gm.PlayerHp);
    this.GameOver();
  }

  private void GameOver()
  {
    if (this.gm.PlayerHp != 0)
      return;
    Singleton<UIManager>.Instance.GameOverPanelOn();
  }
}
