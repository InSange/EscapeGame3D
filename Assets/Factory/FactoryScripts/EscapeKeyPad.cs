using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeKeyPad : MonoBehaviour
{
    public GameObject keyDoor;
    public GameObject Fuse1;
    public GameObject Fuse2;

    public void OpenKeyDoor()
    {
        keyDoor.transform.GetComponent<EscapeDoor>().ChangeDoorState();
    }
}
