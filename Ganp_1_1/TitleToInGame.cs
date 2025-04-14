// Decompiled with JetBrains decompiler
// Type: TitleToInGame
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 15915B99-93CB-482D-B807-71CB8D2D32B6
// Assembly location: C:\Users\tkway\Downloads\10310\ganp_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class TitleToInGame : MonoBehaviour
{
  private void Update()
  {
  }

  public void onClickStartBotton()
  {
    SceneManager.LoadScene("InGame");
    GameManager.instance.currentPlayerHp = 100;
  }
}
