using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAggressiveManager : MonoSingleton<GhostAggressiveManager>
{
    [Range(0, 100f)] public float ghostAggressive = 0f;
    public bool isStarted = false;
    public bool attackable = false;
    private Ghost ghost;

    protected override void Awake()
    {
        base.Awake();
    }

    public void GameStart()
    {
        ghost = GhostManager.Instance.selectedGhost;
        StartCoroutine(IdleAggressiveAdd());
    }

    public void StopAdd()
    {
        ghostAggressive = 0;
        StopAllCoroutines();
    }
    
    private IEnumerator IdleAggressiveAdd()
    {
        float aggressiveAddTime = 20f;
        while(ghostAggressive <= 100)
        {
            ghostAggressive += ghost.data.aggression / 2;
            Debug.Log(ghostAggressive);
            yield return new WaitForSeconds(aggressiveAddTime);
        }
    }

    public void AddAggressive()
    {
        ghostAggressive += ghost.data.aggression;
    }
}
