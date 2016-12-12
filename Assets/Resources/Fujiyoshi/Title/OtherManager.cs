using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class OtherManager : MonoBehaviour
{


    [SerializeField]
    GameObject SelectedCustomPartFlame = null;

    [SerializeField]
    GameObject SelectedCustomPartFlame2 = null;

    [SerializeField]
    GameObject parts_parent = null;

    [SerializeField]
    GameObject MiniGun = null;

    [SerializeField]
    GameObject Rocket = null;

    [SerializeField]
    GameObject Charge = null;

    [SerializeField]
    GameObject particle1 = null;

    [SerializeField]
    GameObject particle2 = null;

    [SerializeField]
    GameObject particle3 = null;

    [SerializeField]
    GameObject WeaponType = null;

    [SerializeField]
    GameObject changeStatusBar = null;

    [SerializeField]
    GameObject[] PartsTag = new GameObject[5];

    [SerializeField]
    GameObject[] Parts = new GameObject[4];

    [SerializeField]
    GameObject[] ProductionStatus = new GameObject[5];

    [SerializeField]
    GameObject PartsNameText = null;

    [SerializeField]
    GameObject PartsTipsText = null;

    

    private int weapon_num = 0;

    



    void WeaponSelect(Collider other)
    {
        if (other.gameObject.name == "MiniGun")
        {
            weapon_num = 0;
            Sound.PlaySe("kasutamu_k");
            other.gameObject.GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("RocketLuncher").GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("ChargeCanon").GetComponent<CollisionUI>().isActive = false;
            parts_parent.SetActive(true);
            particle1.SetActive(true);
            particle2.SetActive(false);
            particle3.SetActive(false);
            var obj = GameObject.Find("WeaponType");
            obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = weapon_num;

        }
        if (other.gameObject.name == "RocketLuncher")
        {
            weapon_num = 1;
            Sound.PlaySe("kasutamu_k");
            other.gameObject.GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("MiniGun").GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("ChargeCanon").GetComponent<CollisionUI>().isActive = false;
            parts_parent.SetActive(true);
            particle2.SetActive(true);
            particle1.SetActive(false);
            particle3.SetActive(false);
            var obj = GameObject.Find("WeaponType");
            obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = weapon_num;
        }
        if (other.gameObject.name == "ChargeCanon")
        {
            weapon_num = 2;
            Sound.PlaySe("kasutamu_k");
            other.gameObject.GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("RocketLuncher").GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("MiniGun").GetComponent<CollisionUI>().isActive = false;
            parts_parent.SetActive(true);
            particle3.SetActive(true);
            particle1.SetActive(false);
            particle2.SetActive(false);
            var obj = GameObject.Find("WeaponType");
            obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = weapon_num;
        }

    }

    void Tab(Collider other)
    {
        bool production = false;
        for (int i = 0; i < 5; i++)
        {
            production = PartsTag[i].GetComponent<SelectUI>().isProduction;
            if (production)
                break;
        }
        if (!production)
        {
            if (other.gameObject.name == "PartsBase0")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame.SetActive(true);
                SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase0").transform);
                SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 5; i++)
                {
                    PartsTag[i].GetComponent<SelectUI>().isSelected = false;
                }
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
            }
            if (other.gameObject.name == "PartsBase1")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame.SetActive(true);
                SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase1").transform);
                SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 5; i++)
                {
                    PartsTag[i].GetComponent<SelectUI>().isSelected = false;
                }
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
            }
            if (other.gameObject.name == "PartsBase2")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame.SetActive(true);
                SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase2").transform);
                SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 5; i++)
                {
                    PartsTag[i].GetComponent<SelectUI>().isSelected = false;
                }
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
            }
            if (other.gameObject.name == "PartsBase3")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame.SetActive(true);
                SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase3").transform);
                SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 5; i++)
                {
                    PartsTag[i].GetComponent<SelectUI>().isSelected = false;
                }
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
            }
            if (other.gameObject.name == "PartsBase4")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame.SetActive(true);
                SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase4").transform);
                SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 5; i++)
                {
                    PartsTag[i].GetComponent<SelectUI>().isSelected = false;
                }
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
            }
            if (other.gameObject.name == "PartsBase5")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame.SetActive(true);
                SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase5").transform);
                SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 5; i++)
                {
                    PartsTag[i].GetComponent<SelectUI>().isSelected = false;
                }
                other.gameObject.GetComponent<SelectUI>().isSelected = true;

            }
        }
    }

    void PartsSet(Collider other)
    {
        int num = 0;
        for (int k = 0; k < 5; k++)
        {
            if (PartsTag[k].GetComponent<SelectUI>().isSelected)
            {
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("CustomParts").Length; i++)
                {
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Name = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].parts_name;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Status1 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].power;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Status2 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].rate;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Status3 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].distance;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Status4 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].burst_time;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Status5 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].cooler_time;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Tips = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].tips;
                }
            }
            num += 4;
        }
    }
    
    void PartsSelect(Collider other)
    {
        bool production = false;
        for (int i = 0; i < 4; i++)
        {
            production = Parts[i].GetComponent<SelectUI>().isProduction;
            if (production)
                break;
        }
        if (!production)
        {
            if (other.gameObject.name == "Parts1")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame2.SetActive(true);
                SelectedCustomPartFlame2.transform.SetParent(GameObject.Find("Parts1").transform);
                SelectedCustomPartFlame2.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 4; i++)
                {
                    Parts[i].GetComponent<SelectUI>().isSelected = false;
                }
                //other.gameObject.GetComponent<SelectUI>().isSelected = true;
                for (int i = 0; i < 5; i++)
                {
                    if (PartsTag[i].GetComponent<SelectUI>().isSelected)
                    {
                        PartsTag[i].GetComponent<PartsStatus>().Name = other.GetComponent<PartsStatus>().Name;
                        PartsTag[i].GetComponent<PartsStatus>().Status1 = other.GetComponent<PartsStatus>().Status1;
                        PartsTag[i].GetComponent<PartsStatus>().Status2 = other.GetComponent<PartsStatus>().Status2;
                        PartsTag[i].GetComponent<PartsStatus>().Status3 = other.GetComponent<PartsStatus>().Status3;
                        PartsTag[i].GetComponent<PartsStatus>().Status4 = other.GetComponent<PartsStatus>().Status4;
                        PartsTag[i].GetComponent<PartsStatus>().Status5 = other.GetComponent<PartsStatus>().Status5;
                        PartsTag[i].GetComponent<PartsStatus>().Tips = other.GetComponent<PartsStatus>().Tips;
                    }
                }
            }
            if (other.gameObject.name == "Parts2")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame2.SetActive(true);
                SelectedCustomPartFlame2.transform.SetParent(GameObject.Find("Parts2").transform);
                SelectedCustomPartFlame2.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 4; i++)
                {
                    Parts[i].GetComponent<SelectUI>().isSelected = false;
                }
                //other.gameObject.GetComponent<SelectUI>().isSelected = true;
                for (int i = 0; i < 5; i++)
                {
                    if (PartsTag[i].GetComponent<SelectUI>().isSelected)
                    {
                        PartsTag[i].GetComponent<PartsStatus>().Name = other.GetComponent<PartsStatus>().Name;
                        PartsTag[i].GetComponent<PartsStatus>().Status1 = other.GetComponent<PartsStatus>().Status1;
                        PartsTag[i].GetComponent<PartsStatus>().Status2 = other.GetComponent<PartsStatus>().Status2;
                        PartsTag[i].GetComponent<PartsStatus>().Status3 = other.GetComponent<PartsStatus>().Status3;
                        PartsTag[i].GetComponent<PartsStatus>().Status4 = other.GetComponent<PartsStatus>().Status4;
                        PartsTag[i].GetComponent<PartsStatus>().Status5 = other.GetComponent<PartsStatus>().Status5;
                        PartsTag[i].GetComponent<PartsStatus>().Tips = other.GetComponent<PartsStatus>().Tips;
                    }
                }
            }
            if (other.gameObject.name == "Parts3")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame2.SetActive(true);
                SelectedCustomPartFlame2.transform.SetParent(GameObject.Find("Parts3").transform);
                SelectedCustomPartFlame2.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 4; i++)
                {
                    Parts[i].GetComponent<SelectUI>().isSelected = false;
                }
                //other.gameObject.GetComponent<SelectUI>().isSelected = true;
                for (int i = 0; i < 5; i++)
                {
                    if (PartsTag[i].GetComponent<SelectUI>().isSelected)
                    {
                        PartsTag[i].GetComponent<PartsStatus>().Name = other.GetComponent<PartsStatus>().Name;
                        PartsTag[i].GetComponent<PartsStatus>().Status1 = other.GetComponent<PartsStatus>().Status1;
                        PartsTag[i].GetComponent<PartsStatus>().Status2 = other.GetComponent<PartsStatus>().Status2;
                        PartsTag[i].GetComponent<PartsStatus>().Status3 = other.GetComponent<PartsStatus>().Status3;
                        PartsTag[i].GetComponent<PartsStatus>().Status4 = other.GetComponent<PartsStatus>().Status4;
                        PartsTag[i].GetComponent<PartsStatus>().Status5 = other.GetComponent<PartsStatus>().Status5;
                        PartsTag[i].GetComponent<PartsStatus>().Tips = other.GetComponent<PartsStatus>().Tips;
                    }
                }
            }
            if (other.gameObject.name == "Parts4")
            {
                Sound.PlaySe("kasutamu_k");
                SelectedCustomPartFlame2.SetActive(true);
                SelectedCustomPartFlame2.transform.SetParent(GameObject.Find("Parts4").transform);
                SelectedCustomPartFlame2.transform.localPosition = new Vector3(0, 0, 0);
                other.gameObject.GetComponent<SelectUI>().isActive = false;
                for (int i = 0; i < 4; i++)
                {
                    Parts[i].GetComponent<SelectUI>().isSelected = false;
                }
                //other.gameObject.GetComponent<SelectUI>().isSelected = true;
                for (int i = 0; i < 5; i++)
                {
                    if (PartsTag[i].GetComponent<SelectUI>().isSelected)
                    {
                        PartsTag[i].GetComponent<PartsStatus>().Name = other.GetComponent<PartsStatus>().Name;
                        PartsTag[i].GetComponent<PartsStatus>().Status1 = other.GetComponent<PartsStatus>().Status1;
                        PartsTag[i].GetComponent<PartsStatus>().Status2 = other.GetComponent<PartsStatus>().Status2;
                        PartsTag[i].GetComponent<PartsStatus>().Status3 = other.GetComponent<PartsStatus>().Status3;
                        PartsTag[i].GetComponent<PartsStatus>().Status4 = other.GetComponent<PartsStatus>().Status4;
                        PartsTag[i].GetComponent<PartsStatus>().Status5 = other.GetComponent<PartsStatus>().Status5;
                        PartsTag[i].GetComponent<PartsStatus>().Tips = other.GetComponent<PartsStatus>().Tips;
                    }
                }
            }
        }
    }

    void StatusChange(Collider other)
    {
        for (int i = 0; i < 5; i++)
        {
            WeaponType.GetComponent<NormalPartsStatus>().status[i] = 0;
        }
        for (int k = 0; k < 5; k++)
        {

            WeaponType.GetComponent<NormalPartsStatus>().status[0] += PartsTag[k].GetComponent<PartsStatus>().Status1;
            WeaponType.GetComponent<NormalPartsStatus>().status[1] += PartsTag[k].GetComponent<PartsStatus>().Status2;
            WeaponType.GetComponent<NormalPartsStatus>().status[2] += PartsTag[k].GetComponent<PartsStatus>().Status3;
            WeaponType.GetComponent<NormalPartsStatus>().status[3] += PartsTag[k].GetComponent<PartsStatus>().Status4;
            WeaponType.GetComponent<NormalPartsStatus>().status[4] += PartsTag[k].GetComponent<PartsStatus>().Status5;

        }
    }
    void DrawName()
    {
        for (int k = 0; k < 5; k++)
        {
            if (PartsTag[k].GetComponent<SelectUI>().isSelected)
            {
                PartsNameText.GetComponent<TextMesh>().text = PartsTag[k].GetComponent<PartsStatus>().Name;
                PartsTipsText.GetComponent<TextMesh>().text = PartsTag[k].GetComponent<PartsStatus>().Tips;
            }
        }
    }

    void DrawStatus()
    {
        for (int i = 0; i < 5; i++)
        {
            ProductionStatus[i].GetComponent<StatusProduction>().next_value = WeaponType.GetComponent<NormalPartsStatus>().status[i];
            ProductionStatus[i].GetComponent<StatusProduction>().changeStatus();
        }
    }

    void StartOrBack(Collider other)
    {
        if (other.gameObject.name == "BackGameSelect")
        {
            other.GetComponent<ButtonUI>().isActive = false;
            parts_parent.SetActive(false);
            Sound.PlaySe("kasutamu_k");
            MiniGun.SetActive(true);
            Rocket.SetActive(true);
            Charge.SetActive(true);
            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(false);
        }
        if (other.gameObject.name == "GameStart")
        {
            other.GetComponent<ButtonUI>().isActive = false;
            SceneChanger.Instance.LoadLevel("Fujiyoshi", 1.0f);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WeaponSelect(other);
            StartOrBack(other);
            Tab(other);
            PartsSet(other);
            PartsSelect(other);
            StatusChange(other);
            DrawName();
            DrawStatus();
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.localPosition += new Vector3(0, -0.01f, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.localPosition += new Vector3(0, 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.localPosition += new Vector3(-0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.localPosition += new Vector3(0.01f, 0, 0);
        }
    }
}

