using UnityEngine;

namespace Swift_Blade
{
    public abstract class ItemObject : MonoBehaviour
    {
        public abstract void ItemEffect(Player player); //������ ȿ��
        public virtual bool CanUse() => true;
    }
}
