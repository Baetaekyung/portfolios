// Decompiled with JetBrains decompiler
// Type: VolumeChanger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class VolumeChanger : MonoBehaviour
{
  [SerializeField]
  private AudioSource bgSources;
  [SerializeField]
  private AudioSource[] soundEffects;
  private Slider slider;

  private void Awake()
  {
    this.slider = this.GetComponent<Slider>();
    this.slider.value = 0.5f;
  }

  private void Update()
  {
    this.bgSources.volume = this.slider.value / 1f;
    for (int index = 0; index < this.soundEffects.Length; ++index)
      this.soundEffects[index].volume = this.slider.value / 1f;
  }
}
