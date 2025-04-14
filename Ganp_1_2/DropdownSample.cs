// Decompiled with JetBrains decompiler
// Type: DropdownSample
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85EC555E-EE2D-4386-9B2C-9D8C60CE294D
// Assembly location: C:\Users\tkway\Downloads\10310_Ganp\10310_Ganp\DungeonGame_Data\Managed\Assembly-CSharp.dll

using TMPro;
using UnityEngine;

#nullable disable
public class DropdownSample : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI text;
  [SerializeField]
  private TMP_Dropdown dropdownWithoutPlaceholder;
  [SerializeField]
  private TMP_Dropdown dropdownWithPlaceholder;

  public void OnButtonClick()
  {
    this.text.text = this.dropdownWithPlaceholder.value > -1 ? "Selected values:\n" + this.dropdownWithoutPlaceholder.value.ToString() + " - " + this.dropdownWithPlaceholder.value.ToString() : "Error: Please make a selection";
  }
}
