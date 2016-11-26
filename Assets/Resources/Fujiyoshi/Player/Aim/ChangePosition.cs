using UnityEngine;
using System.Collections;

public class ChangePosition : MonoBehaviour {


    public enum WeaponType
    {
        NONE = -1,
        MINI_GUN,
        ROCKET_LAUNCHER,
        RAIL_GUN
    }
    public int weaponType = 0;
    void Start () {
	    var type = GameObject.Find("WeaponType");
        weaponType = type.GetComponent<WeaponTypeManager>().asset.WeaponNum;
        if (weaponType == (int)WeaponType.MINI_GUN)
        {
            this.transform.localPosition = new Vector3(-1, 0, 0);
        }
        else if (weaponType == (int)WeaponType.ROCKET_LAUNCHER)
        {
            this.transform.localPosition = new Vector3(0, 0, 1.48f);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
