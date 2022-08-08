using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject Electric;
    public Text text;
    public bool Contact = false;

    public void ElectricState()
    {
        if(Electric.activeSelf == false)
        {
            text.GetComponent<Text>().text = "��ȣ�� ������ �ʴ´�... ���� ������ ������Ű��.";
            StartCoroutine(TextOut());
        }
        else
        {
            text.GetComponent<Text>().text = "��ȣ�� ������! ������û�� �����߰ڴ�.";
            Contact = true;
            StartCoroutine(HelpTest());
        }
    }

    IEnumerator HelpTest()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "������� : ������ �ش���ġ�� ��⸦ �����ڽ��ϴ�.";
        StartCoroutine(Go1F());
    }
    IEnumerator Go1F()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "���� ���������͸� Ÿ�� Ż������!";
        StartCoroutine(TextOut());
    }
    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }
}
