using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorControll : MonoBehaviour
{
    public Text text;
    public GameObject generator1;
    public GameObject generator2;
    public GameObject generator3;
    public GameObject generator4;
    public GameObject generator5;
    public GameObject generator6;
    public GameObject Electric;
    public GameObject Fires;
    public GameObject Dog;

    public GameObject[] LightObj;

    public void GeneratorControllState()
    {
        if(generator1.transform.GetComponent<Generator>().battery.activeSelf && generator2.transform.GetComponent<Generator>().battery.activeSelf
            && generator3.transform.GetComponent<Generator>().battery.activeSelf && generator4.transform.GetComponent<Generator>().battery.activeSelf
            && generator5.transform.GetComponent<Generator>().battery.activeSelf && generator6.transform.GetComponent<Generator>().battery.activeSelf)
        {
            Electric.SetActive(true);
            for( int i = 0; i < LightObj.Length; i++)
            {
                LightObj[i].GetComponent<Light>().enabled = true;
            }
            Fires.SetActive(true);
            //text.GetComponent<Text>().text = "연구소에 전력이 돌아왔다!";
            SoundManager.SM.PlaySound("Boom");
            Player.player.ShakeWindow();
            //StartCoroutine(TextOut());
            text.GetComponent<Text>().text = "중앙홀에서 무슨일이 생긴 것 같다.";
            Dog.SetActive(false);
            StartCoroutine(TextOut());
        }
        else
        {
            text.GetComponent<Text>().text = "모든 발전기에 배터리가 끼워져있지 않은 것 같다.";
            StartCoroutine(TextOut());
        }
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }
}
