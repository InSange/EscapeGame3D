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
            if (hit.collider.CompareTag("Door")) // 문 상호작용
            {
                //hit.collider.transform.parent.GetComponent<B1Door>().ChangeDoorState();
                hit.collider.transform.GetComponent<B1Door>().ChangeDoorState();
                SoundManager.SM.PlaySound("Door");
            }
            else if (hit.collider.CompareTag("DoorKeyPad"))
            {
                text.GetComponent<Text>().text = "카드키로 문을 열수 있을 것 같다...";
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
                    text.GetComponent<Text>().text = "카드키가 필요한 것 같다.";
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
                    text.GetComponent<Text>().text = "카드키가 필요한 것 같다.";
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
                    text.GetComponent<Text>().text = "카드키가 필요한 것 같다.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("Generator")) // 발전기 상호작용
            {
                if (Player.player.BatteryItem > 0)
                {
                    if (hit.collider.transform.GetComponent<Generator>().battery.activeSelf == false)
                    {
                        Player.player.BatteryItem -= 1;
                        hit.collider.transform.GetComponent<Generator>().battery.SetActive(true);
                        //hit.collider.transform.GetComponent<Generator>().GeneratorState();
                        text.GetComponent<Text>().text = "배터리를 넣었다.";
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
            else if (hit.collider.CompareTag("Battery")) // 배터리 상호작용
            {
                hit.collider.gameObject.SetActive(false);
                Player.player.BatteryItem += 1;
                text.GetComponent<Text>().text = "배터리를 획득하였다.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Phone")) // 폰 상호작용
            {
                hit.collider.transform.GetComponent<Phone>().ElectricState();
            }
            else if (hit.collider.CompareTag("Elevator")) // 엘리베이터 상호작용
            {
                hit.collider.transform.GetComponent<Elevator>().ElevatorStatus();
            }
            else if (hit.collider.CompareTag("GeneratorControll")) // 발전기 컨트롤 상호작용
            {
                hit.collider.transform.GetComponent<GeneratorControll>().GeneratorControllState();
            }
            else if (hit.collider.CompareTag("Corpse")) // 시체 상호작용
            {
                text.GetComponent<Text>().text = "이미 죽어있다...";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Drawer")) // 서랍 상호작용
            {
                hit.collider.transform.GetComponent<Drawer>().OpenDrawer();
            }
            else if (hit.collider.CompareTag("CardKey3") || hit.collider.CompareTag("CardKey2") || hit.collider.CompareTag("CardKey1")) // 카드키들 상호작용
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
                text.GetComponent<Text>().text = "카드를 획득하였다.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("HandLight")) // 손전등 상호작용
            {
                hit.collider.gameObject.SetActive(false);
                transform.Find("Main Camera").Find("HandLightItem").gameObject.SetActive(true);
                text.GetComponent<Text>().text = "손전등을 획득하였다. F키를 눌러 사용할 수 있다.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Obstacle")) // 장애물 상호작용(공장)
            {
                text.GetComponent<Text>().text = "여기는 장애물 때문에 못 지나갈 것 같다. 다른 길을 찾아보자.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("EscapeKeypad")) // 옥상문 키패드 상호작용
            {
                if (hit.collider.transform.GetComponent<EscapeKeyPad>().Fuse1.transform.GetComponent<FuseState>().FuseUse == true && hit.collider.transform.GetComponent<EscapeKeyPad>().Fuse2.transform.GetComponent<FuseState>().FuseUse == true)
                {
                    if (transform.Find("Main Camera").Find("Items").GetChild(1).gameObject.activeSelf == true || transform.Find("Main Camera").Find("Items").GetChild(2).gameObject.activeSelf == true)
                    {
                        hit.collider.transform.GetComponent<EscapeKeyPad>().OpenKeyDoor();
                    }
                    else
                    {
                        text.GetComponent<Text>().text = "카드키가 필요한 것 같다.";
                        StartCoroutine(TextOut());
                    }
                }
                else
                {
                    text.GetComponent<Text>().text = "작동이 안된다. 차단기부터 확인해보자.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("Fuse")) // 공장 퓨즈 상호작용.
            {
                if (hit.collider.transform.GetComponent<FuseState>().FuseUse == false)
                {
                    hit.collider.transform.GetComponent<FuseState>().FuseOn();
                    text.GetComponent<Text>().text = "차단기의 스위치를 작동시켰다.";
                    StartCoroutine(TextOut());
                }
                else
                {
                    text.GetComponent<Text>().text = "이미 스위치가 온이다. 더이상 조작할 필요가 없어 보인다.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("BreakDoor"))
            {
                text.GetComponent<Text>().text = "고장난 문이다... 여기로 탈출은 불가능할 것 같다.";
                StartCoroutine(TextOut());
            }
            else if (hit.collider.CompareTag("Desktop"))
            {
                hit.collider.transform.GetComponent<News>().OnNewsButton();
            }
            else if (hit.collider.name == "소화기")
            {
                if (Player.player.fireExt == false)
                {
                    hit.collider.transform.GetComponent<FireExt>().GetFireExt();
                    Player.player.items[3].SetActive(true);
                    text.GetComponent<Text>().text = "소화기를 획득하였다! (마우스 좌클릭으로 사용가능)";
                    StartCoroutine(TextOut());
                }
                else
                {
                    text.GetComponent<Text>().text = "소화기는 이미 획득하였다.";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.name == "불들")
            {
                if (Player.player.fireExt == false)
                {
                    text.GetComponent<Text>().text = "불을 끄기위해서 소화기가 필요할 것 같다!";
                    StartCoroutine(TextOut());
                }
                else
                {
                    hit.collider.gameObject.SetActive(false);
                    SoundManager.SM.PlaySound("CatchFire");
                    text.GetComponent<Text>().text = "불을 껐다!";
                    StartCoroutine(TextOut());
                }
            }
            else if (hit.collider.CompareTag("paper")) // 종이
            {
                hit.collider.transform.GetComponent<News>().OnNewsButton();
            }
            else if (hit.collider.CompareTag("helicopter")) // 헬리콥터
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
