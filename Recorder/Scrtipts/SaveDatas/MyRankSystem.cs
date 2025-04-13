using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyRankSystem : MonoBehaviour
{
    [SerializeField] private string _whatIsGhostName;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _timeText;

    public void SetData()
    {
        _nameText.text = SaveManager.Instance.GetSaveDataClear(_whatIsGhostName);

        int time = SaveManager.Instance.GetSaveDataTime(_whatIsGhostName);

        if(time == 0)
        {
            _timeText.text = $"아직 발견되지 않음";
        }
        else
        {
            int minute = 0;

            while (time > 60)
            {
                if (time > 60)
                {
                    minute += 1;
                    time -= 60;
                }
            }

            string secondString = time.ToString();
            string minuteString = minute.ToString();

            _timeText.text = $"클리어 타임 [ {minuteString} : {secondString} ]";
        }
    }
}
