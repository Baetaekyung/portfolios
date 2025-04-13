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
        _textGhostName.text = $"�߰ߵ� �ͽ��� : {GhostManager.Instance.selectedGhost.data.name}�̴�..";
        _textTimer.text = $"ã�Ƴ� �ð� : {GameManager.Instance.timer}�ʰ� �ɷȴ�..";
    }
}
