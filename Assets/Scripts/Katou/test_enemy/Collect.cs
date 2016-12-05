using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour
{
    public Vector3 traget;

    [SerializeField]
    private int collect_damage = 5;

    public float destroyTime = 5.0f;

    public int Collect_Damage
    {
        get{ return collect_damage; }
        set { collect_damage = value; }
    }

	void Start ()
    {
        traget = transform.position;
        StartCoroutine("collect_destroy", destroyTime);
	}

    IEnumerator collect_destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
