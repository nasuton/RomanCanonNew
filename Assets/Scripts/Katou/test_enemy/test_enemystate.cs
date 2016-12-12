using UnityEngine;
using System.Collections;

public class test_enemystate : MonoBehaviour
{
    float interval;

    gameman gamemain;

    private int power;

    Vector3 target;

    bool together;

    public int Atteck
    {
        get
        {
            return power;
        }
        set
        {
            power = value;
        }
    }

    void Start()
    {
        gamemain = GameObject.Find("gamemanager").GetComponent<gameman>();
        interval = 0.0f;
    }

    void Update()
    {
        if(gamemain.end == true)
        {
            Destroy(gameObject);
        }

        if(together)
        {
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collect>() == null) return;
        target = other.gameObject.GetComponent<Collect>().traget;
        together = true;
    }

    public void Attack(float attack_interval)
    {
        interval += Time.deltaTime;
        if(attack_interval <= interval)
        {
            gamemain.Player_hp -= power;
            interval = 0.0f;
        }
    }

}
