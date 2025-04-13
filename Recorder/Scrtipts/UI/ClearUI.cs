using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textGhostName;
    [SerializeField] private TextMeshProUGUI _textTimer;

    private void OnEnable()
    {
        SetText();
    }

    private void SetText()
    {
        _textGhostName.text = $"발견된 귀신은 : {GhostManager.Instance.selectedGhost.data.name}이다..";
        _textTimer.text = $"찾아낸 시간 : {GameManager.Instance.timer}초가 걸렸다..";
    }
}
