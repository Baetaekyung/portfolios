using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    public virtual void Selected()
    {
        gameObject.SetActive(true);
    }
    public virtual void Unselected()
    {
        gameObject.SetActive(false);
    }
}
