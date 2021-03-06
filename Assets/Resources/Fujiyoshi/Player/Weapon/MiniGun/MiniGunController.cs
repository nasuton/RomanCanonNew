﻿using UnityEngine;
using System.Collections;

public class MiniGunController : DefaultGunController
{

    private GameObject friezeGauge = null;
    public GameObject FriezeGauge { get { return friezeGauge; } set { friezeGauge = value; } }

    [SerializeField]
    float defaultWaitTimeOfShot = 0.1f;

    [SerializeField]
    float maxWaitTimeOfShot = 65.0f;

    

    void Start()
    {
        StartCoroutine(Shot());

    }

    private void MakeBullet()
    {
        GameObject obj = (GameObject)Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        Vector3 force;

        float x = (float)(Random.value - 0.5f)*10;
        float y = (float)(Random.value - 0.5f)*10;
        obj.transform.position = transform.position + transform.forward * 0.5f;
        force = 1000 * transform.forward * speed + new Vector3(x, 0, y);
        
        
        
        if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == true &&
            GameObject.Find("LMHeadMountedRig").GetComponent<RomanModeManager>().roman_type == WeaponStatusManager.RomanType.BurstType.tactical)
        {
            if (GameObject.Find("LMHeadMountedRig").GetComponent<RomanModeManager>().NearEnemy == null)
           { 
                force = 1000 * transform.forward * speed + new Vector3(x,0,y);
            }
            else if(GameObject.Find("LMHeadMountedRig").GetComponent<RomanModeManager>().NearEnemy != null)
            {
                Vector3 auto_aim_vec = (GameObject.Find("LMHeadMountedRig").GetComponent<RomanModeManager>().NearEnemy.transform.position + new Vector3(0, 2, 0)) - obj.transform.position;
                force = auto_aim_vec * 5;
            }
                       
        }

        obj.GetComponent<VectorMover>().MoveVec = force;
        
    }
    
    private void isBurst()
    {
        if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == false)
        {
            friezeGauge.GetComponent<CoolingGauge>().Default();
        }
        else if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == true &&
           GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().roman_type.brust != WeaponStatusManager.RomanType.BurstType.burst)
        {
            friezeGauge.GetComponent<CoolingGauge>().Default();
        }
        else if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == true &&
           GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().roman_type.brust == WeaponStatusManager.RomanType.BurstType.burst)
        {
            ;
        }
    }

    private IEnumerator Shot()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && friezeGauge.GetComponent<CoolingGauge>().canShot == true)
            {
                Sound.PlaySe("minigan r");
                GameObject.Find("WeaponAim").GetComponent<ChangePosition>().Scatter();
                MakeBullet();
                isBurst();
                GameObject.Find("WeaponAim").GetComponent<ChangePosition>().Reset();
                yield return new WaitForSeconds(friezeGauge.GetComponent<CoolingGauge>().rate);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Sound.PlaySe("minigan e");
                friezeGauge.GetComponent<CoolingGauge>().Cooling();
            }
            else
            {
                friezeGauge.GetComponent<CoolingGauge>().Cooling();
            }
            yield return 0;
        }
    }
}
