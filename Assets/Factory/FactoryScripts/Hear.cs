using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hear : MonoBehaviour
{
    public GameObject text;

    private void Awake()
    {
        text = GameObject.Find("Text");
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.SM.PlaySound("helicopter");
            text.GetComponent<Text>().text = "헬기소리가 들린다. 근처에 헬기가 있는것같다..!";
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
