using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class HoverButton : MonoBehaviour, IHoverable, IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private float _hoverSize = 1.1f;
    [SerializeField] private float _hoverAnimationSpeed = 10f;
    
    private bool _isHovered = false;

    protected virtual void Update()
    {
        OnHovering();
    }
    
    public void OnHovering()
    {
        if (_isHovered)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * _hoverSize,
                Time.deltaTime * _hoverAnimationSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one,
                Time.deltaTime * _hoverAnimationSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isHovered = false;
    }
}
