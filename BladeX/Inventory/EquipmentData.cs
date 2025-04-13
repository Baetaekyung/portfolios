using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Swift_Blade
{
    public enum EquipmentSlotType
    {
        HEAD,
        ARMOR,
        WEAPON, 
        RING,
        SHOES
    }
    
    [CreateAssetMenu(fileName = "EquipmentData", menuName = "SO/Equipment/EquipmentData")]
    public class EquipmentData : ScriptableObject
    {
        public SerializableDictionary<StatType, float> statModifier = new();

        [HideInInspector]
        public string itemSerialCode; //���ݿ� ���Ҷ� �������ִ� ��ȣ
        public Sprite equipmentIcon;

        public EquipmentSlotType slotType;
        public ColorType         colorType;
        public int               colorAdder;

        private void OnValidate()
        {
            if (String.IsNullOrEmpty(itemSerialCode))
                itemSerialCode = Guid.NewGuid().ToString();
        }
    }
}
