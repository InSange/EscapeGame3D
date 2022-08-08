using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpenScirpt : MonoBehaviour
{
    //객체의 애니메이션을 받을 drawerAnimator를 생성
    Animator drawerAnimator;
    //객체의 음향을 받을 drawerAudio를 생성
    AudioSource drawerAudio;

    //열쇠의 유무를 확인하기 위한 변수 생성
    //public으로 변수를 생성해 인스펙터 창에서 변경 가능하도록 생성
    public bool keyCheck = false;

    //프로그램 시작과 동시에 애니메이션과 음향을 변수에 저장
    private void Start()
    {
        //객체에서 애니메이션을 받아와 drawerAnimator에 저장
        drawerAnimator = GetComponentInParent<Animator>();
        //객체에서 음향을 받아와 drawerAudio에 저장
        drawerAudio = GetComponentInParent<AudioSource>();
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
            if(Physics.Raycast(ray, out hit))
            {
                //ray에 맞은 객체가 자신인지 확인
                if (hit.transform.CompareTag("Drawer"))
                {
                    //열쇠가 존재하는 상태에서 서랍이 닫혀있는지 확인
                    if(!drawerAnimator.GetBool("Open") && keyCheck)
                    {
                        //애니메이션에 "Open"변수를 true 값으로 변경
                        drawerAnimator.SetBool("Open", true);
                        //음향 재생
                        drawerAudio.Play();
                    }
                    //서랍이 열린 경우
                    else if(drawerAnimator.GetBool("Open") && keyCheck)
                    {
                        //대사가 나올 수 있도록 true 값을 설정
                        GetComponent<LineId>().takeLine = true;
                    }
                }
            }
        }
    }
}
