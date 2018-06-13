using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellingAge : MonoBehaviour
{

    public string selectedYear;
    public static string csv;
    public Text testy;
    public TextAsset year1, year2, year3, year4, year5, year6;

    void Awake()
    {
        selectedYear = DropdownManager.year;

        Debug.Log(selectedYear);
    }

    //sets the correct year .csv file to read from
    void Update()
    {

        switch (selectedYear)
        {
            case "Year One":
               csv = "One";

                break;

            case "Year Two":
                csv = "Two";

                break;

            case "Year Three":
                csv = "Three";
                break;

            case "Year Four":
                csv = "Four";

                break;

            case "Year Five":
                csv = "Five";

                break;

            case "Year Six":
                csv = "Six";

                break;
        }
    }
}
