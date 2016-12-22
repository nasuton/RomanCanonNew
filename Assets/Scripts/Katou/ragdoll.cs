using UnityEngine;
using System.Collections;

public class ragdoll : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;

    [SerializeField]
    private float Generation_Time;

    private Vector3 add = new Vector3(0.0f, 1.0f, 0.0f);

	void Start ()
    {
        StartCoroutine("Effect_Generation", Generation_Time);
	}

    IEnumerator Effect_Generation(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(effect, transform.position + add, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        Destroy(gameObject);
    }
}
