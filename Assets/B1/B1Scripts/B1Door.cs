using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1Door : MonoBehaviour
{
    public bool open = false;
    //public float doorOpenAngle = 90f;
    //public float doorCloseAngle = 0f;
    public float smoot = 3f;

    public void ChangeDoorState()
    {
        if (!open)
        {
            /*
            Vector3 b = new Vector3(transform.position.x, 2.8f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, b, smoot);
            */
            transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z);
            open = !open;
            StartCoroutine(DoorClose());
        }
        /*
        else
        {
          
            ///Vector3 b = new Vector3(transform.position.x, 0.0f, transform.position.z);
            ///transform.position = Vector3.Lerp(transform.position, b, smoot);
     
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
            open = !open;
        }
        */
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        open = !open;
    }

    /*
    void Update()
    {
        if(open)
        {
            //Quaternion targetRotation = Quaternion.Euler(-90.0f, doorOpenAngle, -180.0f);
            //transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
            Vector3 b = new Vector3(transform.position.x, 2.8f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, b, smoot );
        }
        else
        {
            //Quaternion targetRotation2 = Quaternion.Euler(-90.0f, doorCloseAngle, -180.0f);
            //transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
        }
    }
    */
}