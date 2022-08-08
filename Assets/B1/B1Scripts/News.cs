using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class News : MonoBehaviour
{
    public GameObject newsButton;
    public GameObject newsLetter;
    public GameObject CheckButton;

    public void OnNewsButton()
    {
        Player.player.rotCtr = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        newsButton.SetActive(true);
    }

    public void OnNewsLetter()
    {
        newsButton.SetActive(false);
        newsLetter.SetActive(true);
        CheckButton.SetActive(true);
    }

    public void CheckNews()
    {
        newsLetter.SetActive(false);
        CheckButton.SetActive(false);
        Player.player.rotCtr = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void close()
    {
        Player.player.rotCtr = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        newsButton.SetActive(false);
    }
}