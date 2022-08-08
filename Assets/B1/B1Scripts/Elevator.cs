using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public GameObject Electric;
    public Text text;
    public GameObject Phone;

    public void ElevatorStatus()
    {
        if(Electric.activeSelf == false)
        {
            text.GetComponent<Text>().text = "엘리베이터에 전력이 공급이 안되는 것 같다. 전력을 고치고 돌아와보자";
            StartCoroutine(TextOut());
        }
        else
        {
            if(Phone.GetComponent<Phone>().Contact)
            {
                text.GetComponent<Text>().text = "좋아 연락도 했으니 이제 지상으로 탈출하자!";
                Player.player.currentMapName = Player.player.transferMapName;
                StartCoroutine(GoFactory());
            }
            else
            {
                text.GetComponent<Text>().text = "지상으로 올라가기전에 먼저 구조요청부터하자!";
                StartCoroutine(TextOut());
            }
        }
    }
    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }

    IEnumerator GoFactory()
    {
        yield return new WaitForSeconds(1.5f);
        text.GetComponent<Text>().text = "";
        SceneManager.LoadScene(Player.player.transferMapName);
    }
}
