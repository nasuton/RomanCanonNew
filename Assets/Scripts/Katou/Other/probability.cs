using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class probability
{
	public static T enemy_election<T>(Dictionary <T, int> target)
    {
        float total = 0;
        
        foreach (float per in target.Values)
        {
            total += per;
        }

        float rand = Random.Range(0, total);

        foreach(KeyValuePair<T, int> pair in target)
        {
            rand -= pair.Value;

            if(rand < 0)
            {
                return pair.Key;
            }
        }

        return new List<T>(target.Keys)[0];
    }
}
