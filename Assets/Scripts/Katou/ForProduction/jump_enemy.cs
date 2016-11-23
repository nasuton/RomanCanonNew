using UnityEngine;
using System.Collections;

public class jump_enemy : MonoBehaviour
{

    private Vector3 target;

    [SerializeField]
    private float speed = 2.5f;

    [SerializeField]
    private int add_score = 40;

    enemy_state state;

    [SerializeField]
    private int maxhp = 25;

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
        Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
