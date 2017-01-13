using UnityEngine;
using System.Collections;

public class RocketLauncherController : DefaultGunController
{

    [SerializeField]
    GameObject gravity = null;

    GameObject obj_ins;

    public int roman_count = 0;

    public GameObject roman_bar;

    float move_Vec = 10;

    void Start()
    {
        StartCoroutine(Shot());
    }

    private void MakeBullet()
    {
        GameObject obj = (GameObject)Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        Vector3 force;
        force = transform.forward * speed * (100 - GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[4]);
        obj.GetComponent<VectorMover>().MoveVec = force;
        obj.transform.position = transform.position + transform.forward * 10;
    }
    void Update()
    {
        romanShot();
    }
    private void romanShot()
    {
        if (Input.GetMouseButtonDown(1) &&
                roman_bar.GetComponent<RomanGauge>().roman_mode == true &&
                roman_count == 0 &&
                GameObject.Find("LMHeadMountedRig").GetComponent<RomanModeManager>().roman_type == WeaponStatusManager.RomanType.BurstType.gravity)
            {
                roman_count++;
                obj_ins = (GameObject)Instantiate(gravity, new Vector3(0, 0, 0), Quaternion.identity);
                obj_ins.transform.forward = this.transform.forward;
            }

            if (roman_bar.GetComponent<RomanGauge>().roman_mode == true &&
            GameObject.Find("LMHeadMountedRig").GetComponent<RomanModeManager>().roman_type == WeaponStatusManager.RomanType.BurstType.gravity)
            {
                obj_ins.transform.localPosition += this.transform.forward * move_Vec;
                move_Vec *= 0.9f;
            }
    }
    private IEnumerator Shot()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                Sound.PlaySe("rokeran s");
                MakeBullet();

                yield return new WaitForSeconds(3 + (GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[1] / 10));
            }


            
            yield return 0;
        }
    }
}
