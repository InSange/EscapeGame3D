using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Camera mainCamera;
    Vector3 cameraPos;

    //https://ncube-studio.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%B9%B4%EB%A9%94%EB%9D%BC-%ED%9D%94%EB%93%A4%EA%B8%B0%EC%89%90%EC%9D%B4%ED%81%AC-%ED%9A%A8%EA%B3%BC-%EA%B5%AC%ED%98%84-%EC%A7%80%EC%A7%84-%ED%8F%AD%EB%B0%9C-%EC%8A%88%ED%8C%85%EC%8B%9C-%EC%9C%A0%EC%9A%A9%ED%95%9C-%ED%9A%A8%EA%B3%BC-Unity-C-ScriptCamera-Shake-Invoke-InvokeRepeating
    [SerializeField] [Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField] [Range(0.1f, 1f)] float duration = 2.0f;

    public void Shake()
    {
        cameraPos = mainCamera.transform.position;
        Player.player.transform.GetComponent<Player>().enabled = false;
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
        Player.player.transform.GetComponent<Player>().enabled = true;
        mainCamera.transform.position = cameraPos;
    }
}
