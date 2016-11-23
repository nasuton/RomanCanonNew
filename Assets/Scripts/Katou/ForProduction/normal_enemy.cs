using UnityEngine;
using System.Collections;


//基本となるエネミー(エネミー1)
public class normal_enemy : MonoBehaviour
{
    private Vector3 target;

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private int add_score = 10;

    enemy_state state;

    [SerializeField]
    private int maxhp = 100;

    void Start ()
    {
        target = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
        state = GetComponent<enemy_state>();
        state.Hp = maxhp;
    }
	
	void Update ()
    {
        if (state.isDed) return;

        Move();
    }

    void Move()
    {
        Quaternion targetrotation = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
