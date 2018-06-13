using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileWrite : MonoBehaviour
{
    public string filePath;


    void Start()
    {
        WriteHeader();
    }

    void Update()
    {
    }

    //when called creates a file in the specified directory location and writes the specified text
    void WriteHeader()
    {
        filePath = Application.dataPath + "/Student Incorrect Answers.txt";

        StreamWriter sw;
        if (!File.Exists(filePath))
        {
            sw = File.CreateText(Application.dataPath + "/Student Incorrect Answers.txt");
        }
        else
        {
            sw = new StreamWriter(filePath);
        }
        sw.WriteLine("Detailed below are the math question the student answered incorrectly");
        sw.WriteLine("");

        sw.Close();
    }

    //when called it itterates through a list of incorrect asnwers to a file for a teacher/moderator to view 
    public static void Write(List<string> WriteLine)
    {
        string filePath = Application.dataPath + "/Student Incorrect Answers.txt";
        StreamWriter sw;

        if (!File.Exists(filePath))
        {
            sw = File.CreateText(Application.dataPath + "/Student Incorrect Answers.txt");
        }
        else
        {
            sw = new StreamWriter(filePath, append: true);
        }

        foreach (string write in WriteLine)
        {
            sw.WriteLine(write);
        }
        sw.Close();
    }
}
