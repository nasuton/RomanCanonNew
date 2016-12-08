using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TitleManager : MonoBehaviour
{
    LoadSet status = new LoadSet();

    [SerializeField]
    GameObject SelectedCustomPartFlame = null;

    [SerializeField]
    GameObject parts_parent = null;

    [SerializeField]
    GameObject particle1 = null;

    [SerializeField]
    GameObject particle2 = null;

    [SerializeField]
    GameObject particle3 = null;

    private int weapon_num = 0;


    public struct CostomParts
    {
        public string name;
        public float[] status;
        public string tips;
    }
    public Dictionary<string, CostomParts> parts = new Dictionary<string, CostomParts>();

    void LoadStatus()
    {

    }
    public double a;
    void Awake() {
        status.loadStatus();
        int inclement_buf = 0;
        foreach (var inc in status.All)
        {
            inclement_buf++;
            float[] f = new float[5];
            CostomParts buf = new CostomParts();
            a = inc.power;
            f[0] = (float)inc.power;
            f[1] = (float)inc.rate;
            f[2] = (float)inc.distance;
            f[3] = (float)inc.burst_time;
            f[4] = (float)inc.cooler_time;
            buf.status = f;
            buf.name = inc.parts_name;
            buf.tips = inc.tips;
            
            parts.Add("パーツ", buf);
            
        }
        
       
    }



    void WeaponSelect(Collider other)
    {
        if (other.gameObject.name == "MiniGun")
        {
            weapon_num = 0;
            other.gameObject.GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("RocketLuncher").GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("ChargeCanon").GetComponent<CollisionUI>().isActive = false;
            parts_parent.SetActive(true);
            particle1.SetActive(true);
            particle2.SetActive(false);
            particle3.SetActive(false);
            
        }
        if (other.gameObject.name == "RocketLuncher")
        {
            weapon_num = 1;
            other.gameObject.GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("MiniGun").GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("ChargeCanon").GetComponent<CollisionUI>().isActive = false;
            parts_parent.SetActive(true);
            particle2.SetActive(true);
            particle1.SetActive(false);
            particle3.SetActive(false);
        }
        if (other.gameObject.name == "ChargeCanon")
        {
            weapon_num = 2;
            other.gameObject.GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("RocketLuncher").GetComponent<CollisionUI>().isActive = false;
            GameObject.Find("MiniGun").GetComponent<CollisionUI>().isActive = false;
            parts_parent.SetActive(true);
            particle3.SetActive(true);
            particle1.SetActive(false);
            particle2.SetActive(false);
        }

    }

    void Tab(Collider other)
    {
        if (other.gameObject.name == "PartsBase0")
        {
            Sound.PlaySe("kasutamu_k");
            SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase0").transform);
            SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<SelectUI>().isActive = false;
        }
        if (other.gameObject.name == "PartsBase1")
        {
            Sound.PlaySe("kasutamu_k");
            SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase1").transform);
            SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<SelectUI>().isActive = false;
        }
        if (other.gameObject.name == "PartsBase2")
        {
            Sound.PlaySe("kasutamu_k");
            SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase2").transform);
            SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<SelectUI>().isActive = false;
        }
        if (other.gameObject.name == "PartsBase3")
        {
            Sound.PlaySe("kasutamu_k");
            SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase3").transform);
            SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<SelectUI>().isActive = false;
        }
        if (other.gameObject.name == "PartsBase4")
        {
            Sound.PlaySe("kasutamu_k");
            SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase4").transform);
            SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<SelectUI>().isActive = false;
        }
        if (other.gameObject.name == "PartsBase5")
        {
            Sound.PlaySe("kasutamu_k");
            SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase5").transform);
            SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<SelectUI>().isActive = false;

        }
    }

    void OnTriggerEnter(Collider other)
    {

        WeaponSelect(other);

        Tab(other);

    }
    void Start()
    {
        
    }
    void Update()
    {

    }
}

public class Data : MasterBase
{
    public string parts_name { get; private set; }
    public double power { get; private set; }
    public double rate { get; private set; }
    public double distance { get; private set; }
    public double burst_time { get; private set; }
    public double cooler_time { get; private set; }
    public string tips { get; private set; }
}


public class LoadSet : MasterTableBase<Data>
{
    public static readonly string path = "minigun";

    public void loadStatus()
    {
        Load(path);
    }
}