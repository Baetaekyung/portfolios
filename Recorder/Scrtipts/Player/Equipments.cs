using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipments : MonoBehaviour
{
    public Equipment[] equipments;

    private void Awake()
    {
        UnselectAll();
    }

    private void Update()
    {
        SelectEquipment();
    }

    private void SelectEquipment()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnselectAll();
            equipments[0].Selected();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnselectAll();
            equipments[1].Selected();
        }
    }

    public void UnselectAll()
    {
        foreach(var equip in equipments)
        {
            equip.Unselected();
        }
    }
}
