﻿// Decompiled with JetBrains decompiler
// Type: PlayerState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PlayerState : MonoBehaviour
{
  public static PlayerState.FightStates fightState = PlayerState.FightStates.Roaming;

  public enum FightStates
  {
    Fighting,
    Roaming,
  }
}
