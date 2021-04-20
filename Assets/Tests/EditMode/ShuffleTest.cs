using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using RandomUtilities;

public class ShuffleTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ShuffleTestSimplePasses()
    {
        int[] array = { 0, 1, 2, 3 };
        int[] newOrder = { 1, 3, 0, 2 };
        int[][] newOrderCases = new int[8][];
        newOrderCases[0] = new int[] { 1, 3, 0, 2 };
        newOrderCases[1] = new int[] { 0, 1, 2, 3 };
        newOrderCases[2] = new int[] { 0, 2, 1, 3 };
        newOrderCases[3] = new int[] { 3, 2, 1, 0 };
        newOrderCases[4] = new int[] { 0, 3, 1, 2 };
        newOrderCases[5] = new int[] { 0, 3, 2, 1 };
        newOrderCases[6] = new int[] { 1, 0, 2, 3 };
        newOrderCases[7] = new int[] { 2, 3, 1, 0 };
        for (int i = 0; i < newOrderCases.GetLength(0); i++) {
            array = new int[]{ 0, 1, 2, 3 };
            Rand.ArrangeArray(array, newOrderCases[i]);
            Assert.AreEqual(newOrderCases[i][0], array[0]);
            Assert.AreEqual(newOrderCases[i][1], array[1]);
            Assert.AreEqual(newOrderCases[i][2], array[2]);
            Assert.AreEqual(newOrderCases[i][3], array[3]);
        }
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ShuffleTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
