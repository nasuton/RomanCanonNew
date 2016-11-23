using UnityEngine;
using System.Collections;

//ボスです
public class boss_cs : MonoBehaviour
{

    private Vector3 player;

    [SerializeField]
    private float speed = 3.5f;

    [SerializeField]
    private int add_score = 50;

    enemy_state state;

    [SerializeField]
    private int maxhp = 800;

    void Start()
    {
        player = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
        state = GetComponent<enemy_state>();
        state.Hp = maxhp;
    }

    void Update()
    {
        if (state.isDed) return;

        //float e_p_dis = Vector3.Distance(transform.position, player);

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
