using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XControl : MonoBehaviour
{
    //회전 속도를 private를 이용하여 스크립트에서 고정
    private float rotateSpeed = 1.5f;
    //회전 각도를 넣을 변수를 생성
    private float cameraRotation = 0f;
    //회전 한계 각도를 private를 이용하여 70도로 스크립트에서 고정
    private float cameraRotationLimit = 70f;
    //객체의 시점에서 회전되는 회전 각도를 넣을 변수를 생성
    private float currentCameraRotation = 0f;

    //마우스 회전에 따른 회전 각도를 변수에 Update를 이용하여 실시간으로 계산
    private void Update()
    {
        //GetAxis를 이용하여 마우스의 Y축 변화량을 받아 rotateSpeed값을 곱해 객체의 회전 각도를 계산
        float xRot = Input.GetAxis("Mouse Y") * rotateSpeed;
        //회전 각도 값을 cameraRotation에 저장
        cameraRotation = xRot;
    }

    //FixedUpdate를 이용하여 객체의 각도를 물리적으로 업데이트
    private void FixedUpdate()
    {
        //
        PreformRotation();
    }

    //PreformRotation함수로 실제 객체 변경 각도 설정과 객체의 각도 변경
    void PreformRotation()
    {
        //객체 시점에서의 회전 각도를 currentCameraRotation에 저장
        currentCameraRotation -= cameraRotation;
        //Mathf를 이용하여 회전 각도가 한계값 범위 안에 있는지 확인하고 실제 이동 각도를 currentCameraRotation에 저장
        currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);
        //객체의 각도 값을 변경
        transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
    }
}
