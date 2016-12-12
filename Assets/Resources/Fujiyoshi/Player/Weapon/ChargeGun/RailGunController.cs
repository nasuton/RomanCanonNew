using UnityEngine;
using System.Collections;

public class RailGunController : MonoBehaviour
{
    [SerializeField]
    GameObject bullet = null;

    [SerializeField]
    GameObject effect1 = null;

    [SerializeField]
    GameObject effect2 = null;

    [SerializeField]
    GameObject gravity = null;

    [SerializeField, Tooltip("BulletSpeed")]
    private float speed = 100.0f;

    [SerializeField, Tooltip("1発撃った後の待機時間")]
    private float waitTimeOfShot = 0.05f;

    public GameObject roman_bar;

    GameObject obj_ins;

    float move_Vec = 10;

    private bool isCharge = false;

    private bool isShoted = false;

    public float chargePower = 0.0f;

    private float charge_default_time = 3;

    private float burst_default_time = 5;

    public float charge_max = 100;

    public float ChargePower
    {
        get { return chargePower; }
    }

    
    void Start()
    {
        isCharge = false;
        isShoted = false;
        bullet.SetActive(false);
        effect1.SetActive(false);
        effect2.SetActive(false);
    }

    private void MakeBullet()
    {
        Vector3 force;
        force = transform.forward * speed;
        bullet.GetComponent<BulletOfRailGun>().MoveVec = force;
    }

    void Update()
    {
        Shot();
        Charge();
        DevideChargePower();
    }

    private void Shot()
    {
        if (isShoted == true) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isCharge == false)
                isCharge = true;
            Sound.PlayBgm("tilya-zi t");

        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (isCharge == true)
            {

                effect1.SetActive(true);
                effect2.SetActive(true);
                Sound.StopBgm();
                Sound.PlayBgm("tilya-zi s");
                isCharge = false;
                isShoted = true;
                bullet.GetComponent<BulletOfRailGun>().Reset();
                bullet.SetActive(true);
                MakeBullet();
            }
        }

        if (Input.GetMouseButtonDown(1) && roman_bar.GetComponent<RomanGauge>().roman_mode == true)
        {
            obj_ins = (GameObject)Instantiate(gravity, new Vector3(0, 0, 0), Quaternion.identity);
            obj_ins.transform.forward = this.transform.forward;
        }
        if(roman_bar.GetComponent<RomanGauge>().roman_mode == true)
        {
            obj_ins.transform.localPosition += this.transform.forward * move_Vec;
            move_Vec *= 0.9f;
        }
    }

    private void Charge()
    {
        if (isCharge == false) return;
        
        chargePower +=  100 * (1/(charge_default_time +(GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[1] / 60))) * Time.deltaTime;

        Debug.Log(chargePower);

        if (chargePower > charge_max)
            chargePower = charge_max;
    }


    private void DevideChargePower()
    {
        if (isShoted == false) return;

        chargePower -= 100 * (1 / (burst_default_time + (GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[3] / 60))) * Time.deltaTime;

        if (chargePower < 0)
        {
            Sound.StopBgm();
            chargePower = 0;
            isShoted = false;
            bullet.SetActive(false);
            effect1.SetActive(false);
            effect2.SetActive(false);
        }
    }

}
