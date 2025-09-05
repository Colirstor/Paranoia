using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _rotateSpeed = 75;
    private float _walkSpeed = 5;
    private float _runSpeed = 8;
    private float _jumpForce = 5;
    private float _gravity = -9.81f;
    private CharacterController _characterController;
    private Camera _playerCamera;
    private Vector2 _rotation;
    private Vector2 _direction;
    private Vector3 _velocity;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _characterController.Move(_velocity * Time.deltaTime);
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (_characterController.isGrounded)
        {
            _velocity.y = Input.GetKeyDown(KeyCode.Space) ? _jumpForce : -0.1f;
        }
        else
        {
            _velocity.y += _gravity * Time.deltaTime;
        }

        mouseDelta *= _rotateSpeed * Time.deltaTime;
        _rotation.y += mouseDelta.x;
        _rotation.x = Mathf.Clamp(_rotation.x - mouseDelta.y, -90, 90);
        _playerCamera.transform.localEulerAngles = _rotation;
    }

    private void FixedUpdate()
    {
        _direction *= Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
        Vector3 move = Quaternion.Euler(0, _playerCamera.transform.eulerAngles.y, 0) * new Vector3(_direction.x, 0, _direction.y);
        _velocity = new Vector3(move.x, _velocity.y, move.z);
    }
}
