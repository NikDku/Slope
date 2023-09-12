using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTests
{
    [Test]
    public void TestAddToScore()
    {
        var gameManager = new GameManager();

        Assert.AreEqual(0, gameManager.GetScore());

        gameManager.AddToScore();

        Assert.AreEqual(1, gameManager.GetScore());
    }

    [Test]
    public void TestEndLevel()
    {
        var gameManager = new GameManager();

        Assert.IsFalse(gameManager.HasLevelEnded());


        gameManager.EndLevel();

        Assert.IsTrue(gameManager.HasLevelEnded());
        
    }

  
}
