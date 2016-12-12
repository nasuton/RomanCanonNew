using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class StatusProduction : MonoBehaviour {
    public int max_value = 100;

    [SerializeField]
    GameObject normal_bar;

    [SerializeField]
    GameObject down_bar;

    [SerializeField]
    GameObject up_bar;

    public float next_value;

    private float now_value = 0;

    private bool isProduction = false;
    // Use this for initialization
    void Start () {
        up_bar.GetComponent<Image>().fillAmount = 0;
        down_bar.GetComponent<Image>().fillAmount = 0;
        normal_bar.GetComponent<Image>().fillAmount = 0;
    }
    public void changeStatus()
    {
        if (now_value >= next_value)
        {
            up_bar.GetComponent<Image>().fillAmount = 0;
            normal_bar.GetComponent<Image>().fillAmount = next_value / max_value;
            DOTween.To(() => down_bar.GetComponent<Image>().fillAmount, x => down_bar.GetComponent<Image>().fillAmount = x, next_value/max_value, 1f);
        }
        else if (now_value < next_value)
        {
            down_bar.GetComponent<Image>().fillAmount = 0;
            up_bar.GetComponent<Image>().fillAmount = next_value / max_value;
            DOTween.To(() => normal_bar.GetComponent<Image>().fillAmount, x => normal_bar.GetComponent<Image>().fillAmount = x, next_value / max_value, 1f);
        }
    }
	// Update is called once per frame
	void Update () {
        now_value = next_value;
    }
}
