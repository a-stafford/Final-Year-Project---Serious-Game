using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathQuestions : MonoBehaviour
{
    public Text question, points;
    public GameObject prefab1, prefab2, prefab3, prefab4, ExplosionAnimation;

    public GameObject[] Enemies, ene;
    public  List<string> incorrectAns;
    public Transform[] spawnPoints;
    public string finalAnswer, finalQuestion, selectedYear;
    public int WrongAnswer1, WrongAnswer2, WrongAnswer3, WrongAnswer4, CorrectAnswer, maxNumber;
    public int[] rands;
    public static string correctAnswerShip, finalAns, addQuestion;
    public static int answerPoints = 15;
    public AudioClip explosionSound;
    public static bool Correct, incorrect, reload, reload2;
    public MathAge yearOne;

    void Start()
    {
        rands = new int[4];
        selectedYear = DropdownManager.year;

        if (selectedYear == null)
        {
            selectedYear = "Year One";

        }

        getMathQuestions();
        reloadEnemies();
    }

    void Update()
    {

        if(Story.canWrite == true)
        {
            FileWrite.Write(incorrectAns);
            Story.canWrite = false;
        }


        addQuestion = finalQuestion;

        finalAns = finalAnswer;
        if (reload2)
        {
            reload2 = false;
            getMathQuestions();
            destroyEnemies();
            reloadEnemies();
        }

        //if correct is true get the next question and answer, add 1 to the score and destroy enemies and reload them for the next round
        if (Correct)
        {
            Debug.Log(answerPoints);
            Correct = false;
            getMathQuestions();
            answerPoints++;
            destroyEnemies();
            if (Story.CanReload == true)
            {
                if (answerPoints != 20)
                {
                    reloadEnemies();
                }
            }
            Debug.Log("Correct");
        }

        //if incorrect is true target the player and shoot them, take 1 away from the score, get next question adn answer and destroy and relaod enemies
        if (incorrect)
        {
            incorrect = false;
            Debug.Log(answerPoints);

            targetPlayer(correctAnswerShip);


            if (reload == true)
            {
                incorrectAns.Add(finalQuestion);
                if (answerPoints != 0)
                {
                    answerPoints--;
                }
                getMathQuestions();
                reload = false;
                destroyEnemies();

                if (Story.CanReload == true || answerPoints == 8)
                {
                    if (answerPoints != 20)
                    {
                        reloadEnemies();
                    }
                }

                Debug.Log("incorrect");
            }
        }
        points.text = answerPoints.ToString();
    }

    //get the question and answer depending on the selected year and set the max number for the other ships incorrect asnwers
    void getMathQuestions()
    {
        switch (selectedYear)
        {
            case "Year One":
                maxNumber = 20;

                finalQuestion = yearOne.year1question();
                finalAnswer = yearOne.year1answer();

                question.text = finalQuestion + "?";
                finalQuestion = finalQuestion + finalAnswer;

                answerChoice();
                break;

            case "Year Two":
                maxNumber = 40;

                finalQuestion = yearOne.year1question();
                finalAnswer = yearOne.year1answer();

                question.text = finalQuestion + "?";
                finalQuestion = finalQuestion + finalAnswer;

                answerChoice();
                break;

            case "Year Three":
                maxNumber = 60;

                finalQuestion = yearOne.year3question();
                finalAnswer = yearOne.year3answer();

                question.text = finalQuestion + "?";
                finalQuestion = finalQuestion + finalAnswer;

                answerChoice();
                break;

            case "Year Four":
                maxNumber = 80;

                finalQuestion = yearOne.year4question();
                finalAnswer = yearOne.year4answer();

                question.text = finalQuestion + "?";
                finalQuestion = finalQuestion + finalAnswer;

                answerChoice();
                break;

            case "Year Five":
                maxNumber = 100;

                finalQuestion = yearOne.year5question();
                finalAnswer = yearOne.year5answer();

                question.text = finalQuestion + "?";
                finalQuestion = finalQuestion + finalAnswer;

                answerChoice();
                break;

            case "Year Six":
                maxNumber = 120;

                finalQuestion = yearOne.year6question();
                finalAnswer = yearOne.year6answer();

                question.text = finalQuestion + "?";
                finalQuestion = finalQuestion + finalAnswer;

                answerChoice();
                break;
        }
    }

    //set which ship contains the correct answer
    void answerChoice()
    {
        int correctAns = Random.Range(0, 3), y = 0;

        for (int i = 0; i < 3; i++)
        {
            rands[i] = Random.Range(0, maxNumber);
        }

        foreach (GameObject enemy in ene)
        {
            enemy.GetComponentInChildren<Text>().text = rands[y].ToString();
            enemy.name = rands[y].ToString();
            y++;
        }

        ene[correctAns].GetComponentInChildren<Text>().text = finalAnswer.ToString();
        ene[correctAns].name = finalAnswer.ToString();
        correctAnswerShip = ene[correctAns].tag;
    }

    //destorys all enmies when called
    public void destroyEnemies()
    {

        if (GameObject.FindWithTag("Enemy1") != null)
        {
            Explosion(GameObject.FindWithTag("Enemy1").transform.position);
            Destroy(GameObject.FindWithTag("Enemy1"));
        }

        if (GameObject.FindWithTag("Enemy2") != null)
        {
            Explosion(GameObject.FindWithTag("Enemy2").transform.position);
            Destroy(GameObject.FindWithTag("Enemy2"));
        }

        if (GameObject.FindWithTag("Enemy3") != null)
        {
            Explosion(GameObject.FindWithTag("Enemy3").transform.position);
            Destroy(GameObject.FindWithTag("Enemy3"));
        }

        if (GameObject.FindWithTag("Enemy4") != null)
        {
            Explosion(GameObject.FindWithTag("Enemy4").transform.position);
            Destroy(GameObject.FindWithTag("Enemy4"));
        }
    }

    //reloads enemies after they have been destroyed
    void reloadEnemies()
    {
        Debug.Log(reload);

        for (int y = 0; y < Enemies.Length; y++)
        {
            Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(Enemies[y], sp.position, sp.rotation);
        }

    }

    //triggers explosion aniamtion
    void Explosion(Vector3 location)
    {
        SoundEffects.Instance.MakeExplosionSound();
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimation);
        explosion.transform.position = location;
    }

    //when called makes the ship with the correct answer shoot the player
    public static void targetPlayer(string ship)
    {
        GameObject gameObject1, gameObject2, gameObject3, gameObject4;

        gameObject1 = GameObject.FindWithTag("Enemy1");
        gameObject2 = GameObject.FindWithTag("Enemy2");
        gameObject3 = GameObject.FindWithTag("Enemy3");
        gameObject4 = GameObject.FindWithTag("Enemy4");

        switch (ship)
        {
            case "Enemy1":
                gameObject1.GetComponent<FacingPlayer>().look = true;
                break;
            case "Enemy2":
                gameObject2.GetComponent<FacingPlayer>().look = true;
                break;
            case "Enemy3":
                gameObject3.GetComponent<FacingPlayer>().look = true;
                break;
            case "Enemy4":
                gameObject4.GetComponent<FacingPlayer>().look = true;
                break;
        }
    }
}