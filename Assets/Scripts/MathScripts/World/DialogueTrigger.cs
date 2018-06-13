using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    //triggers the first dialogue after a 3 second delay
    void Start()
    {
        StartCoroutine(TriggerDialogue(false, 3f));
    }

    IEnumerator TriggerDialogue(bool status, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        FindObjectOfType<Story>().StartDialogue(dialogue);
    }
}
