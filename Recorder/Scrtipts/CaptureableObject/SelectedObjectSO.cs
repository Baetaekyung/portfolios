using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SelectedObjectList")]
public class SelectedObjectSO : ScriptableObject
{
    public SelectGhostObject[] selectedObjects;
}
