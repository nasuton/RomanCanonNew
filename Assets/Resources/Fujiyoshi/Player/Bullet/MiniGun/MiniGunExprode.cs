using UnityEngine;
using System.Collections;

public class MiniGunExprode : MonoBehaviour {

    void Awake()
    {
        this.GetComponent<BulletDamege>().Damege = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[0] * 3;
    }
    
}
