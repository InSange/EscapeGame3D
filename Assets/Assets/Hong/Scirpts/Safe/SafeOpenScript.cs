using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SafeOpenScript : MonoBehaviour
{
    //public을 이용해 인스펙터 창에서 설정 가능하도록 변수 생성
    public GameObject InputAnswer;
    public GameObject AimPoint;

    //객체의 애니메이션을 받을 safeAnimator를 생성
    Animator safeAnimator;
    //객체의 음향을 받을 safeAudio를 생성
    AudioSource safeAudio;
    //입력 받은 Text를 InputField에서 받기 위해 변수 생성
    InputField inputField;

    //프로그램 시작과 동시에 애니메이션과 음향을 변수에 저장
    //사용자에게서 받은 값을 저장하기 위해 컴퍼넌트를 변수에 저장
    private void Start()
    {
        //객체에서 애니메이션을 받아와 safeAnimator에 저장
        safeAnimator = GetComponentInParent<Animator>();
        //객체에서 음향을 받아와 safeAudio에 저장
        safeAudio = GetComponentInParent<AudioSource>();
        //객체에서 입력 값을 받기 위해 Component<InputField>()를 answer에 저장
        inputField = InputAnswer.GetComponent<InputField>();
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
                if (hit.transform.CompareTag("Safe"))
                {
                    //이전에 실행되고 있는 코르틴을 모두 종료
                    StopAllCoroutines();
                    //코르틴을 사용하여 정답 입력 받음
                    StartCoroutine(Challenge());
                }
            }
        }
    }

    //5초간 스크립트를 지연하고 정답을 입력 받는 함수
    public IEnumerator Challenge()
    {
        //화면의 초점을 끄도록 설정
        AimPoint.SetActive(false);
        //마우스 커서가 고정을 유지하면서 기능할 수 있도록 설정
        Cursor.lockState = CursorLockMode.Confined;

        //마우스 커서가 보이도록 설정
        //Cursor.visible = true;

        //입력 창이 화면에 보이도록 설정
        InputAnswer.SetActive(true);
        //WaitForSeconds를 이용해 다음 스크립트 까지의 공백 기간을 둠
        yield return new WaitForSeconds(5f);
        //사용자 입력 값을 userAnswer 변수에 저장
        int answer = int.Parse(inputField.text);
        //다시 입력 창이 화면에서 사라지게 설정
        InputAnswer.SetActive(false);

        //화면에 초점이 보이도록 설정
        AimPoint.SetActive(true);
        //마우스 커서가 고정되도록 설정
        Cursor.lockState = CursorLockMode.Locked;

        //마우스 커서가 보이지 않도록 설정
        //Cursor.visible = false;

        Debug.Log(answer);

        //열리지 않은 상태에서 암호가 맞는지 확인
        if (!safeAnimator.GetBool("Open") && answer == 2015)
        {
            //애니메이션에 "Open"변수를 true 값으로 변경
            safeAnimator.SetBool("Open", true);
            //음향 재생
            safeAudio.Play();
        }
    }
}
