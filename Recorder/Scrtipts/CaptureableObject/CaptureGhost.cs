using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureGhost : MonoBehaviour, ICaptureable
{
    public AudioSource source;
    public SkinnedMeshRenderer[] mesh;
    [ColorUsage(true, true)] public Color color;
    public SpawnItemTypeEnum spawnType;
    public SelectGhostObject selectObject;
    private bool isGetAngry = false;

    private void OnDestroy()
    {
        mesh = null;
    }

    public virtual void Captured()
    {
        selectObject.isFinded = true;
        selectObject.isSelected = true;
        selectObject.SetColor();
        GameManager.Instance.currentSelectedObjectCount++;
        GhostAggressiveManager.Instance.AddAggressive();
        Destroy(this.gameObject);
    }

    public void GetPointed()
    {
        if(mesh != null)
        {
            foreach(var mes in mesh)
            {
                Material mat = mes.material;
                mat.color = color;
            }
        }

        if (isGetAngry == false)
        {
            source.Play();
            isGetAngry = true;
            
            StartCoroutine(DelayRoutine());
        }
    }

    private IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(2f);
    }

    public void OutPointed()
    {
        if(mesh != null)
        {
            foreach (var mes in mesh)
            {
                Material mat = mes.material;
                mat.color = Color.white;
            }
        }
        
        isGetAngry = false;
        source.Stop();
    }
}
