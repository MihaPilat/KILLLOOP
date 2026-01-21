using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "PlayerConfig",
    menuName = "Configs/Player Config"
)]
public class PlayerConfig : ScriptableObject
{
    public float MoveSpeed = 6f;

    [Header("Attack")]
    public float AttackRange = 1.2f;
    public float AttackDuration = 0.1f;
    public float AttackCooldown = 0.25f;
}
