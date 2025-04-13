using TMPro;
using UnityEngine;

public class SelectGhostObject : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public Color selectedColor;
    public Color defaultColor = Color.white;
    public bool isSelected = false;
    public bool isFinded = false;

    public void SetColor()
    {
        tmp.color = selectedColor;
    }
}