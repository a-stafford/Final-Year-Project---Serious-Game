using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    //name of person speaking
    public string name;

    [TextArea(3, 10)]
    //sentences they are speaking
    public string[] sentences;
}
