using UnityEngine;
using System.Collections;

//ボスです
public class boss_cs : MonoBehaviour
{

    private Vector3 player;

    [SerializeField]
    private float speed = 3.5f;

    //加算するスコア
    [SerializeField]
    private int add_score = 50;

    enemy_state state;

    //体力
    [SerializeField]
    private int maxhp = 800;

    //攻撃力
    [SerializeField]
    private int maxpower;

    //攻撃するまでの間隔
    [SerializeField]
    private float interval;

    void Start()
    {
        player = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
        state = GetComponent<enemy_state>();
        state.Hp = maxhp;
        state.Power = maxpower;
    }

    void Update()
    {
        if (state.isDed == true) return;
        if (state.get_together == true) return;

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
        Quaternion targetRotation = Quaternion.LookRotation(player - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Attack()
    {

    }

}
