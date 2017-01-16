﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RomanGauge : MonoBehaviour {
    public float roman_value = 0.0f;

    [SerializeField]
    private float roman_max = 100.0f;

    [SerializeField]
    GameObject screenEffect = null;

    //ロマンモードかどうか
    public bool roman_mode = false;
    //クールタイムかどうか
    public bool cool_time_mode = false;

    public int roman_num = 0;

    void Start () {
        roman_num = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().roman_type.num;
    }
    public void chargeRomenGaouge(float value)
    {
        if (roman_mode == false && cool_time_mode == false)
        {
            if (roman_value <= roman_max)
            {
                roman_value += value;
            }
            if (roman_value > roman_max)
            {
                roman_value = roman_max;
            }
        }
    }

    void changeRomanMode()
    {
        if (roman_num > 0)
        {
            if ((int)roman_value == (int)roman_max)
            {
                
                if (Input.GetMouseButton(1))
                {
                    roman_mode = true;
                    roman_num--;
                }
            }
        }
        if (roman_mode == true)
        {
            roman_value -= 100 * ((1 / GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().roman_type.active_time) * Time.deltaTime);
            screenEffect.SetActive(true);
        }
    }
    void gaugeChange()
    {
        this.GetComponent<Image>().fillAmount =  roman_value/roman_max;
    }

    void changeCoolTime()
    {
        if (roman_mode == true)
        {
            if (roman_value < 0)
            {
                roman_mode = false;
                cool_time_mode = true;
            }
        }
        if (cool_time_mode == true)
        {
            roman_value += 100 * ((1 / GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().roman_type.debuf_time) * Time.deltaTime);
            if ((int)roman_value == (int)roman_max)
            {
                cool_time_mode = false;
                roman_value = 0;
            }
        }
    }

	void Update() {
        if(roman_mode == false)
        {
            screenEffect.SetActive(false);
        }
        changeRomanMode();
        changeCoolTime();
        gaugeChange();
    }
}
