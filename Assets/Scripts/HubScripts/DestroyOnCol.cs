using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCol : MonoBehaviour
{
    //destorys student opn collision with portal to simualte them entering the portal
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Student")
        {
            Destroy(collision.gameObject);
        }
    }
}
