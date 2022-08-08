using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject P;
    public GameObject StartButton;

    public void HideToPlay()
    {
        this.gameObject.SetActive(false);
        StartButton.SetActive(false);
        P.transform.GetComponent<StartPlayer>().enabled = true;
        P.transform.GetComponent<StartPlayer>().mouseCursor();
    }
}
