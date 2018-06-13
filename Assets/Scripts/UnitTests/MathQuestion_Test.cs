using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MathQuestion_Test {

	[Test]
	public void Year_1() {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testQuestion = Math_Age.year1question();

        Assert.AreNotEqual(null, testQuestion);
	}

    [Test]
    public void Year_2()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testQuestion = Math_Age.year2question();

        Assert.AreNotEqual(null, testQuestion);
    }

    [Test]
    public void Year_3()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testQuestion = Math_Age.year3question();

        Assert.AreNotEqual(null, testQuestion);
    }

    [Test]
    public void Year_4()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testQuestion = Math_Age.year4question();

        Assert.AreNotEqual(null, testQuestion);
    }

    [Test]
    public void Year_5()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testQuestion = Math_Age.year5question();

        Assert.AreNotEqual(null, testQuestion);
    }

    [Test]
    public void Year_6()
    {

        var Math_Age = new GameObject().AddComponent<MathAge>();

        string testQuestion = Math_Age.year6question();

        Assert.AreNotEqual(null, testQuestion);
    }
}
