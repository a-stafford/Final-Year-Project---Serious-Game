using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spellingStory : MonoBehaviour
{

    public Text nameText, dialogueText;
    private float transition = 0.0f, maxSpeed = 5f;
    public Transform dialogBox;
    public Dialogue dialogue2, dialogue3;
    public GameObject player;
    public Animator anim;
    public static bool win;
    public bool move = false, finalDia = false;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DisplayNextSentence();
        }

        if (move)
        {
            player.transform.position += transform.up * Time.deltaTime * maxSpeed;
        }
    }

    //starts first dialogue and corrosponding animations
    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //when called displays next sentence in the trigger dialogue
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //animates the outputted text
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //called when there is no more line sof dialogue left
    void EndDialogue()
    {
        player.GetComponent<PlayerMovment>().enabled = true;
        anim.SetBool("IsOpen", false);

        if (finalDia)
        {
            move = true;
            win = true;
        }
    }

    //triggers the second dialogue later in the game and corrosponding animations
    public void StartDialogue2(Dialogue dialogue)
    {
        player.GetComponent<PlayerMovment>().enabled = false;
        anim.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        finalDia = true;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
}