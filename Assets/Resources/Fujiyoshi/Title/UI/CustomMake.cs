using UnityEngine;
using System.Collections;
using DG.Tweening;
public class CustomMake : MonoBehaviour {
    public bool isActive = true;
    public bool isProduction;
    float production_time = 0;
    // Use this for initialization
    void Start () {
        transform.DOScale(new Vector3(1, 1, 1),0.5f).SetEase(Ease.OutBack);
        isActive = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!isActive)
        {
            transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutBack);
            production_time += Time.deltaTime;
            if (production_time >= 0)
            {
                isProduction = false;
                production_time = 0;
                isActive = true;
                gameObject.SetActive(isProduction);
            }
        }else
        {
            transform.DOScale(new Vector3(1, 1, 1),0.5f).SetEase(Ease.OutBack);
        }
    }
}
