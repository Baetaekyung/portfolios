using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [HideInInspector] public PlayerController Player;
    public AudioSource PlayerEar;
    public bool isInGhostArea = false;

    protected override void Awake()
    {
        base.Awake();
        Player = FindObjectOfType<PlayerController>();
        PlayerEar = Player.GetComponent<AudioSource>();
        isInGhostArea = false;
    }
}
