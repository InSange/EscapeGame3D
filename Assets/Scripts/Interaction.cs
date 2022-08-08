using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Text text;
    public void P_Interaction()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Player.player.interactDistance))
        {
            if (hit.collider.CompareTag("Door")) // �� ��ȣ�ۿ�
            {
                //hit.collider.transform.parent.GetComponent<B1Door>().ChangeDoorState();
                hit.collider.transform.GetComponent<B1Door>().ChangeDoorState();
                SoundManager.SM.PlaySound("Door");
            }
            else if (hit.collider.CompareTag("DoorKeyPad"))
            {
                text.GetComponent<Text>().text = "ī��Ű�� ���� ���� ���� �� ����...";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("KeyPad1"))
            {
                if (transform.Find("Main Camera").Find("Items").GetChild(0).gameObject.activeSelf == true || transform.Find("Main Camera").Find("Items").GetChild(1).gameObject.activeSelf == true || transform.Find("Main Camera").Find("Items").GetChild(2).gameObject.activeSelf == true)
                {
                    hit.collider.transform.GetComponent<KeyPad>().OpenKeyDoor();
                    SoundManager.SM.PlaySound("Door");
                }
                else
                {
                    text.GetComponent<Text>().text = "ī��Ű�� �ʿ��� �� ����.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("KeyPad2"))
            {
                if (transform.Find("Main Camera").Find("Items").GetChild(1).gameObject.activeSelf == true || transform.Find("Main Camera").Find("Items").GetChild(2).gameObject.activeSelf == true)
                {
                    hit.collider.transform.GetComponent<KeyPad>().OpenKeyDoor();
                    SoundManager.SM.PlaySound("Door");
                }
                else
                {
                    text.GetComponent<Text>().text = "ī��Ű�� �ʿ��� �� ����.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("KeyPad3"))
            {
                if (transform.Find("Main Camera").Find("Items").GetChild(2).gameObject.activeSelf == true)
                {
                    hit.collider.transform.GetComponent<KeyPad>().OpenKeyDoor();
                    SoundManager.SM.PlaySound("Door");
                }
                else
                {
                    text.GetComponent<Text>().text = "ī��Ű�� �ʿ��� �� ����.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("Generator")) // ������ ��ȣ�ۿ�
            {
                if (Player.player.BatteryItem > 0)
                {
                    if (hit.collider.transform.GetComponent<Generator>().battery.activeSelf == false)
                    {
                        Player.player.BatteryItem -= 1;
                        hit.collider.transform.GetComponent<Generator>().battery.SetActive(true);
                        //hit.collider.transform.GetComponent<Generator>().GeneratorState();
                        text.GetComponent<Text>().text = "���͸��� �־���.";
                        StartCoroutine(TextOut());
                    }
                    else
                    {
                        hit.collider.transform.GetComponent<Generator>().GeneratorState();
                    }
                }
                else
                {
                    hit.collider.transform.GetComponent<Generator>().GeneratorState();
                }
            }
            else if (hit.collider.CompareTag("Battery")) // ���͸� ��ȣ�ۿ�
            {
                hit.collider.gameObject.SetActive(false);
                Player.player.BatteryItem += 1;
                text.GetComponent<Text>().text = "���͸��� ȹ���Ͽ���.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Phone")) // �� ��ȣ�ۿ�
            {
                hit.collider.transform.GetComponent<Phone>().ElectricState();
            }
            else if (hit.collider.CompareTag("Elevator")) // ���������� ��ȣ�ۿ�
            {
                hit.collider.transform.GetComponent<Elevator>().ElevatorStatus();
            }
            else if (hit.collider.CompareTag("GeneratorControll")) // ������ ��Ʈ�� ��ȣ�ۿ�
            {
                hit.collider.transform.GetComponent<GeneratorControll>().GeneratorControllState();
            }
            else if (hit.collider.CompareTag("Corpse")) // ��ü ��ȣ�ۿ�
            {
                text.GetComponent<Text>().text = "�̹� �׾��ִ�...";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Drawer")) // ���� ��ȣ�ۿ�
            {
                hit.collider.transform.GetComponent<Drawer>().OpenDrawer();
            }
            else if (hit.collider.CompareTag("CardKey3") || hit.collider.CompareTag("CardKey2") || hit.collider.CompareTag("CardKey1")) // ī��Ű�� ��ȣ�ۿ�
            {
                hit.collider.gameObject.SetActive(false);
                if (hit.collider.CompareTag("CardKey3"))
                {
                    Player.player.CardKeys[2] = true;
                    Player.player.items[2].SetActive(true);
                }
                else if (hit.collider.CompareTag("CardKey2"))
                {
                    Player.player.CardKeys[1] = true;
                    Player.player.items[1].SetActive(true);
                }
                else
                {
                    Player.player.CardKeys[0] = true;
                    Player.player.items[0].SetActive(true);
                }
                text.GetComponent<Text>().text = "ī�带 ȹ���Ͽ���.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("HandLight")) // ������ ��ȣ�ۿ�
            {
                hit.collider.gameObject.SetActive(false);
                transform.Find("Main Camera").Find("HandLightItem").gameObject.SetActive(true);
                text.GetComponent<Text>().text = "�������� ȹ���Ͽ���. FŰ�� ���� ����� �� �ִ�.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Obstacle")) // ��ֹ� ��ȣ�ۿ�(����)
            {
                text.GetComponent<Text>().text = "����� ��ֹ� ������ �� ������ �� ����. �ٸ� ���� ã�ƺ���.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("EscapeKeypad")) // ���� Ű�е� ��ȣ�ۿ�
            {
                if (hit.collider.transform.GetComponent<EscapeKeyPad>().Fuse1.transform.GetComponent<FuseState>().FuseUse == true && hit.collider.transform.GetComponent<EscapeKeyPad>().Fuse2.transform.GetComponent<FuseState>().FuseUse == true)
                {
                    if (transform.Find("Main Camera").Find("Items").GetChild(1).gameObject.activeSelf == true || transform.Find("Main Camera").Find("Items").GetChild(2).gameObject.activeSelf == true)
                    {
                        hit.collider.transform.GetComponent<EscapeKeyPad>().OpenKeyDoor();
                    }
                    else
                    {
                        text.GetComponent<Text>().text = "ī��Ű�� �ʿ��� �� ����.";
                        StartCoroutine(TextOut());
                    }
                }
                else
                {
                    text.GetComponent<Text>().text = "�۵��� �ȵȴ�. ���ܱ���� Ȯ���غ���.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("Fuse")) // ���� ǻ�� ��ȣ�ۿ�.
            {
                if (hit.collider.transform.GetComponent<FuseState>().FuseUse == false)
                {
                    hit.collider.transform.GetComponent<FuseState>().FuseOn();
                    text.GetComponent<Text>().text = "���ܱ��� ����ġ�� �۵����״�.";
                    StartCoroutine(TextOut());
                }
                else
                {
                    text.GetComponent<Text>().text = "�̹� ����ġ�� ���̴�. ���̻� ������ �ʿ䰡 ���� ���δ�.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("BreakDoor"))
            {
                text.GetComponent<Text>().text = "���峭 ���̴�... ����� Ż���� �Ұ����� �� ����.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Desktop"))
            {
                hit.collider.transform.GetComponent<News>().OnNewsButton();
            }
            else if (hit.collider.name == "��ȭ��")
            {
                if (Player.player.fireExt == false)
                {
                    hit.collider.transform.GetComponent<FireExt>().GetFireExt();
                    Player.player.items[3].SetActive(true);
                    text.GetComponent<Text>().text = "��ȭ�⸦ ȹ���Ͽ���! (���콺 ��Ŭ������ ��밡��)";
                    StartCoroutine(TextOut());
                }
                else
                {
                    text.GetComponent<Text>().text = "��ȭ��� �̹� ȹ���Ͽ���.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.name == "�ҵ�")
            {
                if (Player.player.fireExt == false)
                {
                    text.GetComponent<Text>().text = "���� �������ؼ� ��ȭ�Ⱑ �ʿ��� �� ����!";
                    StartCoroutine(TextOut());
                }
                else
                {
                    hit.collider.gameObject.SetActive(false);
                    SoundManager.SM.PlaySound("CatchFire");
                    text.GetComponent<Text>().text = "���� ����!";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("paper")) // ����
            {
                hit.collider.transform.GetComponent<News>().OnNewsButton();
            }
            else if (hit.collider.CompareTag("helicopter")) // �︮����
            {
                hit.collider.GetComponent<FadeController>().GameOverFadeOut();
            }
            Debug.Log(hit.transform.gameObject.name);
        }
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }
}
