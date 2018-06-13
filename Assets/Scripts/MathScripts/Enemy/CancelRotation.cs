using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelRotation : MonoBehaviour
{

    public Transform child;

    //cancels the rotation of the text which displays the numbers on the enemy, so it remains visable
    void Update()
    {
        child.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }
}