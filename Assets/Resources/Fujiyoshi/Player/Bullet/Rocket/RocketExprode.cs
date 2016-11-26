using UnityEngine;
using System.Collections;

public class RocketExprode : MonoBehaviour {

    void Awake()
    {
        this.GetComponent<BulletDamege>().Damege = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[0];
        this.transform.localScale = (new Vector3(1, 1, 1)) * GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[3];
    }
}
