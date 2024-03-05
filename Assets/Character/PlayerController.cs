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

        [Space]
        [Header("Interaction")]
        public GameObject interactBox;
        public float interactBoxTime = 0.2f;

        private Vector2 direction;
        private Vector2 movementInput;


        void Start() 
        {
            interactBox = GameObject.Find("interactBox");
            interactBox.SetActive(false);
        }

        private void Update()
        {
            RotateWithMouse();
            MoveWithKeys();
            transform.position += speed * Time.deltaTime * new Vector3(direction.x, 0, direction.y);
        }

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
        
        void RotateWithMouse()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            transform.Rotate(Vector3.up * (mouseX * rotationSpeed * Time.deltaTime));
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
