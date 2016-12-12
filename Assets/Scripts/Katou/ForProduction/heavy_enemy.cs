using UnityEngine;
using System.Collections;

//体力が高い、その分スピードが遅い(エネミー3)
public class heavy_enemy : MonoBehaviour
{
    private Vector3 target;

    private Vector3 player;

    [SerializeField]
    private float speed = 2.0f;

    //加算するスコア
    [SerializeField]
    private int add_score = 30;

    enemy_state state;

    //体力
    [SerializeField]
    private int maxhp = 300;

    //攻撃力
    [SerializeField]
    private int maxpower;

    //攻撃するまでの時間
    [SerializeField]
    private float interval;

    //-------------------------------以下のものは移動の使用--------------------//

    //動くときの角度
    [SerializeField]
    private float angle = 15;

    float angleDir;
    bool nexttarget;
    float nexttime;
    float nowtime;

    void Start ()
    {
        player = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
        angleDir = GameObject.Find("Spawner").GetComponent<spawner_cs>().inversion;
        state = GetComponent<enemy_state>();
        state.Hp = maxhp;
        state.Power = maxpower;
        nexttarget = false;
        nexttime = 0.0f;
        nowtime = 0.0f;
    }
	
	void Update ()
    {
        if (state.isDed == true) return;
        if (state.get_together == true) return;

        float distence = Vector3.Distance(transform.position, player);

        if (distence <= 10.0f)
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
        if (!nexttarget)
        {
            float kakudo = Random.Range(angleDir - (angle / 2), angleDir + (angle / 2));

            float radian = kakudo * Mathf.PI / 180.0f;

            nexttime = Random.Range(3, 5);

            float x1 = Mathf.Cos(radian) * nexttime + transform.position.x;
            float z1 = Mathf.Sin(radian) * nexttime + transform.position.z;

            target = new Vector3(x1, transform.position.y, z1);

            nexttarget = true;
        }
        else if (nexttarget)
        {
            nowtime += Time.deltaTime;

            Quaternion targetrotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, Time.deltaTime * 1.0f);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (nexttime <= nowtime)
            {
                nowtime = 0.0f;
                nexttarget = false;
            }
        }
    }

}
