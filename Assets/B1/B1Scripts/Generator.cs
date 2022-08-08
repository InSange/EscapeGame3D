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
            text.GetComponent<Text>().text = "배터리가 없는 것 같다. 배터리를 찾아보자.";
            StartCoroutine(TextOut());
        }
        else
        {
            text.GetComponent<Text>().text = "이미 배터리를 넣었다.";
            StartCoroutine(TextOut());
        }
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }
}
