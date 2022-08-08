using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    //UI의 Aim 객체를 활성화 하기 위한 변수 생성
    public GameObject Aim;
    //UI의 TitleName을 비활성화 하기 위한 변수 생성
    public GameObject TitleName;
    //UI의 PressToSpace를 비활성화 하기 위한 변수 생성
    public GameObject PressToSpace;
    //UI의 Information을 활성화 하기 위한 변수 생성
    public GameObject InformationScript;

    //시작과 동시에 게임 내 시간을 정지 시킨다.
    void Start()
    {
        //시간의 속도를 0으로 맞춤
        Time.timeScale = 0;
    }

    //실시간으로 사용자가 Space바를 눌렀을 때 게임내 시간이 흘러가게 하는 함수
    void Update()
    {
        //TimeScale이 0일 때 Space바를 눌렀는지 확인
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            //시간의 속도를 1(기준 값)으로 변경
            Time.timeScale = 1;
            //TitleName을 비활성화 시킴
            TitleName.SetActive(false);
            //PressToSpace를 비활성화 시킴
            PressToSpace.SetActive(false);
            //마우스 초점을 활성화 시킴
            Aim.SetActive(true);
            //게임 설명을 활성화 시킴
            InformationScript.SetActive(true);
            //5초 후 게임 설명을 비활성화 시킴
            Destroy(InformationScript, 5f);
        }
    }
}
