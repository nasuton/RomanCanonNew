using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;




public class DrawAim : MonoBehaviour
{
    [SerializeField]
    GameObject R_hand;
    [SerializeField]
    GameObject line;
    [SerializeField]
    GameObject weapon_aim;

    public Vector3 aim_direction;

    [SerializeField]
    GameObject romanModeManager;

    [SerializeField]
    GameObject romanGauge;

    void Start()
    {
        
    }


    void Update()
    {
        Vector3[] pos = new Vector3[2];
        //if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == false)
        //{
            
        //}
        //else if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == true &&
        //    romanModeManager.GetComponent<RomanModeManager>().roman_type == WeaponStatusManager.RomanType.BurstType.tactical)
        //{
        //    if (GameObject.Find("LMHeadMountedRig").GetComponent<RomanModeManager>().NearEnemy == null)
        //    {
        //        return;
        //    }
        //    pos[0] = romanModeManager.GetComponent<RomanModeManager>().NearEnemy.transform.position;
        //}
        pos[0] = weapon_aim.transform.position;
        pos[1] = R_hand.transform.position;
        aim_direction = pos[0] - pos[1];


        line.transform.position = weapon_aim.transform.position;
        line.transform.forward = aim_direction * 10;
       

    }
}
