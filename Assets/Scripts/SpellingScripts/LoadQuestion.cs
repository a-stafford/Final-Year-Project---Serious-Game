using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadQuestion : MonoBehaviour
{
    public int questionNumber, i;
    public Question currentQuestion;
    public string currentAnswer;
    public static string answer;
    public Text questionText, answerText;
    public static string[] Questions, Answer;
    public GameObject[] islands, gridSpawn, islandsToSpawn;
    public Transform[] gridLoc, islandSpawnPoints, tilePrefabs;
    public int[] strSize;
    public static bool trigger = false;

    public Vector2 mapSize;
    public static int size;

    [Range(0, 1)]
    public float outlinePercent;

    private void Start()
    {
        Questions = new string[10];
        Answer = new string[10];
        strSize = new int[10];
        islandsToSpawn = new GameObject[10];
        gridSpawn = new GameObject[10];
        gridLoc = new Transform[10];

        for (int i = 0; i < 10; i++)
        {
            questionNumber = Random.Range(0, ReadFromCsv.UnansweredQuestions.Count);
            currentQuestion = ReadFromCsv.UnansweredQuestions[questionNumber];

            Questions[i] = currentQuestion.question;
            Answer[i] = currentQuestion.qAnswer;
            strSize[i] = currentQuestion.qAnswer.Length;
            ReadFromCsv.UnansweredQuestions.RemoveAt(questionNumber);
        }
        Debug.Log(Questions.Length + Answer.Length);
        getIslands();
    }

    //displays the riddle to the text for the player to answer
    public void GetQuestion(int i)
    {
        questionText.text = Questions[i];
        //answerText.text = Answer[i];
    }

    //chooses which grid top spawn depending on the size of the answer
    public void getIslands()
    {
        for (int i = 0; i < strSize.Length; i++)
        {
            switch (strSize[i])
            {
                case 3:
                    islandsToSpawn[i] = islands[0];
                    break;
                case 4:
                    islandsToSpawn[i] = islands[1];
                    break;
                case 5:
                    islandsToSpawn[i] = islands[2];
                    break;
                case 6:
                    islandsToSpawn[i] = islands[3];
                    break;
                case 7:
                    islandsToSpawn[i] = islands[4];
                    break;
                case 8:
                    islandsToSpawn[i] = islands[5];
                    break;
            }
        }
        chooseIsland();
    }

    //spawns the correct island
    public void chooseIsland()
    {
        int v = 0;
        foreach (GameObject island in islandsToSpawn)
        {
            Instantiate(island, new Vector3(islandSpawnPoints[v].position.x, islandSpawnPoints[v].position.y, 0), islandSpawnPoints[v].rotation);
            v++;
        }
        findIslands();
    }

    //finds the location of the grid spawn in each island
    public void findIslands()
    {
        int i = 0;
        gridSpawn = GameObject.FindGameObjectsWithTag("Gridspawn");
        foreach (GameObject loc in gridSpawn)
        {
            gridLoc[i] = loc.transform;
            i++;
        }

        gridGenerator();
    }

    //generates the grid using the grid spawn trasnform from each island
    public void gridGenerator()
    {
        i = 0;
        foreach (Transform trans in gridLoc)
        {
            mapSize.x = strSize[i] + 1;
            mapSize.y = strSize[i] + 1;

            string holderName = "Grid";

            Transform gridHolder = new GameObject(holderName).transform;
            gridHolder.parent = trans;

            float posX = trans.transform.position.x;
            float posY = trans.transform.position.y;

            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    Vector3 tilePosition = new Vector3(x + posX, y + posY, trans.position.z);

                    Transform newTile = Instantiate(tilePrefabs[i], tilePosition, Quaternion.Euler(Vector3.right)) as Transform;
                    newTile.localScale = Vector3.one * (1 - outlinePercent);
                    newTile.SetParent(gridHolder, false);
                }
            }
            i++;
        }
        trigger = true;
    }
}
