using UnityEngine;
using System.Collections;

public class RomanModeManager : MonoBehaviour {

    public WeaponStatusManager.RomanType.BurstType roman_type;

    [SerializeField]
    GameObject weapon_status_manager;

    bool endless = false;
    private float searchTime = 0;

    private GameObject nearEnemy;
    public GameObject NearEnemy
    {
        get { return nearEnemy; }
        set { nearEnemy = value; }
    }

    void Start () {
        roman_type = weapon_status_manager.GetComponent<WeaponStatusManager>().roman_type.brust;
	}

    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;          
        float nearDis = 0;          
        GameObject targetObj = null; 

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }

        }
        return targetObj;
    }

    void AutoAim()
    {
        searchTime += Time.deltaTime;

        if (searchTime >= 0.3f)
        {
            //最も近かったオブジェクトを取得
            nearEnemy = serchTag(gameObject, "Enemy");

            //経過時間を初期化
            searchTime = 0;
        }
    }

    void Rocket()
    {

    }
    void RomanModeController()
    {
        if(roman_type == WeaponStatusManager.RomanType.BurstType.tactical)
        {
            AutoAim();
        }
        if (roman_type == WeaponStatusManager.RomanType.BurstType.rocket)
        {
            Rocket();
        }
    }
	void Update () {
        RomanModeController();
	}
}
