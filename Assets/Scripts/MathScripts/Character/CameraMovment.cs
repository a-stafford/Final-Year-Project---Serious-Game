using UnityEngine;
using System.Collections;

public class CameraMovment : MonoBehaviour
{

    public GameObject player;
    bool dead = true;

    private Vector3 offset;

    //cameraMovment Script makes the camera follow the player postion at all times, this is needed to allow the infinte scroll to work.
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    

    void LateUpdate()
    {
        try
        {
            transform.position = player.transform.position + offset;
        }
        catch (MissingReferenceException)
        {
            
            if (dead)
            {
                Debug.Log("Player Dead GAME OVER");
                dead = false;
            }
        }
    }
}
