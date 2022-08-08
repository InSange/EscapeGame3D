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
            text.GetComponent<Text>().text = "신호가 잡히질 않는다... 먼저 전력을 복구시키자.";
            StartCoroutine(TextOut());
        }
        else
        {
            text.GetComponent<Text>().text = "신호가 잡혔다! 구조요청을 보내야겠다.";
            Contact = true;
            StartCoroutine(HelpTest());
        }
    }

    IEnumerator HelpTest()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "구조대원 : 현시점 해당위치로 헬기를 보내겠습니다.";
        StartCoroutine(Go1F());
    }
    IEnumerator Go1F()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "좋아 엘리베이터를 타고 탈출하자!";
        StartCoroutine(TextOut());
    }
    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }
}
