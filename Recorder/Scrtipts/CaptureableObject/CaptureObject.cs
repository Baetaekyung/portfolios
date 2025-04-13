using UnityEngine;

public class CaptureObject : MonoBehaviour, ICaptureable
{
    [ColorUsage(true, true)] public Color color;
    public SpawnItemTypeEnum spawnType;
    public SelectGhostObject selectObject;
    private MeshRenderer _meshRenderer;
    private Material _material;

    protected virtual void Awake()
    {
        Init();
    }

    private void Init()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _material = _meshRenderer.material;
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

    public virtual void GetPointed()
    {
        _material.color = color;
    }

    public virtual void OutPointed()
    {
        _material.color = Color.white;
    }
}
