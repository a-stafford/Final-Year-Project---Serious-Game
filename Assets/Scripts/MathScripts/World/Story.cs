using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    public Text nameText;
    public GameObject winScreen;
    public Image winImg;
    private float transition = 0.0f;
    public Text dialogueText;
    public Transform dialogBox;
    public Dialogue dialogue2, dialogue3;
    public float maxSpeed = 5f;
    public bool stop = false, move = true, secondDia = false, secondStarted = false, thirdStarted = false, thirdDia = false, win = false;
    public static bool CanReload = true, canWrite = false;
    public GameObject player, player2, enemy;
    public MathQuestions math;

    public Animator animator, anim, anim2;

    private Queue<string> sentences;

    void Start()
    {
        anim.SetTrigger("Test");
        sentences = new Queue<string>();
    }

    public void Update()
    {
        canWrite = win;
        if (MathQuestions.answerPoints == 11)
        {
            stop = false;
        }

        if (!thirdStarted)
        {

            if (MathQuestions.answerPoints != 19 && thirdDia == false)
            {
                CanReload = true;
            }
            else
            {
                if (MathQuestions.answerPoints == 19 && thirdDia == false)
                {
                    CanReload = false;
                }
            }


            if (MathQuestions.answerPoints == 20 && stop == false)
            {
                stop = true;
                StartThirdDialogue(dialogue3);
            }
        }

        if (move)
        {
            player2.transform.position += transform.up * Time.deltaTime * maxSpeed;
        }

        if (Input.GetKeyDown("space"))
        {
            DisplayNextSentence();
        }

        if (Input.GetKeyDown("space") && secondStarted == true)
        {
            anim.SetBool("Thrust", false);
            anim2.SetBool("Thrust", false);
            move = false;
        }

        if (!secondStarted)
        {

            if (MathQuestions.answerPoints != 9 && secondDia == false)
            {
                CanReload = true;
            }
            else
            {
                if (MathQuestions.answerPoints == 9 && secondDia == false)
                {
                    CanReload = false;
                }
            }

            if (MathQuestions.answerPoints == 10 && stop == false && secondDia == false)
            {
                stop = true;
                StartSecondDialogue(dialogue2);
            }
        }

        WinScr();
    }

    //starts first dialogue and corrosponding animations
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        anim.SetBool("Thrust", false);
        anim2.SetBool("Thrust", false);
        move = false;

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
        if (thirdDia)
        {
            win = true;
        }

        if (!thirdDia)
        {
            move = false;
            player2.GetComponent<PlayerShoot>().enabled = true;
            player2.GetComponent<SpaceshipRotation>().enabled = true;
            player.GetComponent<MathQuestions>().enabled = true;
        }

        if (secondDia)
        {
            secondDia = false;
            MathQuestions.reload2 = true;
        }

        animator.SetBool("IsOpen", false);
    }

    //triggers the second dialogue later in the game and corrosponding animations
    public void StartSecondDialogue(Dialogue dialogue)
    {

        anim.SetBool("Thrust", true);
        anim2.SetBool("Thrust", true);

        secondStarted = true;

        player.GetComponent<MathQuestions>().enabled = false;
        player2.GetComponent<PlayerShoot>().enabled = false;
        player2.GetComponent<SpaceshipRotation>().enabled = false;
        secondDia = true;
        animator.SetBool("IsOpen", true);

        move = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //triggers the second dialogue later in the game and corrosponding animations
    public void StartThirdDialogue(Dialogue dialogue)
    {
        anim.SetBool("Thrust", true);
        anim2.SetBool("Thrust", true);

        thirdStarted = true;
        player.GetComponent<MathQuestions>().enabled = false;
        player2.GetComponent<PlayerShoot>().enabled = false;
        player2.GetComponent<SpaceshipRotation>().enabled = false;
        thirdDia = true;
        animator.SetBool("IsOpen", true);

        move = true;
        anim.SetBool("Thrust", true);
        anim2.SetBool("Thrust", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //triggers win screen when the third dialogue is over
    void WinScr()
    {
        if (win)
        {
            //FileWrite.Write(math.incorrectAns);
            transition += Time.deltaTime;
            winImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
            winScreen.SetActive(true);
        }
    }
}