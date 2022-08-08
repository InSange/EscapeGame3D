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
            text.GetComponent<Text>().text = "���������Ϳ� ������ ������ �ȵǴ� �� ����. ������ ��ġ�� ���ƿͺ���";
            StartCoroutine(TextOut());
        }
        else
        {
            if(Phone.GetComponent<Phone>().Contact)
            {
                text.GetComponent<Text>().text = "���� ������ ������ ���� �������� Ż������!";
                Player.player.currentMapName = Player.player.transferMapName;
                StartCoroutine(GoFactory());
            }
            else
            {
                text.GetComponent<Text>().text = "�������� �ö󰡱����� ���� ������û��������!";
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
