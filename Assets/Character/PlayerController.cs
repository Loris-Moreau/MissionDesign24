using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 8;
        public float rotationSpeed = 40;
        private Vector2 direction;


        void Start() 
        {

        }

        void Update()
        {
                RotateWithMouse();
           
                MoveWithKeys();
        }

        void RotateWithMouse()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

            
            
                float newRotationX = Mathf.Clamp(transform.eulerAngles.x - mouseY * rotationSpeed * Time.deltaTime, -90f, 90f);
                transform.eulerAngles = new Vector3(newRotationX, transform.eulerAngles.y, 0f);
            
        }
        void MoveWithKeys()
        {
            
                transform.Rotate(0, rotationSpeed * Time.deltaTime * direction.x, 0);
            
                transform.position += transform.right * (speed * Time.deltaTime * direction.x);
            

            transform.position += transform.forward * (speed * Time.deltaTime * direction.y);
        }

        public void move(InputAction.CallbackContext context)
        {
            direction = context.ReadValue<Vector2>();


        }


    }
}