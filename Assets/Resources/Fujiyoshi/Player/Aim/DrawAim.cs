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
        pos[0] = weapon_aim.transform.position;
        pos[1] = R_hand.transform.position;
        aim_direction = pos[0] - pos[1];


        line.transform.position = weapon_aim.transform.position;
        line.transform.forward = aim_direction * 10;
       

    }
}
