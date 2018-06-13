using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public static string target;
    void OnMouseDown()
    {
        target = this.name;
    }
}
 
