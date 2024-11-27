using System;
using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// A class storing some useful Finch functions!
/// Usually to shorten some stuff
/// </summary>
public class Finch
{
    public static bool slowPrintFin = false;
    /// <summary>
    /// Returns Time.time + addition
    /// </summary>
    /// <param name="addition">The amount of time to add to Time.time</param>
    /// <returns>A float which can be used for a timer</returns>
    public static float TimeAdd(float addition)
    {
        return Time.time + addition;
    }
    /// <summary>
    /// A corutine that prints a message to a TMP_text slowly, and can also wait 3 seconds after printing
    /// Once finished, will set the public bool slowPrintFin to true
    /// </summary>
    /// <param name="text">The TMP_Text object being written to</param>
    /// <param name="timeWait">The amount of time between message writing</param>
    /// <param name="inputString">The string to write to the TMP_Text object</param>
    /// <param name="waitAfter">Whether to wait after or not</param>
    public static IEnumerator SlowWrite(TMP_Text text, float timeWait, string inputString, bool waitAfter)
    {
        slowPrintFin = false;
        char[] chars = inputString.ToCharArray();
        string outputSofar = "";
        foreach (char c in chars)
        {
            outputSofar += c;
            text.SetText(outputSofar);
            if (c == ' ')
            {
                yield return null;
            }
            else
            {
            yield return new WaitForSeconds(timeWait);
            }
        }
        if (waitAfter)
        {
            for (int i = 0; i <= 2; i++)
            {
                yield return new WaitForSeconds(1);
            }
        }
        Debug.Log("FINISHED");
        slowPrintFin = true;
    }

    /// <summary>
    /// Returns the first Active object in a object pool
    /// </summary>
    /// <param name="gameObjArray">The object pool as an array</param>
    /// <returns>First active object in an object pool, if none, null</returns>
    public static GameObject PoolGetInactive(GameObject[] gameObjArray)
    {
        foreach (GameObject obj in gameObjArray)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    /// <summary>
    /// Creates a pool of objects with a specified size
    /// </summary>
    /// <param name="poolSize">Integer that is the number of objects in the pool</param>
    /// <param name="obj">The object being pooled</param>
    /// <returns>An object pool</returns>
    public static GameObject[] CreatePool(int poolSize, GameObject obj)
    {
        GameObject[] pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = GameObject.Instantiate(obj);
            pool[i].SetActive(false);
        }
        return pool;
    }



    
}
