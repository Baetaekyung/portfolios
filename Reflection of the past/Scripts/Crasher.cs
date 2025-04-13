using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Crasher : MonoBehaviour
{
    private Vector3 _topPointPosition;
    private Vector3 _bottomPointPosition;
    
    private void Awake()
    {
        _topPointPosition = transform.position;
    }

    private void Start()
    {
        if (Physics.Raycast(transform.position, Vector3.down
                , out RaycastHit hit, Mathf.Infinity))
        {
            _bottomPointPosition = hit.point;
        }
        else
        {
            Debug.Log("Under point doesn't exist you need to add platform under this object!");
        }
    }

    private void MoveDown()
    {
        transform.DOMove(_bottomPointPosition + new Vector3(0, 1, 0), 1.5f).SetEase(Ease.InCirc)
            .OnComplete(MoveUp);
    }

    private void MoveUp()
    {
        transform.DOMove(_topPointPosition, 1.5f).SetEase(Ease.Linear)
            .OnComplete(MoveDown);
    }

    public void MoveStart()
    {
        //Do damage start!!
        MoveDown();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent<Player>(out var player))
        {
            player.Dead();
        }
    }
}
