using UnityEngine;

/// <summary>
/// �ö󰡴� value�� �ִ�� ��ø�� �� �ִ� ī��Ʈ ������ �ִ� SO
/// </summary>
[CreateAssetMenu(fileName = "new AdditiveData", menuName = "SO/Stat/AdditiveStatData")]
public class StatBuffDataSO : ScriptableObject
{
    [SerializeField] private EStatBuffType  statBuffType;
    [SerializeField] private EStatType      statType;
    [SerializeField] private string         statBuffName;
    [SerializeField] private int            maxLayerCount = 1;
    [SerializeField] private int            increaseAmount;

    public EStatBuffType GetStatBuffType   => statBuffType;
    public EStatType     GetStatType       => statType;
    public string        GetBuffName       => statBuffName;
    public int           GetMaxLayerCount  => maxLayerCount;
    public int           GetIncreaseAmount => increaseAmount;
}