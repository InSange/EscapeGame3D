using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    public bool open = false;
    public void ChangeDoorState()
    {
        if (!open)
        {
            transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
            open = !open;
            StartCoroutine(DoorClose());
        }
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        open = !open;
    }
}
