using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathAge : MonoBehaviour
{

    public string finalAnswer, questionText;

    public float num1, num2, answer = 0, temp;
    public int rand, rand2;

    //returns a question string from a list of unanswered questions tailered to the skills of a year 1 student
    public string year1question()
    {

        string[] Operands = { "+", "-", /*"x", "÷" */};
        rand = Random.Range(0, Operands.Length);
        num1 = Random.Range(0, 20);
        num2 = Random.Range(0, 20);

        if (num2 > num1)
        {
            temp = num2;
            num2 = num1;
            num1 = temp;
        }

        //if (rand == 2 || rand == 3)
        //{
        //    num2 = Random.Range(0, 12);
        //}

        //num1 = 1;
        //num2 = 1;

        questionText = num1 + " " + Operands[rand] + " " + num2 + " =  ";
        return questionText;
    }

    //returns a answer string from a list of answers tailered to the skills of a year 1 student
    public string year1answer()
    {
        switch (rand)
        {
            case 0:
                answer = num1 + num2;
                finalAnswer = answer.ToString();
                break;
            case 1:
                answer = num1 - num2;
                finalAnswer = answer.ToString();
                break;
            //case 2:
            //    answer = num1 * num2;
            //    finalAnswer = answer.ToString();
            //    break;
            //case 3:
            //    if (num2 > num1)
            //    {
            //        temp = num2;
            //        num2 = num1;
            //        num1 = temp;
            //    }

            //    answer = num1 / num2;
            //    finalAnswer = answer.ToString();
                //break;
        }
        return finalAnswer;
    }

    //returns a question string from a list of unanswered questions tailered to the skills of a year 2 student
    public string year2question()
    {
        //if you have time add 3 number equations "2+2+3=7"
        string[] Operands = { "+", "-", "x", "÷" };

        rand = Random.Range(0, Operands.Length);
        num1 = Random.Range(0, 100);
        num2 = Random.Range(0, 100);

        if (rand == 2 || rand == 3)
        {
            int[] Mult = { 1, 2, 5, 10 };
            rand2 = Random.Range(0, Mult.Length);
            num1 = Mult[rand2];
            rand2 = Random.Range(0, Mult.Length);
            num2 = Mult[rand2];
        }

        //num1 = 2;
        //num2 = 2;

        questionText = num1 + " " + Operands[rand] + " " + num2 + " =  ?";
        return questionText;
    }

    //returns a answer string from a list of answers tailered to the skills of a year 2 student
    public string year2answer()
    {
        switch (rand)
        {
            case 0:
                answer = num1 + num2;
                finalAnswer = answer.ToString();
                break;
            case 1:
                answer = num1 - num2;
                finalAnswer = answer.ToString();
                break;
            case 2:
                answer = num1 * num2;
                finalAnswer = answer.ToString();
                break;
            case 3:
                //if (num2 > num1)
                //{
                //    temp = num2;
                //    num2 = num1;
                //    num1 = temp;
                //}

                answer = num1 / num2;
                finalAnswer = answer.ToString();
                break;
        }
        return finalAnswer;
    }

    //returns a question string from a list of unanswered questions tailered to the skills of a year 3 student
    public string year3question()
    {
        string[] Operands = { "+", "-", "x", "÷" };
        rand = Random.Range(0, Operands.Length);
        num1 = Random.Range(0, 100);
        num2 = Random.Range(0, 100);


        if (rand == 2 || rand == 3)
        {
            int[] Mult = { 1, 2, 3, 4, 5, 8, 10 };
            rand2 = Random.Range(0, Mult.Length);
            num1 = Mult[rand2];
            rand2 = Random.Range(0, Mult.Length);
            num2 = Mult[rand2];
        }

        questionText = num1 + " " + Operands[rand] + " " + num2 + " =  ?";
        return questionText;
    }

    //returns a answer string from a list of answers tailered to the skills of a year 3 student
    public string year3answer()
    {
        switch (rand)
        {
            case 0:
                answer = num1 + num2;
                finalAnswer = answer.ToString();
                break;
            case 1:
                answer = num1 - num2;
                finalAnswer = answer.ToString();
                break;
            case 2:
                answer = num1 * num2;
                finalAnswer = answer.ToString();
                break;
            case 3:
                //if (num2 > num1)
                //{
                //    temp = num2;
                //    num2 = num1;
                //    num1 = temp;
                //}

                answer = num1 / num2;
                finalAnswer = answer.ToString();
                break;
        }
        return finalAnswer;
    }

    //returns a question string from a list of unanswered questions tailered to the skills of a year 4 student
    public string year4question()
    {
        string[] Operands = { "+", "-", "x", "÷" };
        rand = Random.Range(0, Operands.Length);
        num1 = Random.Range(0, 1000);
        num2 = Random.Range(0, 1000);


        if (rand == 2)
        {
            num1 = Random.Range(0,999);
            num2 = Random.Range(0, 12);
        }
        if (rand == 3)
        {
            num1 = Random.Range(0, 99);
            num2 = Random.Range(0,12);
        }

        //num1 = 4;
        //num2 = 4;

        questionText = num1 + " " + Operands[rand] + " " + num2 + " =  ?";
        return questionText;
    }

    //returns a answer string from a list of answers tailered to the skills of a year 4 student
    public string year4answer()
    {
        switch (rand)
        {
            case 0:
                answer = num1 + num2;
                finalAnswer = answer.ToString();
                break;
            case 1:
                answer = num1 - num2;
                finalAnswer = answer.ToString();
                break;
            case 2:
                answer = num1 * num2;
                finalAnswer = answer.ToString();
                break;
            case 3:
                //if (num2 > num1)
                //{
                //    temp = num2;
                //    num2 = num1;
                //    num1 = temp;
                //}

                answer = num1 / num2;
                finalAnswer = answer.ToString();
                break;
        }
        return finalAnswer;
    }

    //returns a question string from a list of unanswered questions tailered to the skills of a year 5 student
    public string year5question()
    {
        string[] Operands = { "+", "-", "x", "÷" };
        rand = Random.Range(0, Operands.Length);
        num1 = Random.Range(0, 99999);
        num2 = Random.Range(0, 99999);


        if (rand == 2)
        {
            num1 = Random.Range(0, 9999);
            num2 = Random.Range(0, 12);
        }
        if (rand == 3)
        {
            num1 = Random.Range(0, 9999);
            num2 = Random.Range(0, 9);
        }

        //num1 = 5;
        //num2 = 5;

        questionText = num1 + " " + Operands[rand] + " " + num2 + " =  ?";
        return questionText;
    }


    //returns a answer string from a list of answers tailered to the skills of a year 5 student
    public string year5answer()
    {
        switch (rand)
        {
            case 0:
                answer = num1 + num2;
                finalAnswer = answer.ToString();
                break;
            case 1:
                answer = num1 - num2;
                finalAnswer = answer.ToString();
                break;
            case 2:
                answer = num1 * num2;
                finalAnswer = answer.ToString();
                break;
            case 3:
                //if (num2 > num1)
                //{
                //    temp = num2;
                //    num2 = num1;
                //    num1 = temp;
                //}

                answer = num1 / num2;
                finalAnswer = answer.ToString();
                break;
        }
        return finalAnswer;
    }

    //returns a question string from a list of unanswered questions tailered to the skills of a year 6 student
    public string year6question()
    {
        string[] Operands = { "+", "-", "x", "÷" };
        rand = Random.Range(0, Operands.Length);
        num1 = Random.Range(0, 100);
        num2 = Random.Range(0, 100);


        if (rand == 2 || rand == 3)
        {
            num1 = Random.Range(0, 9999);
            num2 = Random.Range(0, 12);
        }

        //num1 = 6;
        //num2 = 6;

        questionText = num1 + " " + Operands[rand] + " " + num2 + " =  ?";
        return questionText;
    }


    //returns a answer string from a list of answers tailered to the skills of a year 6 student
    public string year6answer()
    {
        switch (rand)
        {
            case 0:
                answer = num1 + num2;
                finalAnswer = answer.ToString();
                break;
            case 1:
                answer = num1 - num2;
                finalAnswer = answer.ToString();
                break;
            case 2:
                answer = num1 * num2;
                finalAnswer = answer.ToString();
                break;
            case 3:
                //if (num2 > num1)
                //{
                //    temp = num2;
                //    num2 = num1;
                //    num1 = temp;
                //}

                answer = num1 / num2;
                finalAnswer = answer.ToString();
                break;
        }
        return finalAnswer;
    }
}