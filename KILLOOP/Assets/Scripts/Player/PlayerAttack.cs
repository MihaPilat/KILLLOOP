using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    private IInput _input;
    private PlayerConfig _config;

    private bool _canAttack = true;

    [SerializeField] private AttackHitbox _hitboxPrefab;

    [Inject]
    public void Construct(IInput input, PlayerConfig config)
    {
        _input = input;
        _config = config;
    }

    private void Update()
    {
        if (_input.Attack && _canAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        _canAttack = false;

        Vector2 direction = _input.Move;
        if (direction == Vector2.zero)
            direction = Vector2.up; // fallback

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
