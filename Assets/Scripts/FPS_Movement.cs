using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Movement : MonoBehaviour
{
    #region Variables
    [SerializeField] float walkSpeed, jumpHeight, lookSpeed;
    CharacterController controller;
    Vector3 velocity, moveDirection;
    float gravity = -9.81f;
    float maxX = 60f;
    float minX = -60f;
    float rotX, rotY;
    public Camera cam;
    #endregion

    #region Func
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Move();
        CamRotate();
        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            Jump();
        } 
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward).normalized;
        controller.Move(moveDirection * walkSpeed * Time.fixedDeltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    void CamRotate()
    {
        rotX += Input.GetAxis("Mouse Y") * lookSpeed;
        rotY += Input.GetAxis("Mouse X") * lookSpeed;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        transform.localEulerAngles = new Vector3(0, rotY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
    }
    #endregion
}
