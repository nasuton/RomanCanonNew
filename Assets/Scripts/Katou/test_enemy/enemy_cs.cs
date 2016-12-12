using UnityEngine;
using System.Collections;

public class enemy_cs : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private int attack;

    [SerializeField]
    private float attack_interval;

    Vector3 playerPos;

    test_enemystate state;

    void Start()
    {
        state = GetComponent<test_enemystate>();
        state.Atteck = attack;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerPos, transform.position);

        if(distance <= 10.0f)
        {
            state.Attack(attack_interval);
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Attack()
    {

    }

}
