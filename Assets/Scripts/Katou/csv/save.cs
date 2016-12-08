using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class save : MonoBehaviour
{
    int[] rank = new int [5];


	void Start ()
    {
        for(int i = 1; i <= 5; i++)
        {
            rank[i - 1] = i + 1;
        }

        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/CSV/save.csv"); //true=追記 false=上書き
        sw.WriteLine("rank,score");
        for (int i = 1; i <= rank.Length; i++)
        {
            sw.WriteLine(i + "," + rank[i - 1]);
        }
        sw.Flush();
        sw.Close();
    }
	
	void Update ()
    {
	
	}
}
