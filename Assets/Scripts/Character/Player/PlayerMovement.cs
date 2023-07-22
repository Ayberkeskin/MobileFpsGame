using MobileFpsGame.Input;
using UnityEngine;

namespace MobileFpsGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] InputData _ýnputData;
        [SerializeField] PlayerSettings _playerSettings;

        private CharacterController _characterController;
        private Vector3 _heightMovement;
        private Transform _mainCamera;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            if (Camera.main.GetComponent<CameraController>() == null)
            {
                Camera.main.gameObject.AddComponent<CameraController>();
            }
            _mainCamera = GameObject.FindWithTag("CameraPoint").transform;
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            _heightMovement.y -= _playerSettings.GravityModifer * Time.deltaTime;

            //Baktigin yöne dogru gitmesi icin
            Vector3 localVerticalVector = transform.forward * _ýnputData.Vertical;
            Vector3 localHorizontalVector = transform.right * _ýnputData.Horizontal;
            Vector3 movmentVector = localHorizontalVector + localVerticalVector;

            movmentVector.Normalize();       // normal hiz 8 ise sag ust hiz 8.4 daha hizli onu esitledik hepsi 8
            movmentVector *= _playerSettings.RunSpeed * Time.deltaTime;

            _characterController.Move(movmentVector + _heightMovement);

            if (_characterController.isGrounded)
            {
                _heightMovement.y = 0f;
            }
        }

        private void Rotate()
        {
            // Calculate the rotation angles based on input and rotation speed
            float rotationX = -_ýnputData.RotateDirection.z * _playerSettings.RotateSpeed * Time.deltaTime;
            float rotationY = _ýnputData.RotateDirection.x * _playerSettings.RotateSpeed * Time.deltaTime;

            // Apply the rotation
            transform.Rotate(rotationX, rotationY, 0f, Space.Self);

            // Clamp the X rotation between -60 and 60 degrees
            float currentRotationX = transform.localEulerAngles.x;
            if (currentRotationX > 180f)
                currentRotationX -= 360f;

            float clampedRotationX = Mathf.Clamp(currentRotationX, -_playerSettings.MaxViewAngle, _playerSettings.MaxViewAngle);

            // Apply the clamped rotation
            transform.localRotation = Quaternion.Euler(clampedRotationX, transform.localEulerAngles.y, 0f);
        }
    }
}