using UnityEngine;
using System.Collections;


//Enemyが共通でもっているもの
//Score Hp 無敵時間

public class enemy_state : MonoBehaviour
{
    public bool isDed;

    public bool get_together;

    float time_de;

    bool isInvincible = false;

    float invincibleTime = 0.0f;

    [SerializeField]
    float maxInvincibleTime = 1.0f;

    gameman gamemain;

    [SerializeField]
    public GameObject score;

    //new AudioSource audio;

    //[SerializeField,Tooltip("死んだとき")]
    //private AudioClip die_clip;

    //[SerializeField, Tooltip("攻撃したとき")]
    //private AudioClip attack_clip;

    //[SerializeField, Tooltip("攻撃が当たった時")]
    //private AudioClip hit_clip;

    //[SerializeField, Tooltip("攻撃があったた時のエフェクト")]
    //private GameObject hit_effect;

    //[SerializeField, Tooltip("死ぬ時のエフェクト")]
    //private GameObject die_effect;

    [SerializeField]
    private int hp;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    private int power;

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    float interval;

    [SerializeField]
    private int scorePoint = 10;

    public int ScorePoint
    {
        get { return scorePoint; }
        set { scorePoint = value; }
    }

    float damage;

    Vector3 t;

    void Start()
    {
        isDed = false;
        gamemain = GameObject.Find("gamemanager").GetComponent<gameman>();
        interval = 0.0f;
        //audio = GetComponent<AudioSource>();
        damage = 0.0f;
    }

    void Update()
    {
        if(gamemain.end == true)
        {
            //Instantiate(die_effect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
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
            Quaternion targetRotation = Quaternion.LookRotation(t - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

            transform.Translate(Vector3.forward * 0.1f *Time.deltaTime);
        }

        if (hp > 0) return;
        isDed = true;
        //audio.clip = die_clip;
        //audio.Play();
        //Instantiate(die_effect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        Destroy(this.gameObject);
        GameObject.Find("ScoreManager").GetComponent<score>().ScoreValue += scorePoint;
        score.GetComponent<score_notation>().Add_Score();
        GameObject.Find("RomanBar").GetComponent<RomanGauge>().chargeRomenGaouge(10);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletDamege>() == null) return;
        if (isInvincible == true) return;

        isInvincible = true;
        hp -= (int)other.gameObject.GetComponent<BulletDamege>().Damege;

        //audio.clip = hit_clip;
        //audio.Play();
    }

    void OnTriggerStay(Collider other)
    {
        hp -= (int)other.gameObject.GetComponent<BulletDamege>().Damege;

        if (other.gameObject.GetComponent<Collect>() == null) return;

        get_together = true;

        hp -= (int)other.gameObject.GetComponent<Collect>().Collect_Damage;

        t = other.gameObject.GetComponent<Collect>().traget;

        time_de = other.gameObject.GetComponent<Collect>().destroyTime;

        StartCoroutine("change", time_de);
    }

    IEnumerator change(float time)
    {
        yield return new WaitForSeconds(time);

        hp -= (int)damage;

        get_together = false;
    }

    public void Attack(float attack_interval)
    {
        interval += Time.deltaTime;
        if(attack_interval <= interval)
        {
            //audio.clip = attack_clip;
            //audio.Play();
            gamemain.Player_hp -= power;
            interval = 0.0f;
        }
    }

}
