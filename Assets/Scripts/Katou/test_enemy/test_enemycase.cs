using UnityEngine;
using System.Collections;

public class test_enemycase : MonoBehaviour
{
    float speed = 1.5f;

    test_enemystate test_state;
	
	void Start ()
    {
        test_state = GetComponent<test_enemystate>();
	}
	
	
	void Update ()
    {
        //if (test_state.get_together) return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
