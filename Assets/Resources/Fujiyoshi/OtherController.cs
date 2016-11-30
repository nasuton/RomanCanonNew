using UnityEngine;
using System.Collections;

public class OtherController : MonoBehaviour
{
    private bool otherEnter = false;
    public bool OtherEnter
    {
        get { return otherEnter; }
    }


    void Control()
    {
        if (otherEnter == false)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.localEulerAngles += new Vector3(0, -0.5f, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.localEulerAngles += new Vector3(0, 0.5f, 0);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            otherEnter = true;
        }
        Control();
    }
}
