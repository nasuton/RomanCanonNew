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
    GameObject RomanPartsTag = null;

    [SerializeField]
    GameObject PartsNameText = null;

    [SerializeField]
    GameObject PartsTipsText = null;


    private int weapon_num = 0;


    void defaultSelect()
    {
        for (int i = 0; i < 5; i++)
        {
            PartsTag[i].GetComponent<SelectUI>().isSelected = false;
        }
        PartsTag[0].GetComponent<SelectUI>().isSelected = true;

        for (int i = 0; i < 4; i++)
        {
            Parts[i].GetComponent<SelectUI>().isSelected = false;
        }
        Parts[3].GetComponent<SelectUI>().isSelected = true;

        RomanPartsTag.GetComponent<SelectRoman>().parts_name = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].roman_name;
        RomanPartsTag.GetComponent<SelectRoman>().power_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].power_buf;
        RomanPartsTag.GetComponent<SelectRoman>().rate_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].rate_buf;
        RomanPartsTag.GetComponent<SelectRoman>().scatter_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].scatter_buf;
        RomanPartsTag.GetComponent<SelectRoman>().wide_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].wide_buf;
        RomanPartsTag.GetComponent<SelectRoman>().speed_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].speed_buf;

        RomanPartsTag.GetComponent<SelectRoman>().power_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].power_debuf;
        RomanPartsTag.GetComponent<SelectRoman>().rate_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].rate_debuf;
        RomanPartsTag.GetComponent<SelectRoman>().scatter_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].scatter_debuf;
        RomanPartsTag.GetComponent<SelectRoman>().wide_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].wide_debuf;
        RomanPartsTag.GetComponent<SelectRoman>().speed_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].speed_debuf;

        RomanPartsTag.GetComponent<SelectRoman>().roman_type = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].roman_type;
        RomanPartsTag.GetComponent<SelectRoman>().roman_count = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].roman_count;
        RomanPartsTag.GetComponent<SelectRoman>().roman_time = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].roman_time;
        RomanPartsTag.GetComponent<SelectRoman>().debuf_time = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].debuf_time;
        RomanPartsTag.GetComponent<SelectRoman>().tips1 = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].roman_tips1;
        RomanPartsTag.GetComponent<SelectRoman>().tips2 = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].roman_tips2;
        RomanPartsTag.GetComponent<SelectRoman>().tips3 = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[3].roman_tips3;

        int num = 3;
        for (int i = 0; i < 5; i++)
        {

            PartsTag[i].GetComponent<PartsStatus>().Name = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].parts_name;
            PartsTag[i].GetComponent<PartsStatus>().Status1 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].power;
            PartsTag[i].GetComponent<PartsStatus>().Status2 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].rate;
            PartsTag[i].GetComponent<PartsStatus>().Status3 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].distance;
            PartsTag[i].GetComponent<PartsStatus>().Status4 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].burst_time;
            PartsTag[i].GetComponent<PartsStatus>().Status5 = (float)WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].cooler_time;
            PartsTag[i].GetComponent<PartsStatus>().Tips1 = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].tips1;
            PartsTag[i].GetComponent<PartsStatus>().Tips2 = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].tips2;
            PartsTag[i].GetComponent<PartsStatus>().Tips3 = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[num].tips3;
            num += 4;
        }
    }


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

            defaultSelect();

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
            defaultSelect();
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
            defaultSelect();
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
                RomanPartsTag.GetComponent<SelectUI>().isSelected = true;
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
                RomanPartsTag.GetComponent<SelectUI>().isSelected = false;
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
                RomanPartsTag.GetComponent<SelectUI>().isSelected = false;
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
                RomanPartsTag.GetComponent<SelectUI>().isSelected = false;
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
                RomanPartsTag.GetComponent<SelectUI>().isSelected = false;
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
                RomanPartsTag.GetComponent<SelectUI>().isSelected = false;

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
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Tips1 = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].tips1;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Tips2 = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].tips2;
                    GameObject.FindGameObjectsWithTag("CustomParts")[i].GetComponent<PartsStatus>().Tips3 = WeaponType.GetComponent<WeaponTypeManager>().get(weapon_num).All[i + num].tips3;
                }
            }
            num += 4;
        }
    }

    void RomanSet()
    {
        if (RomanPartsTag.GetComponent<SelectUI>().isSelected)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("CustomParts").Length; i++)
            {

                Parts[i].GetComponent<SelectRoman>().parts_name = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].roman_name;
                Parts[i].GetComponent<SelectRoman>().power_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].power_buf;
                Parts[i].GetComponent<SelectRoman>().rate_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].rate_buf;
                Parts[i].GetComponent<SelectRoman>().scatter_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].scatter_buf;
                Parts[i].GetComponent<SelectRoman>().wide_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].wide_buf;
                Parts[i].GetComponent<SelectRoman>().speed_buf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].speed_buf;

                Parts[i].GetComponent<SelectRoman>().power_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].power_debuf;
                Parts[i].GetComponent<SelectRoman>().rate_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].rate_debuf;
                Parts[i].GetComponent<SelectRoman>().scatter_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].scatter_debuf;
                Parts[i].GetComponent<SelectRoman>().wide_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].wide_debuf;
                Parts[i].GetComponent<SelectRoman>().speed_debuf = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].speed_debuf;

                Parts[i].GetComponent<SelectRoman>().roman_type = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].roman_type;
                Parts[i].GetComponent<SelectRoman>().roman_count = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].roman_count;
                Parts[i].GetComponent<SelectRoman>().roman_time = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].roman_time;
                Parts[i].GetComponent<SelectRoman>().debuf_time = (float)WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].debuf_time;
                Parts[i].GetComponent<SelectRoman>().tips1 = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].roman_tips1;
                Parts[i].GetComponent<SelectRoman>().tips2 = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].roman_tips2;
                Parts[i].GetComponent<SelectRoman>().tips3 = WeaponType.GetComponent<WeaponTypeManager>().getRoman(weapon_num).All[i].roman_tips3;

            }
        }
    }
    void inputRomanTab(Collider other)
    {
        if (RomanPartsTag.GetComponent<SelectUI>().isSelected)
        {
            RomanPartsTag.GetComponent<SelectRoman>().parts_name = other.GetComponent<SelectRoman>().parts_name;
            RomanPartsTag.GetComponent<SelectRoman>().power_buf = (float)other.GetComponent<SelectRoman>().power_buf;
            RomanPartsTag.GetComponent<SelectRoman>().rate_buf = (float)other.GetComponent<SelectRoman>().rate_buf;
            RomanPartsTag.GetComponent<SelectRoman>().scatter_buf = (float)other.GetComponent<SelectRoman>().scatter_buf;
            RomanPartsTag.GetComponent<SelectRoman>().wide_buf = (float)other.GetComponent<SelectRoman>().wide_buf;
            RomanPartsTag.GetComponent<SelectRoman>().speed_buf = (float)other.GetComponent<SelectRoman>().speed_buf;

            RomanPartsTag.GetComponent<SelectRoman>().power_debuf = (float)other.GetComponent<SelectRoman>().power_debuf;
            RomanPartsTag.GetComponent<SelectRoman>().rate_debuf = (float)other.GetComponent<SelectRoman>().rate_debuf;
            RomanPartsTag.GetComponent<SelectRoman>().scatter_debuf = (float)other.GetComponent<SelectRoman>().scatter_debuf;
            RomanPartsTag.GetComponent<SelectRoman>().wide_debuf = (float)other.GetComponent<SelectRoman>().wide_debuf;
            RomanPartsTag.GetComponent<SelectRoman>().speed_debuf = (float)other.GetComponent<SelectRoman>().speed_debuf;

            RomanPartsTag.GetComponent<SelectRoman>().roman_type = (float)other.GetComponent<SelectRoman>().roman_type;
            RomanPartsTag.GetComponent<SelectRoman>().roman_count = (float)other.GetComponent<SelectRoman>().roman_count;
            RomanPartsTag.GetComponent<SelectRoman>().roman_time = (float)other.GetComponent<SelectRoman>().roman_time;
            RomanPartsTag.GetComponent<SelectRoman>().debuf_time = (float)other.GetComponent<SelectRoman>().debuf_time;
            RomanPartsTag.GetComponent<SelectRoman>().tips1 = other.GetComponent<SelectRoman>().tips1;
            RomanPartsTag.GetComponent<SelectRoman>().tips2 = other.GetComponent<SelectRoman>().tips2;
            RomanPartsTag.GetComponent<SelectRoman>().tips3 = other.GetComponent<SelectRoman>().tips3;
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
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
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
                        PartsTag[i].GetComponent<PartsStatus>().Tips1 = other.GetComponent<PartsStatus>().Tips1;
                        PartsTag[i].GetComponent<PartsStatus>().Tips2 = other.GetComponent<PartsStatus>().Tips2;
                        PartsTag[i].GetComponent<PartsStatus>().Tips3 = other.GetComponent<PartsStatus>().Tips3;
                    }
                }
                inputRomanTab(other);

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
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
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
                        PartsTag[i].GetComponent<PartsStatus>().Tips1 = other.GetComponent<PartsStatus>().Tips1;
                        PartsTag[i].GetComponent<PartsStatus>().Tips2 = other.GetComponent<PartsStatus>().Tips2;
                        PartsTag[i].GetComponent<PartsStatus>().Tips3 = other.GetComponent<PartsStatus>().Tips3;
                    }
                }
                inputRomanTab(other);
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
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
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
                        PartsTag[i].GetComponent<PartsStatus>().Tips1 = other.GetComponent<PartsStatus>().Tips1;
                        PartsTag[i].GetComponent<PartsStatus>().Tips2 = other.GetComponent<PartsStatus>().Tips2;
                        PartsTag[i].GetComponent<PartsStatus>().Tips3 = other.GetComponent<PartsStatus>().Tips3;
                    }
                }
                inputRomanTab(other);
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
                other.gameObject.GetComponent<SelectUI>().isSelected = true;
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
                        PartsTag[i].GetComponent<PartsStatus>().Tips1 = other.GetComponent<PartsStatus>().Tips1;
                        PartsTag[i].GetComponent<PartsStatus>().Tips2 = other.GetComponent<PartsStatus>().Tips2;
                        PartsTag[i].GetComponent<PartsStatus>().Tips3 = other.GetComponent<PartsStatus>().Tips3;
                    }
                }
                inputRomanTab(other);
            }
        }
    }

    void StatusChange(Collider other)
    {
        for (int i = 0; i < 5; i++)
        {
            WeaponType.GetComponent<NormalPartsStatus>().status[i] = 0;
            WeaponType.GetComponent<RomanPartsStauts>().status[i] = 0;
            WeaponType.GetComponent<DownPartsStatus>().status[i] = 0;
        }
        WeaponType.GetComponent<RomanCanonStatus>().BulletNum = 0;
        WeaponType.GetComponent<RomanCanonStatus>().CanRomanModeCount = 0;
        WeaponType.GetComponent<RomanCanonStatus>().RomanModeTime = 0;
        WeaponType.GetComponent<RomanCanonStatus>().DebuffTime = 0;
        for (int k = 0; k < 5; k++)
        {

            WeaponType.GetComponent<NormalPartsStatus>().status[0] += PartsTag[k].GetComponent<PartsStatus>().Status1;
            WeaponType.GetComponent<NormalPartsStatus>().status[1] += PartsTag[k].GetComponent<PartsStatus>().Status2;
            WeaponType.GetComponent<NormalPartsStatus>().status[2] += PartsTag[k].GetComponent<PartsStatus>().Status3;
            WeaponType.GetComponent<NormalPartsStatus>().status[3] += PartsTag[k].GetComponent<PartsStatus>().Status4;
            WeaponType.GetComponent<NormalPartsStatus>().status[4] += PartsTag[k].GetComponent<PartsStatus>().Status5;

        }

        WeaponType.GetComponent<RomanPartsStauts>().status[0] = (float)RomanPartsTag.GetComponent<SelectRoman>().power_buf;
        WeaponType.GetComponent<RomanPartsStauts>().status[1] = (float)RomanPartsTag.GetComponent<SelectRoman>().rate_buf;
        WeaponType.GetComponent<RomanPartsStauts>().status[2] = (float)RomanPartsTag.GetComponent<SelectRoman>().scatter_buf;
        WeaponType.GetComponent<RomanPartsStauts>().status[3] = (float)RomanPartsTag.GetComponent<SelectRoman>().wide_buf;
        WeaponType.GetComponent<RomanPartsStauts>().status[4] = (float)RomanPartsTag.GetComponent<SelectRoman>().speed_buf;

        WeaponType.GetComponent<DownPartsStatus>().status[0] = (float)RomanPartsTag.GetComponent<SelectRoman>().power_debuf;
        WeaponType.GetComponent<DownPartsStatus>().status[1] = (float)RomanPartsTag.GetComponent<SelectRoman>().rate_debuf;
        WeaponType.GetComponent<DownPartsStatus>().status[2] = (float)RomanPartsTag.GetComponent<SelectRoman>().scatter_debuf;
        WeaponType.GetComponent<DownPartsStatus>().status[3] = (float)RomanPartsTag.GetComponent<SelectRoman>().wide_debuf;
        WeaponType.GetComponent<DownPartsStatus>().status[4] = (float)RomanPartsTag.GetComponent<SelectRoman>().speed_debuf;


        WeaponType.GetComponent<RomanCanonStatus>().BulletNum = (int)RomanPartsTag.GetComponent<SelectRoman>().roman_count;
        WeaponType.GetComponent<RomanCanonStatus>().CanRomanModeCount = (int)RomanPartsTag.GetComponent<SelectRoman>().roman_count;
        WeaponType.GetComponent<RomanCanonStatus>().RomanModeTime = (int)RomanPartsTag.GetComponent<SelectRoman>().roman_time;
        WeaponType.GetComponent<RomanCanonStatus>().DebuffTime = (int)RomanPartsTag.GetComponent<SelectRoman>().debuf_time;

    }
    void DrawName()
    {
        if (RomanPartsTag.GetComponent<SelectUI>().isSelected)
        {
            PartsNameText.GetComponent<TextMesh>().text = RomanPartsTag.GetComponent<SelectRoman>().parts_name;
            PartsTipsText.GetComponent<TextMesh>().text = RomanPartsTag.GetComponent<SelectRoman>().tips1 + "\n"
                                                         + RomanPartsTag.GetComponent<SelectRoman>().tips2 + "\n"
                                                         + RomanPartsTag.GetComponent<SelectRoman>().tips3;
        }
        for (int k = 0; k < 5; k++)
        {
            if (PartsTag[k].GetComponent<SelectUI>().isSelected)
            {
                PartsNameText.GetComponent<TextMesh>().text = PartsTag[k].GetComponent<PartsStatus>().Name;
                PartsTipsText.GetComponent<TextMesh>().text = PartsTag[k].GetComponent<PartsStatus>().Tips1 + "\n"
                                                             + PartsTag[k].GetComponent<PartsStatus>().Tips2 + "\n"
                                                             + PartsTag[k].GetComponent<PartsStatus>().Tips3;
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
            Sound.PlaySe("kasutamu_k");
            MiniGun.SetActive(true);
            Rocket.SetActive(true);
            Charge.SetActive(true);
            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(false);
            parts_parent.GetComponent<CustomMake>().isActive = false;
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
            PartsSet(other);
            RomanSet();
            Tab(other);
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

