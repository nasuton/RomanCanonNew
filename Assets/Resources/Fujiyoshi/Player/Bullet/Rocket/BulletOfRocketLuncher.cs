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
        GameObject.Instantiate(effect, this.transform.position, Quaternion.identity);
        GameObject.Instantiate(sphereCollider, this.transform.position, Quaternion.identity);
        Sound.PlaySe("rokeran h");
        
        Destroy(this);
    }
}
