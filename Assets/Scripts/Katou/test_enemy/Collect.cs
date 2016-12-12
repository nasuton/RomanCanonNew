using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour
{
    public Vector3 traget;

    [SerializeField]
    private float collect_damage;

    public float destroyTime = 5.0f;

    [SerializeField, Tooltip("発動中のエフェクト")]
    private GameObject gravity_effect;

    public float Collect_Damage
    {
        get{ return collect_damage; }
        set { collect_damage = value; }
    }

	void Start ()
    {
        collect_damage = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().status[0];

        traget = transform.position;

        Instantiate(gravity_effect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));

        StartCoroutine("collect_destroy", destroyTime);
	}

    IEnumerator collect_destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
