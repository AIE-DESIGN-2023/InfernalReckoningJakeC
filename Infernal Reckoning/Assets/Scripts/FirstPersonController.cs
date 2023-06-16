using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    //Variables for speed and camera sensitivity
    public float movementSpeed = 5f;
    public float cameraSensitivity = 3f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private bool canMove = true;
    public bool moveMouse = true;
    

    //Private variables for Character controller
    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private Vector3 movement;
    
    //Variable containts info from the previous frame about jump height
    private float verticalVelocity;


    // Start is called before the first frame update
    void Start()
    {
        //Get the character controller component from this object
        characterController = GetComponent<CharacterController>();
        //Get the camera component from the child object
        playerCamera = GetComponentInChildren<Camera>(); 

        //Lock mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

        
            //PLAYER MOVEMENT
            //handle horizontal movement
            float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            //handle vertical movement
            float verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        

            //Handle movement using the above variables on the Character controller
            movement = transform.forward * verticalMovement + transform.right * horizontalMovement;
        }

        if (characterController != null)
        {
            if (characterController.isGrounded && characterController != null)
            {
                verticalVelocity = -0.5f;
            }
            else
            {
                //add gravity when not grounded
                verticalVelocity += gravity * Time.deltaTime;
            }
            if (characterController.isGrounded && Input.GetButton("Jump") && characterController != null)
            {
                //Accessing just the y value of the Vector3
                verticalVelocity = Mathf.Sqrt(jumpForce * -2 * gravity);

            }
            movement.y = verticalVelocity * Time.deltaTime;

            //Check if we press spacebar

            characterController.Move(movement);
        }
        //CAMERA MOVEMENT
        //Handle Camera Rotation
        if (moveMouse)
        {
            float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;

            //Handle vertical rotation
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

            //Rotate the player around the y axis to match camera rotation
            transform.Rotate(Vector3.up * mouseX);
            //Rotate the camera around X axis using the verticalRotation varianble above
            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
         


    
    }
    public void DisableMovement()
    {
        // Call this method when the condition is met to disable movement
        
        canMove = false;
        moveMouse = false;
        characterController = null;
    }
}
