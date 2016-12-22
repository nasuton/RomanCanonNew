using UnityEngine;
using System.Collections;
using UnityEngine.VR;
public class WeaponTypeManager : MonoBehaviour
{
    [SerializeField]
    public WeaponTypeAssets asset = null;

    public LoadSet minigun = new LoadSet();
    public LoadSet rocket = new LoadSet();
    public LoadSet charge = new LoadSet();

    public RomanSet minigun_r = new RomanSet();
    public RomanSet rocket_r = new RomanSet();
    public RomanSet charge_r = new RomanSet();
    static GameObject _instance = null;

    public LoadSet get(int num)
    {
        if (num == 0)
        {
            return minigun;
        }
        if (num == 1)
        {
            return rocket;
        }
        if (num == 2)
        {
            return charge;
        }

        return null;
    }
    public RomanSet getRoman(int num)
    {
        if (num == 0)
        {
            return minigun_r;
        }
        if (num == 1)
        {
            return rocket_r;
        }
        if (num == 2)
        {
            return charge_r;
        }
        return null;
    }
    void Start()
    {
        InputTracking.Recenter();
    }
    void Awake()
    {

        minigun.loadStatus(0);
        rocket.loadStatus(1);
        charge.loadStatus(2);

        minigun_r.loadStatus(0);
        rocket_r.loadStatus(1);
        charge_r.loadStatus(2);
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            //Destroy(gameObject);
        }
    }
}
public class StatusData : MasterBase
{
    public string parts_name { get; private set; }
    public double power { get; private set; }
    public double rate { get; private set; }
    public double distance { get; private set; }
    public double burst_time { get; private set; }
    public double cooler_time { get; private set; }
    public string tips1 { get; private set; }
    public string tips2 { get; private set; }
    public string tips3 { get; private set; }
}


public class LoadSet : MasterTableBase<StatusData>
{
    public string path;

    public void loadStatus(int num)
    {
        if (num == 0)
        {
            path = "minigun";
        }
        else if (num == 1)
        {
            path = "rokeran";
        }
        else if (num == 2)
        {
            path = "charge";
        }
        Load(path);
    }
}


public class RomanData : MasterBase
{
    public string roman_name { get; private set; }
    public double power_buf { get; private set; }
    public double rate_buf { get; private set; }
    public double scatter_buf { get; private set; }
    public double wide_buf { get; private set; }
    public double speed_buf { get; private set; }

    public double power_debuf { get; private set; }
    public double rate_debuf { get; private set; }
    public double scatter_debuf { get; private set; }
    public double wide_debuf { get; private set; }
    public double speed_debuf { get; private set; }

    public double roman_type { get; private set; }
    public double roman_count { get; private set; }
    public double roman_time { get; private set; }
    public double debuf_time { get; private set; }
    public string roman_tips1 { get; private set; }
    public string roman_tips2 { get; private set; }
    public string roman_tips3 { get; private set; }
}

public class RomanSet : MasterTableBase<RomanData>
{
    public string path;

    public void loadStatus(int num)
    {

        if (num == 0)
        {
            path = "minigun_r";
        }
        else if (num == 1)
        {
            path = "rokeran_r";
        }
        else if (num == 2)
        {
            path = "charge_r";
        }

        Load(path);
    }
}