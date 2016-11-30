using UnityEngine;
using System.Collections;

public class BulletOfRailGun : MonoBehaviour
{
    private Vector3 moveVec = new Vector3(0, 0, 0);

    public Vector3 MoveVec
    {
        get { return moveVec; }
        set { moveVec = value; }
    }

    void Start()
    {
    
    }

    void Awake()
    {
        this.GetComponent<BulletDamege>().Damege = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[0];
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        
    }

    public void Reset()
    {
        transform.localPosition = new Vector3(0,0, GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[2]);
        transform.localScale = new Vector3(
            GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[4],
            GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[2],
            GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[4]);
    }


}
