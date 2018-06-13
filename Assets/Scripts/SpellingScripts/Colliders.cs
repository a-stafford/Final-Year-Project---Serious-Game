using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    public static GameObject[] TopBlock, BottomBlock, Trig;

    public static bool trig = false, activate = false;
    public static int count = 1;

    void Update()
    {
        if (trig)
        {
            TopBlock = GameObject.FindGameObjectsWithTag("TopWall");
            BottomBlock = GameObject.FindGameObjectsWithTag("BottomWall");
            Trig = GameObject.FindGameObjectsWithTag("BlockTrig");
            trig = false;
        }
    }

    public static void RemoveCollider(int island)
    {
        Debug.Log(island);
        TopBlock[island].SetActive(false);
        if (island != 9)
        {
        BottomBlock[island + 1].SetActive(false);
        }

        activate = true;
    }

    public static void EnableCollider()
    {
        Debug.Log("activeated");

        if (activate)
        {
            activate = false;
            BottomBlock[count].SetActive(true);
            count++;
        }
    }
}
