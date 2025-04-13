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
    public float coldAreaRange; // �ֺ����� �߿� ������ ����
    [Range(1, 10)] public int aggression; // ���ݼ�
    public float speed;
}
