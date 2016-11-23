using UnityEngine;
using System.Collections;

public class BulletOfMiniGun : MonoBehaviour
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
        if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == true &&
              GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().roman_type.brust == WeaponStatusManager.RomanType.BurstType.rocket)
        {
            GameObject.Instantiate(effect);
            GameObject.Instantiate(sphereCollider);
            effect.transform.localPosition = other.transform.localPosition;
            sphereCollider.transform.localPosition = other.transform.localPosition;
        }
    }
}
