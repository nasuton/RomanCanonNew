using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChargeGauge : MonoBehaviour
{

    public bool isShoted = false;
    public bool canShot = true;
    public float rate = 0.0f;
    public float fire_count = 0.0f;


    //冷却
    private float type_cool;
    //発射可能時間
    private float type_fire_count;
    //連射速度
    private float type_rate;
    
    public  float charge_max;
    public float charge_count;
    public void Default()
    {

        fire_count++;
        if (type_fire_count <= (int)fire_count)
        {
            Sound.PlaySe("minigan h");
            canShot = false;
        }

    }

    public void Cooling()
    {
        if (isShoted == false && 0.0f < (int)fire_count)
        {
            fire_count -= type_cool * Time.deltaTime;
        }
    }
    void CoolTime()
    {
        if (canShot == false)
        {
            if ((int)fire_count == 0.0f)
            {
                canShot = true;
            }
        }
    }
    void Rate()
    {
        rate = 1 / (60 - type_rate);
    }

    void Init()
    {
        type_cool = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[4];
        type_fire_count = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[3];
        type_rate = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[1];

    }
    void Start()
    {

        Init();
        Rate();
    }


    void ChangeSize()
    {
        this.GetComponent<Image>().fillAmount = charge_count / charge_max;
    }
    void Update()
    {
        //CoolTime();
        ChangeSize();
    }
}
