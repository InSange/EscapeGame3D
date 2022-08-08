using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    //속도를 변수를 이용하여 초기화
    public float speed = 0.1f;

    //FixedUpdate를 이용하여 물리적으로 객체를 업데이트
    private void FixedUpdate()
    {
        //위 방향키 또는 W키를 눌렀을 때 객체의 Z축 좌표를 이동
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //스크립트가 존재하는 객체의 Z축 방향을 속도 변수 * 시간 변화량한 값만큼 이동
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
        //아래 방향키 또는 S키를 눌렀을 때 객체의 Z축 좌표를 이동
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //스크립트가 존재하는 객체의 Z축 방향을 속도 변수 * 시간 변화량 * -1한 값만큼 이동
            this.transform.Translate(0, 0, speed * Time.deltaTime * -1f);
        }
        //오른 방향키 또는 D키를 눌렀을 때 객체의 X축 좌표를 이동
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //스크립트가 존재하는 객체의 X축 방향을 속도 변수 * 시간 변화량한 값만큼 이동
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        //왼 방향키 또는 A키를 눌렀을 때 객체의 X축 좌표를 이동
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //스크립트가 존재하는 객체의 X축 방향을 속도 변수 * 시간 변화량 * -1한 값만큼 이동
            this.transform.Translate(speed * Time.deltaTime * -1f, 0, 0);
        }
    }
}
