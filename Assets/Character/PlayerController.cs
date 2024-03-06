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

        [Space]
        [Header("Interaction")]
        public GameObject interactBox;
        public float interactBoxTime = 0.2f;

        private Vector2 direction;
        private Vector2 movementInput;
        private Vector2 rotationInput;
        private bool controller;


        void Start() 
        {
            interactBox = GameObject.Find("interactBox");
            interactBox.SetActive(false);
        }

        private void Update()
        {
            
            MoveWithKeys();
            transform.position += speed * Time.deltaTime * new Vector3(direction.x, 0, direction.y);
        }

        private void FixedUpdate()
        {
            
            if(controller) RotateWithGamepad();
            else RotateWithMouse();
            
        }

        // Event for Unity
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                interactBox.SetActive(true);
                Invoke(nameof(DisableInteractBox), interactBoxTime);
                
                
            }
        }

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
            Debug.Log(mouseX);
            transform.Rotate(Vector3.up * (mouseX * rotationSpeed * Time.deltaTime));
        }

        void RotateWithGamepad()
        {
            Debug.Log(rotationInput);
            float rotationAmountX = rotationInput.x * gamepadRotationSpeed * Time.deltaTime;
            //float rotationAmountY = input.y * gamepadRotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up * rotationAmountX, Space.World);
            //transform.Rotate(Vector3.left * rotationAmountY);
        }
        
        void MoveWithKeys()
        {
            Quaternion cameraRotation = Camera.main.transform.rotation;

            Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
            moveDirection = cameraRotation * moveDirection;
            
            transform.Translate(moveDirection.normalized * (speed * Time.deltaTime), Space.World);
        }


        private void DisableInteractBox()
        {
            interactBox.SetActive(false);
        }
        
    }
}
