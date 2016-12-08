using UnityEngine;
using System.Collections;

//スピードが速いタイプ(エネミー2)
public class speed_enemy : MonoBehaviour
{ 
    private Vector3 target;

    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private int add_score = 20;

    enemy_state state;

    [SerializeField]
    private int maxhp = 75;

    [SerializeField]
    private int maxattack;

    [SerializeField]
    private float angle = 90.0f;

    float angleDir;
    bool nexttarget;
    float nexttime;
    float nowtime;

    void Start ()
    {
        target = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
        angleDir = GameObject.Find("Spawner").GetComponent<spawner_cs>().inversion;
        state = GetComponent<enemy_state>();
        state.Hp = maxhp;
        state.Attack = maxattack;
        nexttarget = false;
        nexttime = 0.0f;
        nowtime = 0.0f;
        angleDir = transform.localEulerAngles.y - 90.0f;
    }
	
	void Update ()
    {
        if (state.isDed) return;

        Move();
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
