using UnityEngine;
using System.Collections;

public class WeaponTypeManager : MonoBehaviour
{
    [SerializeField]
    public WeaponTypeAssets asset = null;
   
    public LoadSet minigun = new LoadSet();
    public LoadSet rocket = new LoadSet();
    public LoadSet charge = new LoadSet();
    static GameObject _instance = null;
    
    public LoadSet get(int num)
    {
        if(num == 0)
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
    
    void Awake()
    {
        minigun.loadStatus(0);
        rocket.loadStatus(1);
        charge.loadStatus(2);
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
    public string tips { get; private set; }
}


public class LoadSet : MasterTableBase<StatusData>
{
    public  string path;

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
            path = "tya-zi";
        }
        Load(path);
    }
}


public class RomanData : MasterBase
{
    public string parts_name { get; private set; }
    public double power { get; private set; }
    public double rate { get; private set; }
    public double distance { get; private set; }
    public double burst_time { get; private set; }
    public double cooler_time { get; private set; }
    public string tips { get; private set; }
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
            path = "tya-zi_r";
        }
        Load(path);
    }
}