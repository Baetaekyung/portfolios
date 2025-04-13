using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoSingleton<GhostManager>
{
    public Ghost[] ghosts;
    public Ghost selectedGhost;
    public GameObject ghostObject;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (selectedGhost == null) return;
        if (GhostAggressiveManager.Instance == null) return;
        if (ghostObject == null) return;

        if(GhostAggressiveManager.Instance.ghostAggressive >= 60) 
        {
            ghostObject.SetActive(true);
        }

        if(GhostAggressiveManager.Instance.ghostAggressive >= 80
            && GhostAggressiveManager.Instance.ghostAggressive <= 90)
        {
            Debug.Log("귀신이 화나서 속도가 6.5가 됩니다");
            selectedGhost.agent.speed = selectedGhost.data.speed * 1.2f;
        }
        if (GhostAggressiveManager.Instance.ghostAggressive >= 90
            && GhostAggressiveManager.Instance.ghostAggressive <= 90)
        {
            Debug.Log("귀신이 화나서 속도가 8이 됩니다");
            selectedGhost.agent.speed = selectedGhost.data.speed * 1.5f;
        }
        if (GhostAggressiveManager.Instance.ghostAggressive >= 100)
        {
            Debug.Log("귀신이 화나서 속도가 10이 됩니다");
            selectedGhost.agent.speed = selectedGhost.data.speed * 2f;
        }
    }

    public void SetGhost()
    {
        int index = Random.Range(0, ghosts.Length);
        Debug.Log(index);
        selectedGhost = ghosts[index];
        GhostAggressiveManager.Instance.GameStart();
    }
}
