using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public void Kill()
    {
        Destroy(gameObject);
        //анимация, звук и бла бла бла
    }

}
