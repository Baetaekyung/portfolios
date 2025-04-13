using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Swift_Blade
{
    [Serializable] [CreateAssetMenu(fileName = "ItemData_", menuName = "SO/Item/ItemData")]
    public class ItemDataSO : ScriptableObject
    {
        public ItemSlot  ItemSlot { get; set; }
        public Sprite    itemImage;
        
        [TextArea(4, 5)]
        public string     description;
        public string     itemName;
        public ItemType   itemType;
        public ItemObject itemObject;
        
        [Space, Header("����� �� �ʿ��� ������")]
        public EquipmentData equipmentData; //����� ���� �־��ֱ�
        
        public bool IsEquipment() => itemType == ItemType.EQUIPMENT;
    }
}
