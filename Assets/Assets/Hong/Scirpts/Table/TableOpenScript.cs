using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableOpenScript : MonoBehaviour
{
    //객체의 애니메이션을 받을 tableAnimator를 생성
    Animator tableAnimator;
    //객체의 음향을 받을 tableAudio를 생성
    AudioSource tableAudio;

    //프로그램 시작과 동시에 애니메이션과 음향을 변수에 저장
    private void Start()
    {
        //객체에서 애니메이션을 받아와 tableAnimator에 저장
        tableAnimator = GetComponentInParent<Animator>();
        //객체에서 음향을 받아와 tableAudio에 저장
        tableAudio = GetComponentInParent<AudioSource>();
    }

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
                if (hit.transform.CompareTag("Table"))
                {
                    //서랍이 닫혀있는지 확인
                    if (!tableAnimator.GetBool("Open"))
                    {
                        //애니메이션에 "Open"변수를 true 값으로 변경
                        tableAnimator.SetBool("Open", true);
                        //음향 재생
                        tableAudio.Play();
                    }
                    //열려 있을 경우
                    else
                    {
                        //대사가 나올 수 있도록 true 값을 설정
                        GetComponent<LineId>().takeLine = true;
                    }
                }
            }
        }
    }
}
