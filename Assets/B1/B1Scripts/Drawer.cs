using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    bool Open = false;
    Vector3 OpenLength = new Vector3(0, 0, 0.4f);

    public void OpenDrawer()
    {
        if(!Open)
        {
            Open = !Open;
            //transform.position += OpenLength;
            transform.Translate(0, 0, 0.4f);
        }
        else
        {
            Open = !Open;
            transform.Translate(0, 0, -0.4f);
        }
    }
}
