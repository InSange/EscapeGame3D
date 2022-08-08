using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* // 싱글톤 // * instance라는 변수를 static으로 선언을 하여 다른 오브젝트 안의 스크립트에서도 instance를 불러올 수 있게 합니다 */
    public static Player player = null; 
    private void Awake()
    {
        if (player == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때 
        {
            player = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지 
        } 
        else { 
            if (player != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미 
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제 
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fireAnim = fireObject.GetComponent<Animator>();
        transferMapName = "Factory";
        currentMapName = "B1";
    }
    public GameObject fireObject;
    public Animator fireAnim;

    public CharacterController SelectPlayer; // 제어할 캐릭터 컨트롤러
    public Camera fpsCam;
    public float Speed = 5.0f;  // 이동속도
    public float JumpPow = 5.0f;
    public float interactDistance = 2.5f;   // 레이저 사거리

    private float Gravity = 20.0f;  // 중력   
    private Vector3 MoveDir = Vector3.zero; // 캐릭터의 움직이는 방향.
    private bool JumpButtonPressed = false;  //  최종 점프 버튼 눌림 상태
    public bool silence = false;

    float rotSpeed = 2.0f;
    float currentRot = 0f;
    public bool rotCtr = true;

    public AudioClip footStepSound;
    public float footStepDelay;
    private float nextFootstep = 0;

    public GameObject SelectWindow;
    float SelectItemSpace = 100f;
    public int BatteryItem = 0; 
    public bool[] CardKeys = new bool[] { false, false, false };
    public GameObject[] items;
    private int inputkey = 0;
    public bool fireExt = false;

    public string transferMapName; 
    public string currentMapName;

    public bool survive = true;
    // Update is called once per frame
    void Update()
    {
        Move();
        RotCtrl();
        if (Input.GetKeyDown(KeyCode.E))
        {
            //P_Interaction();
            transform.GetComponent<Interaction>().P_Interaction();
        }
    }

    private void Move()
    {
        if (SelectPlayer == null) return;
        // 캐릭터가 바닥에 붙어 있는 경우만 작동합니다.
        // 캐릭터가 바닥에 붙어 있지 않다면 바닥으로 추락하고 있는 중이므로
        // 바닥 추락 도중에는 방향 전환을 할 수 없기 때문입니다.
        if (SelectPlayer.isGrounded)
        {
            // 키보드에 따른 X, Z 축 이동방향을 새로 결정합니다.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // 오브젝트가 바라보는 앞방향으로 이동방향을 돌려서 조정합니다.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                silence = true;
                GetComponent<AudioSource>().volume = 0.35f;
                footStepDelay = 1.0f;
                Speed = 2.0f;
            }
            else
            {
                silence = false;
                GetComponent<AudioSource>().volume = 1.0f;
                footStepDelay = 0.5f;
                Speed = 5.0f;
            }
            // 속도를 곱해서 적용합니다.
            MoveDir *= Speed;

            if (JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
            }
        }
        else    // 캐릭터가 바닥에 붙어 있지 않다면
        {      
            MoveDir.y -= Gravity * Time.deltaTime;
        }

        if (!Input.GetButton("Jump"))
        {
            JumpButtonPressed = false;       
        }

        SelectPlayer.Move(MoveDir * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && !JumpButtonPressed)
        {
            nextFootstep -= Time.deltaTime;
            if (nextFootstep <= 0)
            {
                GetComponent<AudioSource>().PlayOneShot(footStepSound, 2.0f);
                nextFootstep += footStepDelay;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            inputkey = 0;
            for (int i = 0; i < items.Length; i++)
            {
                GameObject KeyObj = transform.Find("Main Camera").Find("Items").GetChild(i).gameObject;
                KeyObj.SetActive(false);              
            }
            SelectWindow.GetComponent<RectTransform>().anchoredPosition = new Vector3(SelectItemSpace * inputkey, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Input.GetKeyDown(KeyCode.Alpha2)) { inputkey = 1; } 
            else if (Input.GetKeyDown(KeyCode.Alpha3)) { inputkey = 2; } 
            else if (Input.GetKeyDown(KeyCode.Alpha4)) { inputkey = 3; }
            if (CardKeys[inputkey-1] == true)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    GameObject KeyObj = transform.Find("Main Camera").Find("Items").GetChild(i).gameObject;
                    if (i == inputkey-1)
                    {
                        KeyObj.SetActive(true);
                        SelectWindow.GetComponent<RectTransform>().anchoredPosition = new Vector3(SelectItemSpace * inputkey, 0, 0);
                    }
                    else
                    {
                        KeyObj.SetActive(false);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (fireExt == true)
            {
                inputkey = 4;
                for (int i = 0; i < items.Length; i++)
                {
                    GameObject KeyObj = transform.Find("Main Camera").Find("Items").GetChild(i).gameObject;
                    if (i == inputkey - 1)
                    {
                        KeyObj.SetActive(true);
                        SelectWindow.GetComponent<RectTransform>().anchoredPosition = new Vector3(SelectItemSpace * inputkey, 0, 0);
                    }
                    else
                    {
                        KeyObj.SetActive(false);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && transform.Find("Main Camera").Find("HandLightItem").gameObject.activeSelf == true)
        {
            transform.Find("Main Camera").GetComponent<FlashLight>().UseFlash();
        }

        if (fireObject.activeSelf == true) {
            if (Input.GetMouseButton(0))
            {
                fireObject.GetComponent<FireExt>().shoot();
            }
            else
            {
                fireObject.GetComponent<FireExt>().shootStop();
            }
        }
    }
    void RotCtrl()
    {
        if (rotCtr == true)
        {
            float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
            float rotY = Input.GetAxis("Mouse X") * rotSpeed;

            currentRot -= rotX;


            currentRot = Mathf.Clamp(currentRot, -80f, 80f);

            this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);

            fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
        }
    }

    public void ShakeWindow()
    {
        this.gameObject.GetComponent<ShakeCamera>().Shake();
    }
}