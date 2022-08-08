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
            text.GetComponent<Text>().text = "ī�޶� �Һ��� �ȵ����� �� �����ϴ� ���� ���� �ִ°Ͱ���! ���� �����";
            StartCoroutine(TextOut());
        }
        else if (other.gameObject.tag == "Player" && this.gameObject.name == "CheckDOG")
        {
            text.GetComponent<Text>().text = "���񰳴�... ���� �Ⱥ��̴� �߼Ҹ��� �ٿ�������. (shift������ �����Ͻ� �߼Ҹ��� �۾�����.)";
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
