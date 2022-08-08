using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{ 
    public GameObject battery;
    public Text text;


    public void GeneratorState()
    {
        if (battery.activeSelf == false)
        {
            text.GetComponent<Text>().text = "���͸��� ���� �� ����. ���͸��� ã�ƺ���.";
            StartCoroutine(TextOut());
        }
        else
        {
            text.GetComponent<Text>().text = "�̹� ���͸��� �־���.";
            StartCoroutine(TextOut());
        }
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }
}
