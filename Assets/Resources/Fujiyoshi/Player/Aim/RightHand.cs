using UnityEngine;
using System.Collections;

public class RightHand : MonoBehaviour {
    private int weaponType = 0;
    void Awake()
    {
        var type = GameObject.Find("WeaponType");
        weaponType = type.GetComponent<WeaponTypeManager>().asset.WeaponNum;
        if (weaponType == (int)GunManager.WeaponType.MINI_GUN)
        {
            this.transform.localPosition = new Vector3(-0.158f, -0.47f, -1.347f);
        }
        if (weaponType == (int)GunManager.WeaponType.ROCKET_LAUNCHER)
        {
            this.transform.localPosition = new Vector3(-0.103f, -0.033f, -0.937f);
        }
        if (weaponType == (int)GunManager.WeaponType.RAIL_GUN)
        {
            this.transform.localPosition = new Vector3(-0.158f, -0.37f, -1.347f);
        }
    }
	
	
}
