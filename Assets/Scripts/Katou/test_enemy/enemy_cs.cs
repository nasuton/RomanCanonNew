using UnityEngine;
using System.Collections;

public class enemy_cs : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;

    Vector3 momentAddition;

    void Start()
    {
        float radian = transform.eulerAngles.y * (Mathf.PI / 180);
        float momentX = (float)(Mathf.Sin(radian) * 0.1);
        float momentZ = (float)(Mathf.Cos(radian) * 0.1);
        momentAddition = new Vector3(momentX, 0, momentZ);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(momentAddition * Time.deltaTime);
    }

    void Attack()
    {

    }

}
