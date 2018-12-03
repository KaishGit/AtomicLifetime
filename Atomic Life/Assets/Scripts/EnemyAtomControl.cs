using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAtomControl : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _route;
    [SerializeField]
    private GameObject _eyes;
    private int _currentIndexRoute;
    private bool _reverteRoute;
    private NavMeshAgent _navMeshAgent;
    private bool _hasRoute;
    private bool _isIdle;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (_route.Count > 0)
        {
            _hasRoute = true;
        }

        if (_hasRoute)
        {
            _currentIndexRoute = 1;
            _reverteRoute = false;

            _navMeshAgent.SetDestination(_route[_currentIndexRoute].position);
        }

    }

    void Update()
    {
        if (_hasRoute)
        {
            Move();
        }
    }

    private void Move()
    {
        if (!_isIdle && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            if (_currentIndexRoute >= _route.Count - 1)
            {
                _reverteRoute = true;
            }
            else if (_route[_currentIndexRoute] == _route[0])
            {
                _reverteRoute = false;
            }

            if (_reverteRoute)
            {
                _currentIndexRoute = _currentIndexRoute - 1;
            }
            else
            {
                _currentIndexRoute = _currentIndexRoute + 1;
            }

            _navMeshAgent.SetDestination(_route[_currentIndexRoute].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeManager.Instance.DecreaseTime(10);
            SfxManager.Instance.PlaySfxLoss();
            GameManager.Instance.ShowEventTextRed("Collision: -10s Lifetime");
            EffectManager.Instance.CreateExplosionEffect(other.gameObject.transform.position);
            other.gameObject.GetComponent<AtomControl>().CloseEyes();
        }
    }

    public void ActiveIdleState()
    {
        _isIdle = true;
        _eyes.SetActive(false);
        _navMeshAgent.isStopped = true;
        StartCoroutine(WaitingForMove(10));
    }

    private IEnumerator WaitingForMove(float time)
    {
        yield return new WaitForSeconds(time);
        _navMeshAgent.isStopped = false;
        _isIdle = false;
        _eyes.SetActive(true);
    }
}
