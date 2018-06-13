using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropdownManager : MonoBehaviour
{
    public Dropdown drop;
    public static bool year1 = false, year2 = false, year3 = false, year4 = false, year5 = false, year6 = false;
    public int index;
    public static string year;
    public List<string> Years = new List<string>() { "Please Pick One", "Year One", "Year Two", "Year Three", "Year Four", "Year Five", "Year Six" };

    void Start()
    {
        drop.ClearOptions();
        drop.AddOptions(Years);
    }

    void Update()
    {
        index = drop.value;

        setList();
    }


    public void setList()
    {

        switch (Years[index])
        {
            case "Year One":
                year = Years[index];
                break;

            case "Year Two":
                year = Years[index];
                break;

            case "Year Three":
                year = Years[index];
                break;

            case "Year Four":
                year = Years[index];
                break;

            case "Year Five":
                year = Years[index];
                break;

            case "Year Six":
                year = Years[index];
                break;
        }
    }
}
