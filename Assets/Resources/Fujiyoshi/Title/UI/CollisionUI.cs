using UnityEngine;
using System.Collections;
using DG.Tweening;
public class CollisionUI : MonoBehaviour
{
    private Vector3 default_scale;
    public bool isActive;
    public bool isProduction;
    public float production_time;
    void Awake()
    {
        isActive = true;
        isProduction = false;
        production_time = 0.0f;
    }
   
    void Update()
    {
        if (isActive == false)
        {
            default_scale = this.transform.localScale;
            this.transform.localScale = new Vector3(default_scale.x * 1.5f, default_scale.y * 1.5f, default_scale.z);
            transform.DOScale(new Vector3(default_scale.x, default_scale.y, default_scale.z), 0.1f).SetEase(Ease.InSine);
            isActive = true;
            isProduction = true;
        }
        if (isProduction)
        {
            production_time += Time.deltaTime;
            if (production_time >= 0.1f)
            {
                isProduction = false;
                production_time = 0;
                gameObject.SetActive(isProduction);
            }
        }
    }

}
