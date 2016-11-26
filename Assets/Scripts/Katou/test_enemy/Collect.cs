using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

    public Vector3 traget;

    [SerializeField]
    public float destroyTime = 5.0f;

    public bool destroy;

	void Start ()
    {
        traget = transform.position;
        StartCoroutine("collect_destroy", destroyTime);
	}
	
	
	void Update ()
    {
        
	}

    IEnumerator collect_destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
