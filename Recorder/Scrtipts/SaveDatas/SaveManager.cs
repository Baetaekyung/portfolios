using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    protected override void Awake()
    {
        base.Awake();
    }
    
    public void SetClearData(string whatGhost)
    {
        if(!PlayerPrefs.HasKey(whatGhost))
        {
            PlayerPrefs.SetString(whatGhost, $"{whatGhost}");
        }
        else
        {
            Debug.Log("�̹� �߰ߵ� �ͽ��̴�.");
            return;
        }
    }

    public void SetTimeData(string whatGhost, int whatTime)
    {
        if (GetSaveDataTime(whatGhost) < whatTime)
        {
            Debug.Log("Ŭ���� �ð��� �� ��Ϻ��� �� ���!");
            return;
        }
        else
        {
            PlayerPrefs.SetInt(whatGhost, whatTime);
        }
    }

    public int GetSaveDataTime(string whatGhost)
    {
        if (PlayerPrefs.HasKey(whatGhost))
        {
            return PlayerPrefs.GetInt(whatGhost);
        }
        else
        {
            Debug.Log("���� Ŭ���� ���� ����");
            return 0;
        }
    }

    public string GetSaveDataClear(string whatGhost)
    {
        if(PlayerPrefs.HasKey(whatGhost))
        {
            return PlayerPrefs.GetString(whatGhost);
        }
        else
        {
            Debug.Log("���� ��ã��");
            return "NOTFOUND";
        }
    }
}
