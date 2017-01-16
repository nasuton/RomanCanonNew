﻿using UnityEngine;
using System.Collections;

public class WeaponStatusManager : MonoBehaviour {
    [SerializeField]
    GameObject romanGauge;

    public float[] status = new float[5];

    public float[] Status
    {
        get { return status; }
        set { status = value; }
    }
    private float[] roman_status = new float[5];
    private float[] normal_status = new float[5];
    private float[] debuf_status = new float[5];

    public struct RomanType
    {
        public enum BurstType
        {
            rocket = 1,
            normal = 3,
            burst = 0,
            tactical = 2,
            mailbomb = 0,
            silverking = 1,
            gravity = 2,
            limitter = 3,
            charge1 = 0,
            charge2 = 1,
            charge3 = 2,
            charge4 = 3,

        }
        public BurstType brust;
        public int num;
        public float active_time;
        public float debuf_time;
    }
    public RomanType roman_type;

    
    void romanInit()
    {
        roman_type.brust = (RomanType.BurstType)GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().BulletNum;
        roman_type.num = GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().CanRomanModeCount;
        roman_type.active_time = GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().RomanModeTime;
        roman_type.debuf_time = GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().DebuffTime;
    }

    void statusInit()
    {
        for (int i = 0; i < status.Length; i++)
        {
            status[i] = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[i];
            roman_status[i] = GameObject.Find("WeaponType").GetComponent<RomanPartsStauts>().Status[i];
            debuf_status[i] = GameObject.Find("WeaponType").GetComponent<DownPartsStatus>().Status[i];
        }
    }

    void Awake()
    {
        romanInit();
        statusInit();
    }

    void statusChange()
    {
        //通常時
        if(romanGauge.GetComponent<RomanGauge>().roman_mode == false &&
            romanGauge.GetComponent<RomanGauge>().cool_time_mode == false)
        {
            for (int i = 0; i < status.Length; i++)
            {
                status[i] = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[i];
            }
        }



        //ロマンモード時
        if(romanGauge.GetComponent<RomanGauge>().roman_mode == true &&
            romanGauge.GetComponent<RomanGauge>().cool_time_mode == false)
        {
            
            for (int i = 0; i < status.Length; i++)
            {
                status[i] = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[i] * roman_status[i];
            }
            
        }


        //クールタイム時
        if (romanGauge.GetComponent<RomanGauge>().roman_mode == false &&
            romanGauge.GetComponent<RomanGauge>().cool_time_mode == true)
        {
            
            for (int i = 0; i < status.Length; i++)
            {
                status[i] = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[i] * debuf_status[i];
            }
        }
    }

    void Update()
    {
        statusChange();
    }
}
