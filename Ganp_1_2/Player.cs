// Decompiled with JetBrains decompiler
// Type: Player
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Player : MonoBehaviour
{
  [SerializeField]
  private float invisibleT;
  private WaitForSeconds invisibleTime;

  private void Awake() => this.invisibleTime = new WaitForSeconds(this.invisibleT);

  private void Start() => this.invisibleTime = new WaitForSeconds(this.invisibleT);

  public IEnumerator InvisibleRoutine()
  {
    Singleton<GameManager>.Instance.isInvisible = 1;
    yield return (object) this.invisibleTime;
    Singleton<GameManager>.Instance.isInvisible = 0;
  }
}
