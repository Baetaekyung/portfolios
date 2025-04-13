using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChecker : MonoBehaviour
{
    [SerializeField] private float _playerGhostCheckRange;
    [SerializeField] LayerMask _ghostObjectLayer;
    [SerializeField] LayerMask _ghostLayer;
    private Collider[] _hits;

    private void Awake()
    {
        _hits = new Collider[1];
    }

    private void FixedUpdate()
    {
        if(GhostCheck())
        {
            //TemperatureManager.Instance.OnColdArea();
            PlayerManager.Instance.isInGhostArea = true;
        }
        else
        {
            //TemperatureManager.Instance.OutColdArea();
            PlayerManager.Instance.isInGhostArea = false;
        }
    }

    private bool GhostCheck()
    {
        int count = Physics.OverlapSphereNonAlloc(
            transform.position,
            _playerGhostCheckRange, 
            _hits, _ghostLayer | _ghostObjectLayer);

        return count > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _playerGhostCheckRange);
    }
}
