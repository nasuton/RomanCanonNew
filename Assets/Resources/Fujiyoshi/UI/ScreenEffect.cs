using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class ScreenEffect : MonoBehaviour {
    

    float alpha = 0;
    float a;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        a+=4;
        alpha = (float)Math.Sin(a * (Math.PI / 180));
        if (alpha >= 0)
        {
            this.GetComponent<Image>().color = new Color(255, 255, 255, alpha*1.2f);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(255, 255, 255, -alpha * 1.2f);
        }
    }
}
