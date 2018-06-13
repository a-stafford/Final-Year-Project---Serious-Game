using UnityEngine;
using System.Collections;

public class ProjectileMovment : MonoBehaviour
{


    public float maxSpeed = 8f;

    //the projectile is moved forward at the speed defined in maxSpeed in which ever direction it its facing when it is instantiated
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
