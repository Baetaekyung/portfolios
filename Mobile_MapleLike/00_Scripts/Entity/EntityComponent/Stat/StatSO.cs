using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public delegate void StatChangeEventHandler();

[CreateAssetMenu(menuName = "SO/Stat/Stat")]
public class StatSO : ScriptableObject
{
    public event StatChangeEventHandler OnBaseStatValueChanged;
    public event StatChangeEventHandler OnAdditionalStatValueChanged;
    public event StatChangeEventHandler OnStatMultiplierChanged;

    [SerializeField] private EStatType statType;
    [SerializeField] private int       baseStat;
    [SerializeField] private int       additionalStat;
    [SerializeField] private int       statMultiplier;

    private readonly Dictionary<StatBuffDataSO, List<int>> _additiveAmountCollection = new();
    private readonly Dictionary<StatBuffDataSO, int>       _additiveLayerCollection  = new();

    public EStatType GetStatType       => statType;
    public StatSO    GetRuntimeStat    => Instantiate(this);
    public int       BaseStat       { get; set; }
    public int       AdditionalStat { get; set; }

    #region [BaseStat] Increase, Decrease

    public void IncreaseBaseStat(int increaseAmount)
    {
        baseStat += increaseAmount;

        OnBaseStatValueChanged?.Invoke();
    }

    public void DecreaseBaseStat(int decreaseAmount)
    {
        baseStat -= decreaseAmount;

        OnBaseStatValueChanged?.Invoke();
    }

    #endregion

    #region [AdditionalStat] Increase, Decrease

    public void IncreaseAdditionalStat(int increaseAmount)
    {
        additionalStat += increaseAmount;

        OnAdditionalStatValueChanged?.Invoke();
    }

    public void DecreaseAdditionalStat(int decreaseAmount)
    {
        additionalStat -= decreaseAmount;

        OnAdditionalStatValueChanged?.Invoke();
    }

    #endregion

    #region [StatMultiplier] Increase, Decrease

    public void IncreaseStatMultiplier(int increaseAmount)
    {
        statMultiplier += increaseAmount;

        OnAdditionalStatValueChanged?.Invoke();
    }

    public void DecreaseStatMultiplier(int decreaseAmount)
    {
        statMultiplier -= decreaseAmount;

        OnAdditionalStatValueChanged?.Invoke();
    }

    #endregion

    #region Stat Buff ����

    public void StatBuff(StatBuffDataSO additiveStatData)
    {
        Debug.Assert(additiveStatData.GetStatType == statType,
            $"���� �ʴ� ������ ������ �־���. ���� Ÿ��: {statType.ToString()}");

        // ���� ������ ����
        if (_additiveLayerCollection.TryGetValue(additiveStatData, out var layerAmount))
        {
            // ���� ������ �ִ� ��ø �����̴�.
            if (additiveStatData.GetMaxLayerCount == layerAmount)
                AddMaxLayerStatBuff(additiveStatData);
            // �ִ� ��ø �ƴϸ� ��ø ���� �ø��� ���� �߰��ϱ�
            else
                AddStatBuff(additiveStatData);
        }
        // ó�� ����Ǵ� ������� �׳� ���� ���̾� 1 �߰��ϰ� ���� �� �߰��ϱ�
        else
            InitStatBuff(additiveStatData);
    }

    public void RemoveStatBuff(StatBuffDataSO additiveStatData)
    {
        Debug.Assert(additiveStatData.GetStatType == statType, $"���� �ʴ� ������ ������ �־���. ���� Ÿ��: {statType.ToString()}");

        if (_additiveAmountCollection.TryGetValue(additiveStatData, out var amountList))
        {
            int matchAmountIndex = 0;
            bool hasMatchBuff = false;

            for(int i = 0; i < amountList.Count; i++)
            {
                if (amountList[i] == additiveStatData.GetIncreaseAmount)
                {
                    matchAmountIndex = i;
                    hasMatchBuff = true;

                    break;
                }
            }

            if(hasMatchBuff == false)
            {
                Debug.Log($"�������� �ʴ� ���� ���, ���� �̸�: {additiveStatData.GetBuffName}");
                return;
            }

            _additiveAmountCollection[additiveStatData].RemoveAt(matchAmountIndex);
            _additiveLayerCollection[additiveStatData]--;
        }
        else
        {
            Debug.Log($"�������� �ʴ� ���� ���, ���� �̸�: {additiveStatData.GetBuffName}");
        }
    }

