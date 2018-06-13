using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour
{


    public float maxSpeed = 5f;

    //the player is moved forward at the speed defined in maxSpeed in which ever direction the player is facing
    void Update()
    {

        transform.position += transform.up * Time.deltaTime * maxSpeed;
    }
}
