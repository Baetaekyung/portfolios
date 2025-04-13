using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform ghostSpawnTransform;
    public List<CaptureObject> list;
    public List<CaptureGhost> ghostList;
    private Ghost ghost;

    private void Start()
    {
        ghost = GhostManager.Instance.selectedGhost;

        Init();
    }

    private void Init()
    {
        Spawn();

        GhostManager.Instance.ghostObject =
            Instantiate(ghost.gameObject, ghostSpawnTransform.position, 
            ghost.gameObject.transform.localRotation);
    }

    private void Spawn()
    {
        foreach (SpawnItemTypeEnum type in ghost.data.favoriteObjects)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(type == list[i].spawnType)
                {
                    list[i].gameObject.SetActive(true);
                }
            }
            for(int i = 0; i < ghostList.Count; i++)
            {
                if(type == ghostList[i].spawnType)
                {
                    ghostList[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
