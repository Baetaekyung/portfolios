using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private readonly Dictionary<Type, IEntityCompo> _components = new();

    protected virtual void Awake()
    {
        SetEntityComponents();

        Initialize();
        AfterInitialize();
    }

    private void SetEntityComponents()
    {
        List<IEntityCompo> components = GetComponentsInChildren<IEntityCompo>(true).ToList();
        components.ForEach(compo => Debug.Log(compo.GetType().Name));

        foreach (IEntityCompoInit component in components)
        {
            Type componentType = component.GetType();
            if (_components.ContainsKey(componentType))
            { 
                Debug.LogWarning($"�ߺ��� EntityComponent: {componentType.Name}");
                continue;
            }

            _components.Add(componentType, component);
        }
    }

    private void Initialize()
    {
        _components.Values
            .OfType<IEntityCompoInit>()
            .ToList()
            .ForEach(component => component.Initialize(this));
    }

    private void AfterInitialize()
    {
        _components.Values
            .OfType<IEntityCompoAfterInit>()
            .ToList()
            .ForEach(component => component.AfterInitialize(this));
    }

    /// <param name="addComponentIfNotFound">���� ����ȭ �� ������ �����Ѵٸ� ������� �� ��</param>
    public T GetEntityCompo<T>(bool addComponentIfNotFound = false) where T : Component, IEntityCompo
    {
        if(_components.TryGetValue(typeof(T), out IEntityCompo component))
            return component as T;

        if (GetComponentInChildren<T>() != null)
        {
            T newGetComponent = GetComponentInChildren<T>();

            Debug.Log($"���� ã�� ������Ʈ {typeof(T).Name}");
            return newGetComponent;
        }

        if(addComponentIfNotFound == true)
        {
            T addedComponent = this.AddComponent<T>();

            if(addedComponent is IEntityCompoInit needInit)
                needInit.Initialize(this);
            if(addedComponent is IEntityCompoAfterInit needAfterInit)
                needAfterInit.AfterInitialize(this);

            Debug.Log($"���� �߰��� ������Ʈ {typeof(T).Name}");
            return addedComponent;
        }

        Debug.LogWarning($"Component�� �������� ����! Component name: {typeof(T).Name}");

        return default(T);
    }

    public bool TryGetEntityCompo<T>(out IEntityCompo compo) where T : Component, IEntityCompo
    {
        if(_components.TryGetValue(typeof(T), out compo))
            return true;

        compo = GetEntityCompo<T>();

        if(compo != null)
            return true;

        compo = default(T);
        Debug.LogWarning($"Component�� �������� ����! Component name: {typeof(T).Name}");

        return false;
    }
}