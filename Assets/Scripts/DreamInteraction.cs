using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamInteraction : MonoBehaviour
{
    public Text text;
    public int messageCount = 0;
    public GameObject player;

    public Camera mainCamera;
    Vector3 cameraPos;

    //https://ncube-studio.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%B9%B4%EB%A9%94%EB%9D%BC-%ED%9D%94%EB%93%A4%EA%B8%B0%EC%89%90%EC%9D%B4%ED%81%AC-%ED%9A%A8%EA%B3%BC-%EA%B5%AC%ED%98%84-%EC%A7%80%EC%A7%84-%ED%8F%AD%EB%B0%9C-%EC%8A%88%ED%8C%85%EC%8B%9C-%EC%9C%A0%EC%9A%A9%ED%95%9C-%ED%9A%A8%EA%B3%BC-Unity-C-ScriptCamera-Shake-Invoke-InvokeRepeating
    [SerializeField] [Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField] [Range(0.1f, 1f)] float duration = 2.0f;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            message();
        }
    }

    void message()
    {
        if (messageCount == 0)
        {
            text.GetComponent<Text>().text = "2년전 영문도 모른채 나는 납치되어 이름모를 연구소에 오게되었다...";
            messageCount += 1;
            StartCoroutine(NextText());
        }
        else if(messageCount == 1)
        {
            text.GetComponent<Text>().text = "아마 이 꿈에서 깨게되면은 여느때와 같이 실험을 당하게 되겠지...";
            messageCount += 1;
            StartCoroutine(NextText());
        }
        else if (messageCount == 2)
        {
            text.GetComponent<Text>().text = "!!!";
            player.transform.GetComponent<StartPlayer>().enabled = false;
            Shake();
            messageCount += 1;
            StartCoroutine(NextText());
        }
        else if (messageCount == 3)
        {
            player.transform.GetComponent<StartPlayer>().enabled = true;
            text.GetComponent<Text>().text = "무슨 일이 있는건가? ( 문을 클릭하며 꿈에서 나가자! )";
            StartCoroutine(TextOut());
        }
    }

    IEnumerator NextText()
    {
        yield return new WaitForSeconds(2.0f);
        message();
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(2.0f);
        text.GetComponent<Text>().text = "";
    }

    public void Shake()
    {
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", duration);
    }

    void StartShake()
    {
        float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
        float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x += cameraPosX;
        cameraPos.y += cameraPosY;
        mainCamera.transform.position = cameraPos;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = cameraPos;
    }
}
