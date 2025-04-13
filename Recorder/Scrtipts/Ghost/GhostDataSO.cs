using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SO/GhostData")]
public class GhostDataSO : ScriptableObject
{
    public string ghostName;
    public string deadSceneName;
    public GameObject ghostDummy;
    public List<SpawnItemTypeEnum> favoriteObjects;
    public GhostTypeEnum type;
    public AudioSource ghostSound;
    public float coldAreaRange; // 주변으로 추운 영역을 만듬
    [Range(1, 10)] public int aggression; // 공격성
    public float speed;
}
