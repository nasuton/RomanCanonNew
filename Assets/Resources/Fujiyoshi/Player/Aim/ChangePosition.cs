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
    private Vector2 my_scatter;
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
            this.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
	public void Scatter()
    {
        //float x = (float)(Random.value-0.5f) * 10;
        //float y = (float)(Random.value - 0.5f) * 10;
        //this.transform. += new Vector3(x,0,y);
    }
    public void Reset()
    {
        if (weaponType == (int)WeaponType.MINI_GUN)
        {
            this.transform.localPosition = new Vector3(-1, 0, 0);
        }
        else if (weaponType == (int)WeaponType.ROCKET_LAUNCHER)
        {
            this.transform.localPosition = new Vector3(0, 0,3);
        }
    }
    
}
