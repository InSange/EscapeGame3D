using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryReadScript : MonoBehaviour
{
    //public을 이용해 인스펙터 창에서 설정 가능하도록 변수 생성
    public GameObject Diary;

    //Tag를 바꾸기 위해 사용될 변수 생성
   // public string tag;

    //시간을 측정하는 곳에 사용될 변수 생성
   // float time = 0f;

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
                if (hit.transform.CompareTag(tag))
                {
                    //코르틴을 이용해 UI를 3초간 킴
                    StartCoroutine(ShowDiary(Diary));
                }
            }
        }
    }

    //Diary를 띄우고 3초 지연한 후 객체를 끄는 함수
    public IEnumerator ShowDiary(GameObject Diary)
    {
        //Diary를 사용자가 볼 수 있도록 설정
        Diary.SetActive(true);
        //WaitForSeconds를 이용해 다음 스크립트 까지의 공백 기간을 둠
        yield return new WaitForSeconds(3f);
        //다시 사용자가 볼 수 없도록 설정
        Diary.SetActive(false);
    }
}
