using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score_notation : MonoBehaviour {
    
    //描画する用のクラスです
    [SerializeField]
    GameObject Text;
   

	void Start ()
    {
        GetComponent<TextMesh>().text = Text.GetComponent<score>().ScoreValue.ToString();
    }
	
	void Update ()
    {
        GetComponent<TextMesh>().text = Text.GetComponent<score>().ScoreValue.ToString();
    }

    //スコアを追加する際に、呼べば表示も変わる
    public void Add_Score()
    {
        //GetComponent<TextMesh>().text = Text.GetComponent<score>().ScoreValue.ToString();
    }
}
