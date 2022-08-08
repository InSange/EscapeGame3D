using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LineSet : MonoBehaviour
{
    //public을 이용해 인스펙터 창에서 설정 가능하도록 변수 생성
    public GameObject Line;

    //Text 스크립트를 수정할 수 있도록 Text 변수 생성
    Text text;

    //나중에 맞는 대사를 불러오기 위한 string리스트 생성
    List<string> texts = new List<string>
    {
        "문이 잠겨있다.. 열쇠가 필요할 것 같다.",
        "창 밖을 보니 밤인 것 같다...",
        "떨어져서 깨진 액자가 있다.",
        "서랍이 열려있다. 안을 들여다 보자.",
        "어디에 쓰는지 모르는 열쇠를 얻었다.",
        "2017학년도 졸업 앨범이다..",
        "낯 익은 이름들이다...\n나랑 관련이 있을 것 같다.",
        "무언가를 의미하는 것 같다..."
    };

    //프로그램 시작과 동시에 대사 객체의 Text 컴퍼넌트를 text에 불러와 저장
    private void Start()
    {
        //text 변수에 Text 컴퍼넌트 저장
        text = Line.GetComponent<Text>();
    }

    //실시간으로 객체와 상호작용하여 대사를 변경시켜주는 함수
    private void Update()
    {
        //F키를 눌렀을 때 ray를 쏴서 객체와 상호작용 할 것인지 확인
        if (Input.GetKeyDown(KeyCode.F))
        {
            //마우스 포인트에 ray를 지정
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray에 맞은 객체를 저장할 변수 생성
            RaycastHit hit;

            //ray에 객체가 감지되었는지 확인하고 해당 객체에 LineId가 있는지 확인
            if(Physics.Raycast(ray, out hit) && hit.transform.GetComponentInParent<LineId>() != null)
            {
                //객체 안에 있는 texts의 인덱스 번호를 불러와 저장
                int lineNumber = hit.transform.GetComponentInParent<LineId>().id;
                //객체 안에 있는 대사 출력 유무 변수를 불러와 저장
                bool lineTake = hit.transform.GetComponentInParent<LineId>().takeLine;

                //lineTake가 true 값일 경우 대사가 실행 되도록 lineTake 확인
                if (lineTake)
                {
                    //전에 출력하던 대사가 있으면 중지
                    StopAllCoroutines();
                    //코르틴을 사용하여 대사 변경
                    StartCoroutine(SetText(lineNumber));
                }
            }
        }
    }

    //대사를 변경한 후 3초 지연하고 대사를 공백으로 바꾸는 코르틴 함수
    public IEnumerator SetText(int lineNumber)
    {
        //객체에서 받은 인덱스 값을 리스트에 넣어 대사를 변경
        text.text = texts[lineNumber];
        //WaitForSeconds를 이용해 다음 스크립트 까지의 공백 기간을 둠
        yield return new WaitForSeconds(3f);
        //다시 대사를 공백으로 바꿔줌
        text.text = "";
    }
}
