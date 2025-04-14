// Decompiled with JetBrains decompiler
// Type: Singleton`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
  private static T instance;
  private static bool destroyed;

  public static T Instance
  {
    get
    {
      if (Singleton<T>.destroyed)
      {
        Singleton<T>.instance = default (T);
        return default (T);
      }
      if ((Object) Singleton<T>.instance == (Object) null)
      {
        Singleton<T>.instance = (T) Object.FindObjectOfType(typeof (T));
        if ((Object) Singleton<T>.instance == (Object) null)
          Singleton<T>.instance = new GameObject(typeof (T).ToString()).AddComponent<T>();
      }
      return Singleton<T>.instance;
    }
  }

  private void OnApplicationQuit() => Singleton<T>.destroyed = true;
}
