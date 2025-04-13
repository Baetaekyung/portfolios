using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public NavMeshAgent agent;
    public float destinationChangeTime;
    public GhostDataSO data;
    public float attackRange;
    public LayerMask whatIsPlayer;
    private Collider[] _container;
    private bool _playerInRange = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _container = new Collider[1];
        StartCoroutine(SetDestination());
    }
    
    private void Update()
    {
        CheckPlayerInRange();
    }

    private void CheckPlayerInRange()
    {
        if (Physics.OverlapSphereNonAlloc(
            transform.position, attackRange,
            _container, whatIsPlayer) != 0
            && !_playerInRange)
        {
            _playerInRange = true;
            CatchThePlayer();
        }
        else if (Physics.OverlapSphereNonAlloc(
            transform.position, attackRange,
            _container, whatIsPlayer) == 0
            && _playerInRange)
        {
            _playerInRange = false;
            Debug.Log("³ª°¨");
        }
    }


    private void CatchThePlayer()
    {
        if (_playerInRange)
        {
            CursorManager.Instance.SetCursorVisibleTrue();
            CursorManager.Instance.uiMode = true;
            GhostAggressiveManager.Instance.StopAdd();
            SceneManager.LoadScene(data.deadSceneName);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private IEnumerator SetDestination()
    {
        while(true)
        {
            agent.SetDestination(PlayerManager.Instance.Player.transform.position);
            yield return new WaitForSeconds(destinationChangeTime);
        }
    }
}
