﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//! 銃の操作を管理するクラスです
//! 右手と左手のPosを入れてください 
//!
//! 2016-10-13

public class GunManager : MonoBehaviour
{
    //Weapon設定
    [SerializeField]
    public GameObject[] weapon = null;

    [SerializeField,Tooltip("回転速度設定用数値")]
    public float lookSpeed = 3.0f;

    

    [SerializeField]
    GameObject WeaponAim;

    public enum WeaponType
    {
        NONE = -1,
        MINI_GUN,
        ROCKET_LAUNCHER,
        RAIL_GUN
    }

    public int weaponType = 0;
    
    //左手の座標
    private Vector3 leftPos;

    public Vector3 LeftPos
    {
        get { return leftPos; }
        set { leftPos = value; }
    }

    //右手の座標
    private Vector3 rightPos;

    public Vector3 RightPos
    {
        get { return rightPos; }
        set { rightPos = value; }
    }
    [SerializeField]
    GameObject friezeGauge = null;
    [SerializeField]
    GameObject friezeBar = null;

    [SerializeField]
    GameObject ChargeGauge = null;
    [SerializeField]
    GameObject ChargeBar = null;

    [SerializeField]
    GameObject RomanGaugeBar = null;

    [SerializeField]
    GameObject AimDirection = null;

    

    void Start()
    {
        var type = GameObject.Find("WeaponType");
        weaponType = type.GetComponent<WeaponTypeManager>().asset.WeaponNum;
        MakeWeapon();
        MakeUI();
        rightPos = new Vector3(0, 0, 0);
        leftPos = new Vector3(0, 0, 0);
    }

    void MakeUI()
    {
        if(weaponType == (int)WeaponType.MINI_GUN)
        {
            friezeGauge.SetActive(true);
            
        }
        else if(weaponType == (int)WeaponType.RAIL_GUN)
        {
            ChargeGauge.SetActive(true);
        }
    }
    GameObject obj;
    void MakeWeapon()
    {
        //var type = GameObject.Find("WeaponType");
        
        obj = (GameObject)Instantiate(weapon[weaponType],
                           new Vector3(0, 0, 0), Quaternion.identity);
        if (weaponType == (int)WeaponType.MINI_GUN)
        {
            obj.GetComponent<MiniGunController>().FriezeGauge = friezeBar;
        }
        
        obj.transform.parent = GameObject.Find("WeaponAim").transform;
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (weaponType == (int)WeaponType.MINI_GUN)
        {
            obj.transform.localPosition = new Vector3(0, 2, -2);
        }
        if (weaponType == (int)WeaponType.ROCKET_LAUNCHER)
        {
            obj.transform.localPosition = new Vector3(-1.37f, -1.5f, -4.7f);
            obj.GetComponent<RocketLauncherController>().roman_bar = RomanGaugeBar;
        }
        if (weaponType == (int)WeaponType.RAIL_GUN)
        {
            obj.transform.localPosition = new Vector3(-0.3f,-0.1f, -4.1f);
        }
    }
    void gunTransform()
    {
        obj.transform.forward = AimDirection.GetComponent<DrawAim>().aim_direction * 3;
    }
    void Update()
    {
        gunTransform();
        transform.position = WeaponAim.transform.position;
        transform.LookAt(WeaponAim.transform.position);
        if (weaponType == (int)WeaponType.RAIL_GUN)
        {
            ChargeBar.GetComponent<ChargeGauge>().charge_max = obj.GetComponent<RailGunController>().charge_max;
            ChargeBar.GetComponent<ChargeGauge>().charge_count = obj.GetComponent<RailGunController>().chargePower;
        }
    }

   

}
