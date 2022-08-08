using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    //문 애니메이션을 받을 doorAnimator를 생성
    Animator doorAnimator;
    //문 음향을 받을 doorAudio를 생성
    AudioSource doorAudio;

    //열쇠의 유무를 확인하기 위한 변수를 생성
    //public으로 변수를 생성해 인스펙터 창에서 변경 가능하도록 생성
    public bool keyCheck = false;

    //프로그램 시작과 동시에 애니메이션과 음향을 변수에 저장
    private void Start()
    {
        //객체에서 애니메이션을 받아와 doorAnimator에 저장
        doorAnimator = GetComponent<Animator>();
        //객체에서 음향을 받아와 doorAudio에 저장
        doorAudio = GetComponent<AudioSource>();
    }

    //실시간으로 문 상호작용 업데이트
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
            if(Physics.Raycast(ray, out hit))
            {
                //ray에 맞은 객체가 자신인지 확인
                if(hit.transform.CompareTag("Door"))
                {
                    //열쇠가 존재하는 상태에서 문이 닫혀있는지 확인
                    if (!doorAnimator.GetBool("Open") && keyCheck)
                    {
                        //애니메이션에 "Open"변수를 true 값으로 변경
                        doorAnimator.SetBool("Open", true);
                        //음향 재생
                        doorAudio.Play();
                    }
                    //열쇠가 존재하는 상태에서 문이 열려있는지 확인
                    else if (doorAnimator.GetBool("Open") && keyCheck)
                    {
                        //애니메이션에 "Open"변수를 false 값으로 변경
                        doorAnimator.SetBool("Open", false);
                        //음향 재생
                        doorAudio.Play();
                    }
                }
            }
        }
    }
}
