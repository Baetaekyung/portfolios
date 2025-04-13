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
            Debug.Log("이미 발견된 귀신이다.");
            return;
        }
    }

    public void SetTimeData(string whatGhost, int whatTime)
    {
        if (GetSaveDataTime(whatGhost) < whatTime)
        {
            Debug.Log("클리어 시간이 전 기록보다 더 길다!");
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
            Debug.Log("아직 클리어 하지 못함");
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
            Debug.Log("아직 못찾음");
            return "NOTFOUND";
        }
    }
}
