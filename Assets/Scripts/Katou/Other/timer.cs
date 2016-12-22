using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField]
    private float max_Count = 40.0f;

    public float countTimer;

    void Awake()
    {
        countTimer = max_Count;
    }

    void Update()
    {
        if (0.0f >= countTimer)
        {
            countTimer = 0;

            GetComponent<TextMesh>().text = "Time " + countTimer.ToString("F0");
        }
        else
        {
            countTimer -= Time.deltaTime;

            GetComponent<TextMesh>().text = "Time " + countTimer.ToString("F0");
        }

    }

}
