using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeTime : MonoBehaviour
{
    public Text Timer;
    // ��ü ���� �ð��� �������ش�. ���⼭�� 180��.
    float setTime = 120;

    // ����
    bool stop = true;

    // �д����� �ʴ����� ����� ������ ������ش�.
    int min;
    float sec;
    void Update()
    {
        Debug.Log("���� üũ : " + true);
        if (stop == true)
        {
            // ���� �ð��� ���ҽ����ش�.
            setTime -= Time.deltaTime;

            // ��ü �ð��� 60�� ���� Ŭ ��
            if (setTime >= 60f)
            {
                // 60���� ������ ����� ���� �д����� ����
                min = (int)setTime / 60;
                // 60���� ������ ����� �������� �ʴ����� ����
                sec = setTime % 60;
                // UI�� ǥ�����ش�
                Timer.text = "���� �ð� : " + min + "��" + (int)sec + "��";
            }
            else if (setTime < 60f && setTime > 0) // ��ü�ð��� 60�� �̸��� ��
            {
                // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
                Timer.text = "���� �ð� : " + (int)setTime + "��";
            }
            else if (setTime <= 0) // ���� �ð��� 0���� �۾��� ��
            {
                // UI �ؽ�Ʈ�� 0�ʷ� ������Ŵ.
                Debug.Log("�ð� �ƿ�");
                stop = false;
                Timer.text = "���� �ð� : 0��";
                Player.player.transform.GetComponent<Player>().enabled = false;
                UIManager.UIcanvas.GetComponent<FadeController>().GameOverFadeOut();
            }
        }
    }
}
