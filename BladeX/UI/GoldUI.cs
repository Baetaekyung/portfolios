using System;
using TMPro;
using UnityEngine;

namespace Swift_Blade.UI
{
    public class GoldUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        
        private void Start()
        {
            InventoryManager.Inventory.OnCoinChanged += SetCoinUI;
            
            SetCoinUI();
        }

        private void OnDestroy()
        {
            InventoryManager.Inventory.OnCoinChanged -= SetCoinUI;
        }

        private void SetCoinUI()
        {
            if(InventoryManager.Inventory != null)                        
                coinText.text = $"{InventoryManager.Inventory.Coin.ToString()} ����";
            else
            {
                coinText.text = "0 ����";
            }
        }
                
        
    }
}
