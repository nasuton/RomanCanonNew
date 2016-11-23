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

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
