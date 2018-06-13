using UnityEngine;
using System.Collections;

public class AbsoluteScroll:MonoBehaviour
{
    public float parralax = 2f;

    //this script controls the parallax scrolling element

    //when the offset is reached the picture is lopped to create a parallax effect
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;
        mat.mainTextureOffset = offset;

    }
}
