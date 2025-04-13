using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : CaptureObject
{
    [SerializeField] private GameObject rotateBox;
    public LayerMask canSeeLayer;
    public MeshRenderer[] meshRenderers;
    public AudioSource musicPlayer;

    private bool startRotate = false;

    protected override void Awake()
    {
        // None Do Init
    }

    public override void Captured()
    {
        selectObject.isFinded = true;
        selectObject.isSelected = true;
        selectObject.SetColor();
        GhostAggressiveManager.Instance.AddAggressive();
        GameManager.Instance.currentSelectedObjectCount++;

        foreach (var mesh in meshRenderers)
        {
            mesh.material.color = Color.white;
        }

        rotateBox.transform.localScale = new Vector3(1000, 1000, 1000);
        rotateBox.gameObject.layer = canSeeLayer;

        musicPlayer.loop = true;
        musicPlayer.Play();
        startRotate = true;

        Destroy(gameObject, 30f);
    }

    public override void GetPointed()
    {
        if (startRotate) return;

        foreach(var mesh in meshRenderers)
        {
            mesh.material.color = color;
        }
    }

    public override void OutPointed()
    {
        if (startRotate) return;

        foreach (var mesh in meshRenderers)
        {
            mesh.material.color = Color.white;
        }
    }

    private void Update()
    {
        if(startRotate)
        {
            rotateBox.transform.Rotate(0, 0, 180f * Time.deltaTime);
        }
    }
}
