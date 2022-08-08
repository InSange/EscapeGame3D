using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlayer : MonoBehaviour
{
    public CharacterController SelectPlayer;
    public Camera fpsCam;
    public float Speed = 5.0f;
    public float JumpPow = 5.0f;
    public float interactDistance = 2.5f;

    private float Gravity = 10.0f;
    private Vector3 MoveDir = Vector3.zero;
    private bool JumpButtonPressed = false;

    float rotSpeed = 3.0f;
    float currentRot = 0f;

    public AudioClip footStepSound;
    public float footStepDelay;
    private float nextFootstep = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
        RotCtrl();
        if (Input.GetKeyDown(KeyCode.E))
        {
            interaction();
        }
    }

    private void interaction()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("DreamDoor")) // 문 상호작용
            {
                Debug.Log(hit.transform.gameObject.name);
                SceneManager.LoadScene("B1");
            }
        }
    }

    private void Move()
    {
        if (SelectPlayer == null) return;

        if (SelectPlayer.isGrounded)
        {

            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);

            MoveDir *= Speed;

            if (JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
            }
        }
        else
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
    }
    void RotCtrl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        currentRot -= rotX;


        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);

        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }

    public void mouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
