using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public GameObject keyDoor;

    public void OpenKeyDoor()
    {
        keyDoor.transform.GetComponent<B1Door>().ChangeDoorState();
    }
}
