using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTakeScript : MonoBehaviour
{
    //객체의 애니메이션을 받을 bookAnimator를 생성
    Animator bookAnimator;
    //객체의 음향을 받을 bookAudio를 생성
    AudioSource bookAudio;

    //프로그램 시작과 동시에 애니메이션과 음향을 변수에 저장
    private void Start()
    {
        //객체에서 애니메이션을 받아와 bookAnimator에 저장
        bookAnimator = GetComponentInParent<Animator>();
        //객체에서 음향을 받아와 bookAudio에 저장
        bookAudio = GetComponentInParent<AudioSource>();
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
                if (hit.transform.CompareTag("BookShelf"))
                {
                    //책이 이미 떨어졌는지 확인
                    if (!bookAnimator.GetBool("Drop"))
                    {
                        //애니메이션에 "Drop"변수를 true 값으로 변경
                        bookAnimator.SetBool("Drop", true);
                        //음향 재생
                        bookAudio.Play();
                    }
                    //책이 이미 떨어진 경우
                    else
                    {
                        //대사가 나오지 않도록 false 값을 설정
                        GetComponent<LineId>().takeLine = false;
                    }
                }
            }
        }
    }
}
