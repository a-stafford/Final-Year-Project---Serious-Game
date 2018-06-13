using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    //gives portals a spinning aniamtion
    void Update()
    {
        transform.Rotate(0, 0, -5);
    }
}
