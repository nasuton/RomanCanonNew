using UnityEngine;
using System.Collections;

public class RotateWeapon : MonoBehaviour {

    
	
	// Update is called once per frame
	void Update () {
        this.transform.localEulerAngles += new Vector3(0,360 * (Time.deltaTime / 4),0);
	}
}
