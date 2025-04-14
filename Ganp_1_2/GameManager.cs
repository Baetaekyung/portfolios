// Decompiled with JetBrains decompiler
// Type: GameManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GameManager : Singleton<GameManager>
{
  public PlayerController currentPlayer;
  public GameObject hitBox;
  public bool isDead;
  public float timeCount;
  public float playTimeS;
  public float playTimeMin;
  public float playTimeSec;
  public int isInvisible;
  public int leftMonster;
  public bool bossAppear;
  public bool gameClear;
  private int playerHp;

  public int PlayerHp
  {
    get => this.playerHp;
    set => this.playerHp = Mathf.Clamp(value, 0, 5);
  }

  private void Awake()
  {
    this.currentPlayer = Object.FindObjectOfType<PlayerController>();
    this.isDead = false;
    this.playerHp = 5;
  }

  public void InitTimeCount() => this.timeCount = 0.0f;

  private void Update()
  {
    if (this.gameClear)
      return;
    this.playTimeS += Time.deltaTime;
    if ((double) this.playTimeS / 1.0 < 1.0)
      return;
    ++this.playTimeSec;
    this.playTimeS = 0.0f;
    if ((double) this.playTimeSec < 60.0)
      return;
    this.playTimeSec = 0.0f;
    ++this.playTimeMin;
  }
}
