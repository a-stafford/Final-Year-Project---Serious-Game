using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EnglishCsv_Test {

	[Test]
	public void CsvRead_Test() {

        var RandLetters = new GameObject().AddComponent<RandomLetters>();

        RandLetters.fillTextArray();

        if (RandLetters.Letters.Length > 0)
        {
            Assert.Pass();
        }
    }

}
