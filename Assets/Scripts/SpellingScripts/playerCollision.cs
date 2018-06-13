using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollision : MonoBehaviour
{
    public string Word, correctAnswer;
    public bool stop = true;
    public Dialogue dialogue;
    LoadQuestion Load;
    public Text spelling;
    public int i = 0, speed = 5, y = 1;
    public List<char> correctAns;
    public static bool correct, getAnswer, updateHealth, win;
    public Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        Invoke("GetAnswer", 0.5f);
    }

    //when the player collides with a square the name letter is displayed in the text to show it is correct and was walked on
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (correct != true && collide.name != "EndTrigger" && collide.name != "BlockTrig")
        {
            DisplayLetter(collide.name);
            Debug.Log(collide.name);
        }

        if (collide.name == "EndTrigger")
        {
            FindObjectOfType<spellingStory>().StartDialogue2(dialogue);
            stop = false;
            win = true;
            Debug.Log(collide.name);
        }

        if (collide.name == "BlockTrig")
        {
            Colliders.EnableCollider();
        }
    }

    public void Update()
    {
        if (getAnswer == true)
        {
            getAnswer = false;
            GetAnswer();
        }
    }

    //checks if the player spelt word is the correct answer
    void checkQuestion(string word)
    {
        if (word == correctAnswer)
        {
            correct = true;
            GetAnswer();
            Debug.Log("true");
        }
    }

    //gets the correct answer
    public void GetAnswer()
    {
        correctAnswer = RandomLetters.answer;
        Word = "";
        i = 0;
        splitAnswer(correctAnswer);
    }

    //splits the correct answer to check if the collided letter is allowed to be accepted
    public List<char> splitAnswer(string toSplit)
    {
        char[] answerSplit = toSplit.ToCharArray();
        correctAns.Clear();
        correctAns.TrimExcess();
        correctAns.AddRange(answerSplit);
        return correctAns;
    }

    //if the letter collided with is the expected next letter it is added to the constructed word
    public void DisplayLetter(string collideName)
    {
        int v = 0;
        foreach (char c in correctAns)
        {
            if (Word != correctAnswer)
            {
                if (c.ToString() == collideName)
                {
                    if (c.Equals(correctAns[0]))
                    {
                        correctAns.RemoveAt(0);
                        i++;
                        Word = Word + collideName;
                        break;
                    }
                }
                else
                {
                    if (v == 0)
                    {
                        anim.SetTrigger("Dam");
                        v++;
                        HealthUi.currentHealth = HealthUi.currentHealth - 1;
                        updateHealth = true;
                        Debug.Log("wrong letter" + HealthUi.currentHealth);
                    }
                }
            }
        }
        checkQuestion(Word);
        spelling.text = Word;
    }
}