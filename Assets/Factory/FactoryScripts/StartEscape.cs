using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartEscape : MonoBehaviour
{
    public GameObject text;
    public GameObject EscapeTime;

    private void Awake()
    {
        text = GameObject.Find("Text");
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" && this.gameObject.name == "StartEscape")
        {
            text.GetComponent<Text>().text = "공장이 곧 무너질 것 같다...! 빨리 탈출구를 찾아보자.";
            EscapeTime.SetActive(true);
            Player.player.ShakeWindow();
            SoundManager.SM.PlaySound("Boom");
            StartCoroutine(TextOut());
        }
        else if (other.gameObject.tag == "Player" && this.gameObject.name == "Boom")
        {
            text.GetComponent<Text>().text = "!!";
            Player.player.ShakeWindow();
            SoundManager.SM.PlaySound("Boom");
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
