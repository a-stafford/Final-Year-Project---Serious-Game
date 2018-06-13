using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour
{
    public GameObject ExplosionAnimation;
    public AudioClip explosionSound;
    public int health = 3;
    public float enemyPoints = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerProjectile")
        {
            health--;
        }

    }

    public void Update()
    {
        //if the enemy's health is equal to 0 an explosion animation is played and points are added to the score and the enemy drops health 
        if (health <= 0)
        {
            Explosion();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void Explosion()
    {
        SoundEffects.Instance.MakeExplosionSound();
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimation);
        explosion.transform.position = transform.position;
    }
}

