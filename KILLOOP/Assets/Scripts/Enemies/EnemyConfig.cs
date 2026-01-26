using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Enemy")]
public class EnemyConfig : ScriptableObject
{
    public float PatrolSpeed;
    public float ChaseSpeed;
    public float ChaseRadius;
    public float AttackRadius;
    public float AttackCooldown;
    public float IdleDuration;
    public float PointReachDistance;
}
