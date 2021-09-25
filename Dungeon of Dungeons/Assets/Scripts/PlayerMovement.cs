using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float mouseSensitivity = 100f;
    public Transform cam, lean, sword;
    public CharacterController characterController;
    public float gravity = -9.82f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight;
    public float swervingAngle, swervespeed;

    float vertical, mouseVertical;
    float horizontal, mouseHorizontal;
    float xRotation = 0f;
    Vector3 move;
    Vector3 velocity;
    bool isGrounded;
    float currentSwervingAngle;
    bool swerveRight=true;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Rotation
        mouseHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseVertical = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseVertical;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseHorizontal);


        //Movement
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        move = transform.right * horizontal + transform.forward * vertical;

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            print("isGrounded");
        }

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            print("jump");
        }

        if (vertical != 0)
        {
            if (currentSwervingAngle>=swervingAngle)
            {
                swerveRight = false;
            }
            else if (currentSwervingAngle<=-swervingAngle)
            {
                swerveRight = true;
            }

            if (swerveRight)
            {
                currentSwervingAngle += swervespeed;
                lean.localRotation = Quaternion.Euler(0.0f, 0.0f, currentSwervingAngle);
            }
            else
            {
                currentSwervingAngle -= swervespeed;
                lean.localRotation = Quaternion.Euler(0.0f, 0.0f, currentSwervingAngle);
            }

        }
        else if (vertical==0)
        {
            lean.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }


}
