using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFromCsv : MonoBehaviour
{
    public string[][] final;
    public string[] Load;
    public string selectedYear;
    public TextAsset[] csv;
    public TextAsset FinalCsv;
    public static List<string> Questions = new List<string>(), Answers = new List<string>();
    public static List<Question> UnansweredQuestions = new List<Question>();

    void Start()
    {
        selectedYear = DropdownManager.year;
        Debug.Log(selectedYear);

        if (selectedYear == null)
        {
            selectedYear = "Year One";
  
        }

        switch (selectedYear)
        {
            case "Year One":
                FinalCsv = csv[0];
                break;

            case "Year Two":
                FinalCsv = csv[1];
                break;

            case "Year Three":
                FinalCsv = csv[2];
                break;

            case "Year Four":
                FinalCsv = csv[2];
                break;

            case "Year Five":
                FinalCsv = csv[3];
                break;

            case "Year Six":
                FinalCsv = csv[3];
                break;
        }

        fillQuestions(FinalCsv);
    }

    //reads from a specified .csv file then splits question and answer into two seperate arrays then adds these to an list of Questions
    public void fillQuestions(TextAsset File)
    {
        final = new string[1][];
        Load = (File.text.Split('.'));
        final = new string[Load.Length][];

        for (int i = 0; i < Load.Length; i++)
        {
            final[i] = Load[i].Split(',');

            Questions.Add(final[i][0].Trim());
            Answers.Add(final[i][1].Trim());

            UnansweredQuestions.Add(new Question(Questions[i], Answers[i]));
        }
    }
}