    private void InitStatBuff(StatBuffDataSO additiveStatData)
    {
        Debug.Assert(additiveStatData.GetStatType == statType, $"���� �ʴ� ������ ������ �־���. ���� Ÿ��: {statType.ToString()}");

        _additiveLayerCollection.Add(additiveStatData, 1);

        _additiveAmountCollection.Add(additiveStatData, new List<int>() { additiveStatData.GetIncreaseAmount });
    }

    private void AddStatBuff(StatBuffDataSO additiveStatData)
    {
        Debug.Assert(additiveStatData.GetStatType == statType, $"���� �ʴ� ������ ������ �־���. ���� Ÿ��: {statType.ToString()}");

        _additiveLayerCollection[additiveStatData]++;

        _additiveAmountCollection[additiveStatData].Add(additiveStatData.GetIncreaseAmount);
    }

    private void AddMaxLayerStatBuff(StatBuffDataSO additiveStatData)
    {
        Debug.Assert(additiveStatData.GetStatType == statType,
            $"���� �ʴ� ������ ������ �־���. ���� Ÿ��: {statType.ToString()}");

        int minIncreaseAmount = int.MaxValue;
        int minAmountLayer = 0;
        int currentLayer = 0;

        for (; currentLayer < additiveStatData.GetMaxLayerCount; currentLayer++)
        {
            if (_additiveAmountCollection[additiveStatData][currentLayer] < minIncreaseAmount)
            {
                minIncreaseAmount = _additiveAmountCollection[additiveStatData][currentLayer];
                minAmountLayer = currentLayer;
            }
        }

        //���� �ø����� ������ �ѷ��� ���� ���� ������ �� ���� ���� �纸�� ������ ����
        if (minIncreaseAmount >= additiveStatData.GetIncreaseAmount)
            return;
        //���� �ø����� ������ �ѷ��� ���� ���� ���� �� ���� ���� �纸�� ũ��, ���� ���� �� ���� ���� �־��ֱ�
        else
        {
            _additiveAmountCollection[additiveStatData].RemoveAt(minAmountLayer);

            _additiveAmountCollection[additiveStatData].Add(additiveStatData.GetIncreaseAmount);
        }
    }

    private void EffectBuffToStat()
    {
        int index;

        foreach (var additiveBuffData in _additiveAmountCollection)
        {
            StatBuffDataSO statBuffData   = additiveBuffData.Key;
            List<int>      statBuffAmount = additiveBuffData.Value;

            EStatBuffType  statBuffType   = statBuffData.GetStatBuffType;

            for(index = 0; index < statBuffAmount.Count; index++)
                BuffAtMatchStatType(index, statBuffData, statBuffAmount, statBuffType);
        }
    }

    private void BuffAtMatchStatType(
        int             index, 
        StatBuffDataSO  statBuffData, 
        List<int>       statBuffAmount, 
        EStatBuffType   statBuffType)
    {
        switch (statBuffType)
        {
            case EStatBuffType.BASE_STAT_BUFF:
                baseStat += statBuffAmount[index];
                break;
            case EStatBuffType.ADDITIONAL_STAT_BUFF:
                additionalStat += statBuffAmount[index];
                break;
            case EStatBuffType.STAT_MULTIPLIER_BUFF:
                statMultiplier += statBuffAmount[index];
                break;
            default:
                Debug.Log($"StatBuffDataSO�� StatBuffType�� ���� ���� �ʾҽ��ϴ�. {statBuffData.GetBuffName}");
                break;
        }
    }



    #endregion
}