using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public CharacterController characterController;
    public float gravity = -9.82f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight;

    float vertical, mouseVertical;
    float horizontal, mouseHorizontal;
    float xRotation = 0f;
    Vector3 move;
    Vector3 velocity;
    bool isGrounded;



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

        gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseHorizontal);


        //Movement
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        move = playerBody.right * horizontal + playerBody.forward * vertical;

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButton("Jump")&&isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }


}
