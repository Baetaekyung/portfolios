using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialoguePanel : MonoBehaviour,IPopUpable
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private DescriptionSO Description;

    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private float descriptionSpeed;
    [SerializeField] private float descriptionCompleteWaitTime;
    private int currentDescriptionIdx;
    
    private bool _isActive;
    
    public event Action DialogueEvent;

    private void Start()
    {
        DialogueEvent += PopUpHandler;
    }

    private void OnDestroy()
    {
        DialogueEvent -= PopUpHandler;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            DialogueEvent.Invoke();
        }

        
    }

    public void StartDialogue()
    {
        string currentDes = Description.GetDescriptionIdx(currentDescriptionIdx++);
        StopAllCoroutines();
        StartCoroutine(TextRoutine(currentDes));
    }

    private IEnumerator TextRoutine(string _str)
    {
        foreach (var item in _str)
        {
            descriptionText.text += item;
            yield return new WaitForSeconds(descriptionSpeed);
        }

        yield return new WaitForSeconds(descriptionCompleteWaitTime);
        DialogueEvent.Invoke();
    }
    
    
    public void PopUp()
    {
        rectTransform.DOMoveY(0, 0.3f).OnComplete(StartDialogue);
    }

    public void PopDown()
    {
        rectTransform.DOMoveY(-500, 0.3f).OnComplete(() =>
        {
            descriptionText.SetText(string.Empty);
        });
    }

    private void PopUpHandler()
    {
        if (_isActive == false)
        {
            _isActive = true;
            PopUp();
        }
        else
        {
            _isActive = false;
            PopDown();
        }
    }
}
