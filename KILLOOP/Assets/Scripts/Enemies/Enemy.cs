using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private EnemyConfig _enemyConfig;

    private Transform _player;

    private IEnemyState _currentState;

    private int _currentPatrolIndex;

    public IReadOnlyList<Transform> PatrolPoints => _patrolPoints;
    public Transform CurrentPatrolPoint => _patrolPoints[_currentPatrolIndex];

    public Transform Player => _player;
    public EnemyConfig Config => _enemyConfig;

    [Inject]
    private void Construct(PlayerFacade playerFacade)
    {
        _player = playerFacade.transform;
    }

    private void Start()
    {
        ChangeState(new EnemyIdleState(this));
    }

    private void Update()
    {
        _currentState?.Update();
    }

    public void ChangeState(IEnemyState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
    public void MoveTowards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            _enemyConfig.PatrolSpeed * Time.deltaTime);
    }
    public void MoveTowardsTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            _enemyConfig.ChaseSpeed * Time.deltaTime);
    }
    public void SwitchToNextPatrolPoint()
    {
        _currentPatrolIndex++;

        if (_currentPatrolIndex >= _patrolPoints.Count)
            _currentPatrolIndex = 0;
    }
}
