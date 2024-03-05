using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Options")] 
        public float speed = 5;
        [Space]
        
        [Header("Interaction")]
        public GameObject interactBox;
        public float interactBoxTime = 0.2f;

        private Vector2 direction;

        void Start() 
        {
            interactBox = GameObject.Find("interactBox");
            interactBox.SetActive(false);
        }

        private void Update()
        {
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
            direction = context.ReadValue<Vector2>();
        }

        private void DisableInteractBox()
        {
            interactBox.SetActive(false);
        }
    }
}