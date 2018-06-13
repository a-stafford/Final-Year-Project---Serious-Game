using UnityEngine;
using System.Collections;

public class ThrusterAnimation : MonoBehaviour {

    public Animator anim, anim1, anim2;

    //starts the thruster animation when the game starts
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Thrust", true);
        anim2.SetBool("Thrust", true);
        InvokeRepeating("Smoke", 3.0f, 3.0f);
    }

    void Smoke()
    {
        anim.SetTrigger("Smoke");
    }
}

