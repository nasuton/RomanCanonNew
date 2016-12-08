using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class plam_pos : MonoBehaviour {
    [SerializeField]
    GameObject plam;
    // Use this for initialization
    void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("LMHeadMountedRig").GetComponent<OtherController>().OtherEnter == true)
        {
            this.transform.position = plam.transform.position;
        }
        else
        {
            if (Input.GetKey("w"))
            {
                this.transform.localPosition += new Vector3(0, 0, 0.01f);
            }


            if (Input.GetKey("s"))
            {
                this.transform.localPosition += new Vector3(0, 0, -0.01f);
            }


            if (Input.GetKey("a"))
            {
                this.transform.localPosition += new Vector3(0.01f, 0, 0);
            }

            if (Input.GetKey("d"))
            {
                this.transform.localPosition += new Vector3(-0.01f, 0, 0);
            }
        }
	}
}
