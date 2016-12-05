using UnityEngine;
using System.Collections;

public class test_enemystate : MonoBehaviour
{
    public bool get_together;

    Vector3 t;

    float speed = 1.5f;

    float time_de;

    void Start()
    {
        get_together = false;
    }

    void Update()
    {
        if(get_together)
        {
            Quaternion targetRotation = Quaternion.LookRotation(t - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collect>() == null) return;

        get_together = true;

        t = other.gameObject.GetComponent<Collect>().traget;

        time_de = other.gameObject.GetComponent<Collect>().destroyTime;

        StartCoroutine("change", time_de);
    }

    IEnumerator change(float time)
    {
        yield return new WaitForSeconds(time);

        get_together = false;
    }
}
