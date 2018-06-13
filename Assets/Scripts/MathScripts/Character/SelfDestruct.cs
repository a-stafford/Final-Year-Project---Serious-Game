using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public float timer = 1f;

	
	void Update () {
        //when the timer reaches 0 the game object this script is attached to is destroyed
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }


	}

    //when collided with delete any other player projectiles to stop hitting a just spawned enemy
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(GameObject.FindWithTag("PlayerProjectile2"));
        Destroy(GameObject.FindWithTag("PlayerProjectile"));
    }
}
