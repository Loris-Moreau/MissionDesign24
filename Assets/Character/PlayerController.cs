using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Options")] 
        public float speed = 5;
        public float mouseSensitivity = 2f;
        private float rotationSpeed = 40;
        public float gamepadRotationSpeed = 40;
        public float maxLookUpAngle = 80f;  
        public float maxLookDownAngle = 80f;
        public GameObject fpsCamera;

        [Space]
        [Header("Interaction")]
        public GameObject interactBox;
        public float interactBoxTime = 0.2f;

        private Vector2 direction;
        private Vector2 movementInput;
        private Vector2 rotationInput;
        private bool controller;
        private float currentRotationX = 0f;
        private float currentRotationY = 0f;
        
        void Start() 
        {
            interactBox = GameObject.Find("interactBox");
            fpsCamera = GameObject.Find("FPSCamera");
            interactBox?.SetActive(false);
        }

        private void Update()
        {
            MoveWithKeys();
            transform.position += speed * Time.deltaTime * new Vector3(direction.x, 0, direction.y);
            if(controller) RotateWithGamepad();
            else RotateWithMouse();
        }

        // Event for Unity
        // public void OnInteract(InputAction.CallbackContext context)
        // {
        //     if (context.performed)
        //     {
        //         interactBox.SetActive(true);
        //         Invoke(nameof(DisableInteractBox), interactBoxTime);
        //     }
        // }

        public void Move(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
        }

        public void Inventory(InputAction.CallbackContext context)
        {
            
        }

        public void Menu(InputAction.CallbackContext context)
        {
            
        }
        
        public void CameraMove(InputAction.CallbackContext context)
        {
            controller = context.control.device is Gamepad;
            rotationInput = context.ReadValue<Vector2>();
        }    
        
        // Others
        void RotateWithMouse()
        {
            float mouseX = rotationInput.x * mouseSensitivity;
            float mouseY = rotationInput.y * mouseSensitivity;

            currentRotationX -= mouseY;
            currentRotationX = Mathf.Clamp(currentRotationX, -maxLookUpAngle, maxLookDownAngle);

            fpsCamera.transform.localRotation = Quaternion.Euler(currentRotationX, 0, 0);
            transform.Rotate(Vector3.up * (mouseX * rotationSpeed * Time.deltaTime));
        }

        void RotateWithGamepad()
        {
            float rotationAmountX = rotationInput.x * gamepadRotationSpeed * Time.deltaTime;
            float rotationAmountY = rotationInput.y * gamepadRotationSpeed * Time.deltaTime;

            currentRotationX -= rotationAmountX;
            currentRotationY -= rotationAmountY;
            currentRotationY = Mathf.Clamp(currentRotationY, -maxLookUpAngle, maxLookDownAngle);
            fpsCamera.transform.localRotation = Quaternion.Euler(currentRotationY, 0, 0);
            //fpsCamera.transform.Rotate(-rotationAmountY, 0, 0);

            transform.Rotate(Vector3.up * rotationAmountX, Space.Self);
            //transform.Rotate(Vector3.left * rotationAmountY);
        }
        
        void MoveWithKeys()
        {
            Quaternion cameraRotation = Camera.main.transform.rotation;

            Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y).normalized;
            // Debug.Log(moveDirection);
            // moveDirection = new Vector3(transform.right.x * moveDirection.x,
            //     0,
            //     transform.forward.z * moveDirection.z);
            //
            // Debug.Log(moveDirection);
            
            transform.Translate(moveDirection * (speed * Time.deltaTime), Space.Self);
        }


        private void DisableInteractBox()
        {
            interactBox.SetActive(false);
        }
        
    }
}
