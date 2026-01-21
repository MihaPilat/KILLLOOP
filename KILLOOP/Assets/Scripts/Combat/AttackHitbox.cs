using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;
        if (collision.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.Kill();
        }
    }
}
