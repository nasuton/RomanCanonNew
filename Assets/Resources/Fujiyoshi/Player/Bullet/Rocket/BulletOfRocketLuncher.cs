using UnityEngine;
using System.Collections;

public class BulletOfRocketLuncher : MonoBehaviour
{
    [SerializeField]
    GameObject effect;
    [SerializeField]
    GameObject sphereCollider;
    void Awake()
    {
        this.GetComponent<BulletDamege>().Damege = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[0];
    }
    void OnTriggerEnter(Collider other)
    {
        GameObject.Instantiate(effect);
        GameObject.Instantiate(sphereCollider);
        effect.transform.localPosition = other.transform.localPosition;
        sphereCollider.transform.localPosition = other.transform.localPosition;
        Destroy(this);
    }
}
