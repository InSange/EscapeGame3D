using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YControl : MonoBehaviour
{
    //회전 속도를 private를 이용하여 스크립트에서 고정
    private float rotateSpeed = 2.5f;

    //원활한 플레이를 위해 마우스 커서를 중앙에 고정하고 보이지 않게 설정
    //Awake를 이용하여 Start함수가 실행 되기 전에 커서를 고정
    private void Awake()
    {
        //CursorLockMode를 통해 커서를 고정
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor를 플레이어가 보지 못하게 설정
        Cursor.visible = false;
    }

    //마우스 회전에 따른 회전 각도를 변수에 Update를 이용하여 실시간으로 계산
    private void Update()
    {
        //시간이 흘러가고 있는지 확인한 후 시간이 흘러갈 때만 각도가 변화도록 지정
        if(Time.timeScale != 0)
        {
            //GetAxis를 이용하여 마우스의 X축 변화량을 받아 rotateSpeed값을 곱해 객체의 회전 각도를 계산
            float yRot = Input.GetAxis("Mouse X") * rotateSpeed;
            //객체의 각도 값을 현재 각도 값에 곱하여 변경
            this.transform.localRotation *= Quaternion.Euler(0f, yRot, 0f);
        }
    }
}
