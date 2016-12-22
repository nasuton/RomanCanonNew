using UnityEngine;
using System.Collections;

public class effecty_destory : MonoBehaviour {

    [SerializeField]
    private float destory_time;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, destory_time);
	}
	

}
