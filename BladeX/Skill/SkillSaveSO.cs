using System.Collections.Generic;
using Swift_Blade.Skill;
using UnityEngine;

namespace Swift_Blade
{
    [CreateAssetMenu(fileName = "SkillSaveSO", menuName = "SO/SkillSaveData")]
    public class SkillSaveSO : ScriptableObject
    {
        //���⼭ ��ų �����͵� �����ؼ� ��������.
        public List<SkillData> inventoryData;
        public List<SkillData> skillSlotData;

        public void AddSkillToInventory(SkillData skillData)
        {
            inventoryData.Add(skillData);
        }

        public void AddSkillToSlot(SkillData skillData)
        {
            skillSlotData.Add(skillData);
        }

        public void RemoveSlotSkillData(SkillData skillData)
        {
            skillSlotData.Remove(skillData);
        }

        public void RemoveInventoryData(SkillData skillData)
        {
            inventoryData.Remove(skillData);
        }
        
        public SkillSaveSO Clone()
        {
            SkillSaveSO so = Instantiate(this);

            so.skillSlotData = new List<SkillData>();
            so.inventoryData = new List<SkillData>();
            
            //Deep copy...
            foreach (var skillData in skillSlotData)
            {
                so.skillSlotData.Add(skillData);
            }

            //Deep copy...
            foreach (var invenData in inventoryData)
            {
                so.inventoryData.Add(invenData);
            }

            return so;
        }
    }
}
