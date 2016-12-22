using UnityEngine;

public class effect_destory : MonoBehaviour {

    [SerializeField]
    private float destory_time;
	
	void Start ()
    {
        Destroy(gameObject, destory_time);	
	}
	
}
