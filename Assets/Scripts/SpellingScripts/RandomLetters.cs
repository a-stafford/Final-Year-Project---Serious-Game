using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLetters : MonoBehaviour
{
    public char[] letterChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'G', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', };
    public GameObject[][] Letters;
    public GameObject[] Bridges;
    public string[] tags;
    public int i = 0, ranX, ranY, gridSizeLess, c;
    public LoadQuestion Load;
    public static string answer;
    public static bool correct;
    public bool test = false;
    public int corrAns = 0, questionLevel, bridgeCount = 0;
    public Renderer rend;

    void Awake()
    {
        Letters = new GameObject[10][];
    }

    void Update()
    {
        correct = playerCollision.correct;


        //when triggered fills an array of bridges and an array of all letter grid pieces
        if (LoadQuestion.trigger)
        {
            Colliders.trig = true;
            LoadQuestion.trigger = false;
            fillTextArray();
            Bridges = GameObject.FindGameObjectsWithTag("Bridge");
        }

        //when the player asnwers correctly the bridge appears, the board turns blank and the next question is loaded
        if (playerCollision.correct == true /*|| Input.GetKeyDown("space")*/)
        {
            playerCollision.correct = false;
            rend = Bridges[bridgeCount].GetComponent<Renderer>();
            Colliders.RemoveCollider(bridgeCount);
            rend.enabled = true;
            StopColliders();

            bridgeCount++;
            corrAns++;
            questionLevel++;

            Load.GetQuestion(questionLevel);
            answerLocation();
        }
    }

    //fills an array with all text fileds with the tags for eich board piece, this is needed to change the text in each square of the grid
    public void fillTextArray()
    {
        for (int i = 0; i < tags.Length; i++)
        {
            Letters[i] = GameObject.FindGameObjectsWithTag(tags[i]);
        }
        FillGrid();
    }

    //fills the grids with random letters
    void FillGrid()
    {
        Load.GetQuestion(questionLevel);
        for (int x = 0; x < Letters.Length; x++)
        {
            for (int y = 0; y < Letters[x].Length; y++)
            {
                int ran = Random.Range(0, letterChars.Length);
                Letters[x][y].GetComponent<Text>().text = letterChars[ran].ToString();
                Letters[x][y].name = letterChars[ran].ToString();
                Letters[x][y].GetComponent<Text>().color = Color.white;
            }
        }
        answerLocation();
    }

    //returns a int for a given coordinate
    int ColRowToArrayIndex(int x, int y)
    {
        int size = answer.Length + 1;
        return y + size * x;
    }

    //sets the location of the answer 
    public void answerLocation()
    {

        answer = LoadQuestion.Answer[questionLevel];

        gridSizeLess = answer.Length;

        //splits the asnwer into a char array
        char[] answerSplit = LoadQuestion.Answer[questionLevel].ToCharArray();
        Debug.Log(questionLevel);


        playerCollision.getAnswer = true;

        ranX = Random.Range(0, gridSizeLess);
        ranY = Random.Range(0, gridSizeLess);
        bool diag = false;

        //assigns the first letter location, assuring this is on the outside allwoing the player a path through the grid
        if (ranX == 1 || ranX == 2 || ranX == 3 || ranX == 4 || ranX == 5 || ranX == 6 || ranX == 7 || ranX == 8)
        {
            if (Random.value < .5f)
            {
                ranY = 0;
            }
            else
            {
                ranY = gridSizeLess;
            }
        }

        //each answer is placed on the grid in a manner which allows the player to acces it from the previous letter
        for (int x = 0; x < answerSplit.Length; x++)
        {

            Letters[questionLevel][ColRowToArrayIndex(ranX, ranY)].GetComponent<Text>().text = answerSplit[x].ToString();
            Letters[questionLevel][ColRowToArrayIndex(ranX, ranY)].name = answerSplit[x].ToString();
            //Letters[questionLevel][ColRowToArrayIndex(ranX, ranY)].GetComponent<Text>().color = Color.red;



            if (diag != true)
            {
                if (Random.value < .5f)
                {
                    if (ranX != gridSizeLess)
                    {
                        ranX++;
                    }
                    else
                    {
                        if (ranY != gridSizeLess)
                        {
                            ranY++;
                        }
                        else
                        {
                            ranY--;
                            ranX--;
                        }
                    }
                }
                else
                {
                    if (ranY != gridSizeLess)
                    {
                        ranY++;
                    }
                    else
                    {
                        if (ranX != gridSizeLess)
                        {
                            ranX++;
                        }
                        else
                        {
                            ranY--;
                            ranX--;
                        }
                    }
                }
            }
            else
            {
                ranY--;
                ranX--;
            }

            if (ranX == gridSizeLess && ranY == gridSizeLess)
            {
                diag = true;
            }
        }

        diag = false;
    }

    //when called stops the colldiers for the grid which was jsut answered to allow the player to exit without losing health
    void StopColliders()
    {
        for (int i = 0; i < Letters[questionLevel].Length; i++)
        {
            //Debug.Log(i + "i");
            Letters[questionLevel][i].GetComponent<Text>().text = "";
            Letters[questionLevel][i].name = "Blank";
            Letters[questionLevel][i].GetComponent<Collider2D>().enabled = false;
        }

    }
}
