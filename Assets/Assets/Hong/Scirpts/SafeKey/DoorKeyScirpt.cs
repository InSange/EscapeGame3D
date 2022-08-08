using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyScirpt : MonoBehaviour
{
    //public을 이용해 인스펙터 창에서 설정 가능하도록 변수 생성
    public GameObject Door;

    //실시간으로 객체 상호작용 업데이트
    private void Update()
    {
        //F키를 눌렀을 때 ray를 쏴서 객체와 상호작용 할 것인지 확인
        if (Input.GetKeyDown(KeyCode.F))
        {
            //마우스 포인트에 ray를 지정
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray에 맞은 객체를 저장할 변수 생성
            RaycastHit hit;

            //ray에 객체가 감지되었는지 확인
            if (Physics.Raycast(ray, out hit))
            {
                //ray에 맞은 객체가 자신인지 확인
                if (hit.transform.CompareTag("Key_Door"))
                {
                    //열쇠를 획득할 경우 대사가 나오도록 설정
                    GetComponent<LineId>().takeLine = true;

                    //객체가 자신이 맞다면 문을 열수 있도록 설정
                    Door.GetComponent<DoorOpenScript>().keyCheck = true;
                    //문의 대사가 나오지 않도록 설정
                    Door.GetComponent<LineId>().takeLine = false;
                    //게임에서 객체을 끔
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
