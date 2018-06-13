using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hubStory : MonoBehaviour
{
    public Text nameText, dialogueText;
    private float transition = 0.0f, maxSpeed = 5f;
    public Transform dialogBox;
    public int _sentence;
    public Dialogue dialogue, dialogue2, dialogue3;
    public GameObject portal, portal1;
    GameObject[] students;
    public Animator anim;
    public bool move = false, finalDia = false;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        StartCoroutine(TriggerDialogue(false, 1f));
        students = GameObject.FindGameObjectsWithTag("Student");
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _sentence++;
            DisplayNextSentence();
        }

        if (_sentence == 1)
        {
            portal.SetActive(true);
            portal1.SetActive(true);
        }

        if (GameObject.FindGameObjectWithTag("Student") == null)
        {
            chooseLevel(StudentMovment.moveTarget);
        }
    }

    //triggers the first dialogue after a 1 second delay
    IEnumerator TriggerDialogue(bool status, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        StartDialogue(dialogue);
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


    //called when there is no more line sof dialogue lef
    void EndDialogue()
    {
        foreach (GameObject stu in students)
        {
            stu.GetComponent<StudentMovment>().enabled = true;
        }

        anim.SetBool("IsOpen", false);
    }

    //chooses which level has been selected when the portal was clicked
    void chooseLevel(string Scene)
    {
        switch (Scene)
        {
            case "EnglishPortal":
                SceneManager.LoadScene("SpellingGuide");
                break;

            case "MathPortal":
                SceneManager.LoadScene("MathGuide");
                break;
        }
    }
}