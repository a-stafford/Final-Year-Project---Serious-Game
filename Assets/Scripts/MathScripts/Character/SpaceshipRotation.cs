using UnityEngine;
using System.Collections;

public class SpaceshipRotation : MonoBehaviour
{
    void Update()
    {
        //the player spaceship rotation is controlled by the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
