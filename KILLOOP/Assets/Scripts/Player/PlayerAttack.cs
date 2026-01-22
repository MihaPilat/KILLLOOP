using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    private IInput _input;
    private PlayerConfig _config;

    private bool _canAttack = true;
    private Vector2 _lastDirection= Vector2.up;

    [SerializeField] private AttackHitbox _hitboxPrefab;

    [Inject]
    public void Construct(IInput input, PlayerConfig config)
    {
        _input = input;
        _config = config;
    }

    private void Update()
    {
        Vector2 direction = _input.Move;
        if (direction == Vector2.zero)
            direction = _lastDirection;
        else
            _lastDirection = direction;
        if (_input.Attack && _canAttack)
        {

            StartCoroutine(AttackRoutine(direction));
        }
    }

    private IEnumerator AttackRoutine(Vector2 direction)
    {
        _canAttack = false;

        

        var hitbox = Instantiate(
            _hitboxPrefab,
            (Vector2)transform.position + direction.normalized * _config.AttackRange,
            Quaternion.identity
        );

        Destroy(hitbox.gameObject, _config.AttackDuration);

        yield return new WaitForSeconds(_config.AttackCooldown);
        _canAttack = true;
    }
}
