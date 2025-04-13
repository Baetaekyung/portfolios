using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public bool findGhost = false;
    public string ghostName = "";
    public SelectedObjectSO selectObjects;
    public int currentSelectedObjectCount = 0;
    public int timer = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        findGhost = false;
        timer = 0;
        currentSelectedObjectCount = 0;
    }

    private void Update()
    {
        TimerAndGhostFind();
    }

    private void TimerAndGhostFind()
    {
        float t = Time.time;
        timer = Mathf.RoundToInt(t);

        if (currentSelectedObjectCount == 4)
        {
            findGhost = true;
            if (GhostManager.Instance.selectedGhost.data.type == GhostTypeEnum.SlenderMan)
            {
                ghostName = "½½·»´õ¸Ç";
            }
            else if (GhostManager.Instance.selectedGhost.data.type == GhostTypeEnum.Girl)
            {
                ghostName = "¼Ò³à±Í½Å";
            }
        }
    }
}
