using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MathAnswer_Test {

    [Test]
    public void Year_1()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testAnswer = Math_Age.year1answer();

        Assert.AreNotEqual(null, testAnswer);
    }

    [Test]
    public void Year_2()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testAnswer = Math_Age.year2answer();

        Assert.AreNotEqual(null, testAnswer);
    }

    [Test]
    public void Year_3()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testAnswer = Math_Age.year3answer();

        Assert.AreNotEqual(null, testAnswer);
    }

    [Test]
    public void Year_4()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testAnswer = Math_Age.year4answer();

        Assert.AreNotEqual(null, testAnswer);
    }

    [Test]
    public void Year_5()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testAnswer = Math_Age.year5answer();

        Assert.AreNotEqual(null, testAnswer);
    }

    [Test]
    public void Year_6()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testAnswer = Math_Age.year6answer();

        Assert.AreNotEqual(null, testAnswer);
    }
}
