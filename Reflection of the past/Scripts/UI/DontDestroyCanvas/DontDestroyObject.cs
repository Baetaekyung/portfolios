using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    private void Awake()
    {
        print(name);
        Debug.Log($"Dont Destroy {gameObject.name.ToString()} Object");
        DontDestroyOnLoad(gameObject);
    }
}
