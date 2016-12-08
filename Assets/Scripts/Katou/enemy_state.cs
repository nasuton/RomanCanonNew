using UnityEngine;
using System.Collections;


//Enemyが共通でもっているもの
//Score Hp 無敵時間

public class enemy_state : MonoBehaviour
{
    public bool isDed;

    public bool get_together;

    private int hp = 10;

    private int attack;

    float time_de;

    public GameObject effect;

    bool isInvincible = false;

    float invincibleTime = 0.0f;

    [SerializeField]
    float maxInvincibleTime = 1.0f;

    gameman gamemain;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    [SerializeField]
    private int scorePoint = 10;

    public int ScorePoint
    {
        get { return scorePoint; }
        set { scorePoint = value; }
    }

    void Start()
    {
        isDed = false;
        gamemain = GameObject.Find("gamemanager").GetComponent<gameman>();
    }

    void Update()
    {
        if(gamemain.end == true)
        {
            Destroy(gameObject);
        }

        if (isInvincible == true)
        {
            invincibleTime += Time.deltaTime;

            if (invincibleTime > maxInvincibleTime)
            {
                isInvincible = false;
                invincibleTime = 0.0f;
            }
        }

        if (get_together)
        {

        }

        if (hp > 0) return;
        //GameObject.Instantiate(effect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        isDed = true;
        Destroy(this.gameObject);
        GameObject.Find("ScoreManager").GetComponent<score>().ScoreValue += scorePoint;
        GameObject.Find("ScoreUI").GetComponent<score_notation>().Add_Score();
        GameObject.Find("RomanBar").GetComponent<RomanGauge>().chargeRomenGaouge(10);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletDamege>() == null) return;
        if (isInvincible == true) return;

        isInvincible = true;
        hp -= (int)other.gameObject.GetComponent<BulletDamege>().Damege;

        if (other.gameObject.GetComponent<Collect>() == null) return;

        get_together = true;

        //t = other.gameObject.GetComponent<Collect>().traget;

        time_de = other.gameObject.GetComponent<Collect>().destroyTime;

        StartCoroutine("change", time_de);
    }

    void OnTriggerStay(Collider other)
    {

    }

    IEnumerator change(float time)
    {
        yield return new WaitForSeconds(time);

        get_together = false;
    }

}
