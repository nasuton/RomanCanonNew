using UnityEngine;
using System.Collections;

public class DefaultGunController : MonoBehaviour
{
    [SerializeField]
    protected GameObject bullet = null;

    [SerializeField, Tooltip("BulletSpeed")]
    protected float speed = 100000000;

    [SerializeField, Tooltip("1発撃った後の待機時間")]
    public float waitTimeOfShot = 1;

}
