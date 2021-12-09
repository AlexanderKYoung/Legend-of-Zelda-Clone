using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMoveTests
{
    [UnityTest]
    public IEnumerator MoveNorth()
    {
        //var gameObject = new GameObject();
        //var player = gameObject.AddComponent<Player>();
        //player.MoveCharacter();

        yield return null;

        int i = 0;
        Assert.AreEqual(i, 0);
    }

    [UnityTest]
    public IEnumerator SwingSword()
    {
        yield return null;
        int j = Random.RandomRange(0, 1);

        bool isTrue = (j < 0.5f);
        Assert.AreEqual(isTrue, true);
    }

    [UnityTest]
    public IEnumerator CameraMovedWest()
    {
        yield return null;
        int x = 5;
        Assert.AreEqual(x, 5);
    }
}
