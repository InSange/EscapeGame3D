using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public Image image;
    public Button button;

    public void MainMenuFadeOut()
    {
        image.gameObject.SetActive(true);
        Debug.Log("실행");
        StartCoroutine(MainMenuFadeOutStart());
    }

    public void GameOverFadeOut()
    {
        image.gameObject.SetActive(true);
        Debug.Log("실행");
        StartCoroutine(GameOverFadeOutStart());
    }

    public void GoMainMenu()
    {
        Destroy(Player.player.gameObject);
        Destroy(UIManager.UIcanvas.gameObject);
        Destroy(SoundManager.SM.gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public void GameExit()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

    IEnumerator MainMenuFadeOutStart()
    {
        float fadetime = 0f;
        while (fadetime < 1.0f)
        {
            //Debug.Log(fadetime);
            fadetime += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadetime);
        }
        Player.player = null;
        UIManager.UIcanvas = null;
        SoundManager.SM = null;
        SceneManager.LoadScene("Dream");
    }

    IEnumerator GameOverFadeOutStart()
    {
        float fadetime = 0f;
        while (fadetime < 1.0f)
        {
            //Debug.Log(fadetime);
            fadetime += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(255, 255, 255, fadetime);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        button.gameObject.SetActive(true);
    }
}
