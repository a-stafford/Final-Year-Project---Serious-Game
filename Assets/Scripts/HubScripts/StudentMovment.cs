using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentMovment : MonoBehaviour
{
    //public static bool move = false;
    public static string moveTarget;
    NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    //when the player clicks on either the first or second portal the navmesh agent is given this point as the destination and the studnets move towards it
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.collider.name == "EnglishPortal" || hit.collider.name == "MathPortal")
                {
                    moveTarget = hit.collider.name;
                    agent.destination = hit.point;
                }

            }
        }
    }
}