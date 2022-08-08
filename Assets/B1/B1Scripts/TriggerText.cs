using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TriggerText : MonoBehaviour
{
    public GameObject text;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.name== "B1StartMessage")
        {
            text.GetComponent<Text>().text = "카메라에 불빛이 안들어오는 걸 보아하니 무슨 일이 있는것같다! 문을 열어보자";
            StartCoroutine(TextOut());
        }
        else if (other.gameObject.tag == "Player" && this.gameObject.name == "CheckDOG")
        {
            text.GetComponent<Text>().text = "좀비개다... 앞이 안보이니 발소리를 줄여서가자. (shift누르고 움직일시 발소리가 작아진다.)";
            StartCoroutine(TextOut());
        }
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
        this.gameObject.SetActive(false);
    }
}
