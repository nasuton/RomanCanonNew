using UnityEngine;
using System.Collections;

public class enemy4_cs : MonoBehaviour
{

    Vector3 target;

    bool jumpflug;
    bool execution;

    Rigidbody body;

    [SerializeField]
    float jump_power;

    [SerializeField]
    private float maxtime = 2;

    float nowtime;

    [SerializeField]
    private float speed;

    void Start()
    {
        target = Vector3.zero;
        jumpflug = false;
        execution = false;
        body = GetComponent<Rigidbody>();
        jump_power = 500.0f;
        nowtime = 0.0f;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (!jumpflug)
        {
            nowtime += Time.deltaTime;
            if (maxtime <= nowtime)
            {
                jumpflug = true;
            }
        }
        else if (jumpflug)
        {
            if (!execution)
            {
                During_Jump();
            }
        }
    }

    void During_Jump()
    {
        body.AddForce(Vector3.up * jump_power);
        execution = true;
        nowtime = 0.0f;
    }

    void Attack()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        jumpflug = false;
        execution = false;
    }

}
