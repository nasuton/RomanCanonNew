using UnityEngine;
using System.Collections;

//ステージを回転させるスクリプトです
public class stage_rotation : MonoBehaviour
{
    bool roteto;

	void Start ()
    {
        float rotato = Random.Range(0.0f, 360.0f);
        transform.Rotate(0.0f, rotato, 0.0f);
        StartCoroutine("", 2.0f);

    }

    IEnumerator stage_rote(float time)
    {
        yield return new WaitForSeconds(time);

    }
}
