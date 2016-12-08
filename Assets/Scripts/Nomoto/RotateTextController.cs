using UnityEngine;
using System.Collections;
using DG.Tweening;
public class RotateTextController : MonoBehaviour
{
    private string text;

    string temp;

    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    //半径
    public float radius = 10;
    //回転させるための角度
    public float offsetAngle;

    private int point;

    private float active_time = 0;

    void Start()
    {
        score scoreManager = GameObject.Find("ScoreManager").GetComponent<score>();

        point = scoreManager.ScoreValue;

        point += 1234567890;

        Make("The end of the competition!! SCORE " + point.ToString() + "!! ");
        radius = 10.0f;
    }

    void Update()
    {
        Arrange();
        offsetAngle += 80.0f * Time.deltaTime;
        sceneChange();
    }

    [SerializeField]
    GameObject textObject = null;

    [SerializeField]
    GameObject backUI = null;

    private void Make(string str)
    {
        text = "";

        for (int i = str.Length - 1; i >= 0; --i)
        {
            temp += str[i].ToString();
        }

        str = temp;

        for (int i = 0; i < str.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(textObject, transform) as GameObject;
            obj.GetComponent<TextMesh>().text = str[i].ToString();
            obj.transform.localScale = new Vector3(1,0,1);
            obj.transform.DOScaleY(1, 1).SetEase(Ease.OutElastic);
            GameObject UI = GameObject.Instantiate(backUI, obj.transform) as GameObject;
            UI.transform.localPosition = new Vector3(0, -0.6f,0.5f);
        }
    }

    void Arrange()
    {
        float splitAngle = 360 / transform.childCount + 0.44f;
        var rect = transform;

        for (int elementId = 0; elementId < transform.childCount; elementId++)
        {
            var child = transform.GetChild(elementId);
            float currentAngle = splitAngle * elementId + offsetAngle;
            child.position = new Vector3(
                Mathf.Cos(currentAngle * Mathf.Deg2Rad), transform.position.y,
                Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * radius;
            child.LookAt(transform);
            child.Rotate(new Vector3(0, 180, 0));
        }
    }

    void sceneChange()
    {
        active_time += Time.deltaTime;
        if(active_time >= 10)
        {
            SceneChanger.Instance.LoadLevel("Title", 1.0f);
        }
    }
}
