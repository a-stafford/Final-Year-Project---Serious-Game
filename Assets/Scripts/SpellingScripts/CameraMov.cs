using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public float smoothTimeY;
    public GameObject character;
    bool dead = true;
    private Vector2 velocity;
    private Vector3 CameraOffset;

    //moves the camera with the player
    void LateUpdate()
    {
        float posy = Mathf.SmoothDamp(transform.position.y, character.transform.position.y, ref velocity.y, smoothTimeY);
        transform.position = transform.position = new Vector3(transform.position.x, posy, transform.position.z); ;
    }
}