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
}
