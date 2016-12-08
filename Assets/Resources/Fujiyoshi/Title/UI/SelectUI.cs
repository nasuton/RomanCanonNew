using UnityEngine;
using System.Collections;
using DG.Tweening;
public class SelectUI : MonoBehaviour {

    private Vector3 default_scale;
    public bool isActive;
    private bool isProduction;
    public bool isSelected;
    public float production_time;
    void Awake()
    {
        isActive = true;
        isSelected = false;
    }

    void Update()
    {
        if ((int)production_time == 0)
        {
            if (isActive == false)
            {
                default_scale = this.transform.localScale;
                this.transform.localScale = new Vector3(default_scale.x * 1.5f, default_scale.y * 1.5f, default_scale.z);
                transform.DOScale(new Vector3(default_scale.x, default_scale.y, default_scale.z), 0.1f).SetEase(Ease.InSine);
                isActive = true;
                isSelected = true;
                isProduction = true;
            }
        }
        if (isProduction)
        {
            production_time += Time.deltaTime * 100;
            if (production_time >= 10)
            {
                isProduction = false;
                production_time = 0;
            }
        }
    }
}
