using UnityEngine;
using System.Collections;

public class gameman : MonoBehaviour
{

    public bool win;

    public bool lose;

    public bool end;

    [SerializeField]
    private int Hp = 500;

    public int Player_hp
    {
        get { return Hp; }
        set { Hp = value; }
    }

    timer time;

    void Awake()
    {
        time = GameObject.Find("Timer").GetComponent<timer>();
        end = false;
        win = false;
        lose = false;
    }

	void Start ()
    {
        
	}
	
	
	void Update ()
    {
        gameover();
        clear();
	}

    void gameover()
    {
        if(Hp <= 0)
        {
            lose = true;
            end = true;
        }
    }

    void clear()
    {
        if(time.countTimer < 0.0f)
        {
            win = true;
            end = true;
        } 
    }
}
