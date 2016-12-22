using UnityEngine;
using System.Collections;

public class jump_enemy : MonoBehaviour
{
    private Vector3 target;

    private Vector3 player;

    [SerializeField]
    private float speed = 2.5f;

    //加算するスコア
    [SerializeField]
    private int add_score = 40;

    enemy_state state;

    //体力
    [SerializeField]
    private int maxhp = 25;

    //攻撃力
    [SerializeField]
    private int maxpower;

    //攻撃するまでの時間
    [SerializeField]
    private float interval;


    //--------以下のものは移動処理に使用--------------------//
    bool jumpflug;
    bool execution;

    Rigidbody body;

    //ジャンプする高さ
    [SerializeField]
    float jump_power;

    //ジャンプするまでの時間
    [SerializeField]
    private float maxtime = 2;

    float nowtime;

    void Start ()
    {
	    player = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
        state = GetComponent<enemy_state>();
        state.Hp = maxhp;
        state.Power = maxpower;
        jumpflug = false;
        execution = false;
        body = GetComponent<Rigidbody>();
        jump_power = 500.0f;
        nowtime = 0.0f;
    }
	
	void FixedUpdate()
    {
        if (state.isDed) return;
        if (state.get_together) return;

        float distance = Vector3.Distance(transform.position, player);

        if(distance <= 10.0f)
        {
            state.Attack(interval);
        }
        else
        {
            Move();
        }        
    }

    void Move()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

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

    void OnCollisionEnter(Collision collision)
    {
        jumpflug = false;
        execution = false;
    }

}
