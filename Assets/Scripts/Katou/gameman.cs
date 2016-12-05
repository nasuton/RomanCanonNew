using UnityEngine;
using System.Collections;

public class gameman : MonoBehaviour
{

    public bool win;

    public bool lose;

    public bool end;

    [SerializeField]
    private int playerHp = 500;

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
        if(playerHp <= 0)
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
