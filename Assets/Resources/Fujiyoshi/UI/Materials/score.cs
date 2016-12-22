using UnityEngine;
using DG.Tweening;

//ここではあくまでScoreを記録するだけ
//Scoreの描画は新しいクラスを作ること

public class score : MonoBehaviour
{
    private int scoreValue;

    private int continuous;

    public int ScoreValue
    {
        get { return scoreValue; }
        set { scoreValue = value;}
    }

    public int Continuous
    {
        get { return continuous; }
        set { continuous = value; }
    }

    float continuous_time;

    [SerializeField]
    private float reset_time;

    static GameObject _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        continuous_time = 0.0f;
        scoreValue = 0;
    }

    void Update()
    {
        continuous_time += Time.deltaTime;
        if(continuous_time >= reset_time)
        {
            continuous = 0;
        }
    }

    public void Continuous_Kill(int score)
    {
        continuous_time = 0.0f;
        if (continuous >= 10)
        {
            DOTween.To(() => ScoreValue, (x) => ScoreValue = x, ScoreValue + (score * 2), 0.5f);
        }
        else if(continuous >= 20)
        {
            DOTween.To(() => ScoreValue, (x) => ScoreValue = x, ScoreValue + (score * 3), 0.5f);
        }
        else if(continuous >= 30)
        {
            DOTween.To(() => ScoreValue, (x) => ScoreValue = x, ScoreValue + (score * 4), 0.5f);
        }
        else
        {
            DOTween.To(() => ScoreValue, (x) => ScoreValue = x, ScoreValue + score, 0.5f);
        }
    }

}
