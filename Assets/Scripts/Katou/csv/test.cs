using UnityEngine;

public class test : MonoBehaviour
{
    EnemyMasterTable enemyMasterTable = new EnemyMasterTable();
	void Start ()
    {
        enemyMasterTable.Load();
        foreach(var enemyMaster in enemyMasterTable.All)
        {
            Debug.Log(enemyMaster.rank);
            Debug.Log(enemyMaster.score);
        }
	}
	
	void Update ()
    {
	
	}
}
