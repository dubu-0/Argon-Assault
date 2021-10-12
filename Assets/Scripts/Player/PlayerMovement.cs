using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float verticalSpeed = 25f;
    [SerializeField] private float horizontalSpeed = 25f;
    
    [Header("Rotation")]
    [SerializeField] private float xRotationAngle = 18f;
    [SerializeField] private float yRotationAngle = 12f;
    [SerializeField] private float zRotationAngle = 25f;
    
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private const float MinXOffset = -9f;
    private const float MinYOffset = -4f;
    private const float MaxXOffset = 9f;
    private const float MaxYOffset = 9f;
    
    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.localPosition = CalculateNewLocalPos();
        transform.localRotation = CalculateRotation();
    }
    
    private float CalculateXOffset() => 
        transform.localPosition.x + horizontalSpeed * Input.GetAxis(Horizontal) * Time.deltaTime;
    private float CalculateYOffset() =>
        transform.localPosition.y + verticalSpeed * Input.GetAxis(Vertical) * Time.deltaTime;
    private Vector3 CalculateNewLocalPos() =>
        new Vector3(Mathf.Clamp(CalculateXOffset(), MinXOffset, MaxXOffset), 
            Mathf.Clamp(CalculateYOffset(), MinYOffset, MaxYOffset), 0f);
    private Quaternion CalculateRotation() =>
        Quaternion.Euler(
            -xRotationAngle * Input.GetAxis(Vertical), 
            yRotationAngle * Input.GetAxis(Horizontal), 
            -zRotationAngle * Input.GetAxis(Horizontal));
}
