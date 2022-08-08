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
            text.GetComponent<Text>().text = "������ �� ������ �� ����...! ���� Ż�ⱸ�� ã�ƺ���.";
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
