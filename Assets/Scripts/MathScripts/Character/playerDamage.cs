using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{

    //player takes damage when they collide with a enemy missile
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyProjectile")
        {
            MathQuestions.reload = true;
        }

    }
}
