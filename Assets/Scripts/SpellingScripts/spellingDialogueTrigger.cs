using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellingDialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    //triggers the first dialogue after a 1 second delay
    void Start()
    {
        StartCoroutine(TriggerDialogue(false, 1f));
    }

    IEnumerator TriggerDialogue(bool status, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        FindObjectOfType<spellingStory>().StartDialogue(dialogue);
    }

}
