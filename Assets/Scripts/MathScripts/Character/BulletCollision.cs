using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{
    public int health = 1;
    public string Colname;
    GameObject bullet1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Colname = MathQuestions.finalAns + "(Clone)";
        //when the game object this is attached to is collides with another game object the health variable is subtracted by 1  
        if (collision.collider.tag == "Player")
        {
            health--;
        }

        //if the players bullet collides with the correct answer ships this tells MathQuestions the player answered the question correctly else the player is incorrect
        if (collision.collider.name == Colname)
        {
            MathQuestions.Correct = true;
            MathQuestions.incorrect = false;

            Destroy(bullet1);


        }
        else
        {
            Debug.Log("Wrong answer BOi" + " " + MathQuestions.correctAnswerShip);
            MathQuestions.targetPlayer(MathQuestions.correctAnswerShip);
            MathQuestions.incorrect = true;
            MathQuestions.Correct = false;
            Destroy(bullet1);
        }
    }

    void Update()
    {
        bullet1 = GameObject.FindWithTag("PlayerProjectile");
        bullet1 = GameObject.FindWithTag("PlayerProjectile2");

        //if the health variable is less than or equal to 0 then the game object this script is attached to is destroyed 
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

