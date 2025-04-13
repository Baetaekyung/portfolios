using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out PlayerController p))
        {
            p.transform.position = _playerSpawnPosition.position;
        }
    }
}
