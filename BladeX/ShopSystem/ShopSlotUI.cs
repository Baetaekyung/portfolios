using System;
using DG.Tweening;
using Swift_Blade.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Swift_Blade
{
    public class ShopSlotUI : MonoBehaviour
    {
        private PlayerInventory playerInventory = InventoryManager.Inventory;

        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI itemNameText;
        [SerializeField] private TextMeshProUGUI itemDescriptionText;
        [SerializeField] private Button buyButton;
        [SerializeField] private TextMeshProUGUI remainCount;
        [SerializeField] private TextMeshProUGUI _buttonText;
        
        [SerializeField] private GameObject soldOutPanel;
        
        private ItemDataSO _currentItem;
        private int _itemCount;
        private int _itemCost;

        public CanvasGroup GetCanvasGroup => canvasGroup;
        
        public void SetSlotItem(ItemDataSO newItem, int count, int cost)
        {
            _itemCost    = cost;
            _currentItem = newItem;
            _itemCount   = count;
            
            _buttonText.text         = $"{_itemCost.ToString()}����";
            remainCount.text         = $"���� ����: {count.ToString()}";
            itemIcon.sprite          = newItem.itemImage;
            itemNameText.text        = newItem.itemName;
            itemDescriptionText.text = newItem.description;
        }
        
        private void OnEnable()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            canvasGroup.alpha = 0;
            buyButton.onClick.AddListener(TryBuy);
        }

        private void OnDestroy()
        {
            canvasGroup.alpha = 0;
            buyButton.onClick.RemoveListener(TryBuy);
        }

        public void TryBuy()
        {
            if (_itemCount <= 0)
            {
                GetFailedMessage("������ ����");

                return;
            }
            
            if (!_currentItem)
            {
                GetFailedMessage("������ ����");

                return;
            }

            if (playerInventory.Coin < _itemCost)
            {
                GetFailedMessage("������ �����մϴ�.");

                return;
            }
            
            if (playerInventory.currentInventoryCapacity == playerInventory.maxInventoryCapacity)
            {
                GetFailedMessage("�κ��丮 ���� ����");

                return;
            }

            BuyAnimation();
            
            _itemCount--;
            remainCount.text = $"���� ����: {_itemCount.ToString()}";
            
            InventoryManager.Instance.AddItemToMatchSlot(_currentItem);
            playerInventory.currentInventoryCapacity++;
            
            if(_itemCount <= 0)
                soldOutPanel.SetActive(true);
        }

        private void BuyAnimation()
        {
            buyButton.transform.DOKill();

            buyButton.transform.DOShakeScale(0.3f, new Vector3(0.3f, 0.3f, 0));
            buyButton.transform.DOShakeRotation(0.3f, new Vector3(0, 0, 2.5f));
        }

        private void GetFailedMessage(string message) => PopupManager.Instance.LogMessage(message);
    }
}
