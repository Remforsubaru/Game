using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RorationAxes
    {

        X

    }
    public float _rotationSpeedHor = 5.0f;
    public float _rotationSpeedVer = 5.0f;

    public float maxVert = 45.0f;
    public float minVert = -45.0f;

    private float _rotationX = 0;

    private bool isMoving;
    private Animator _animator;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSpeedHor, 0);
        
    }

    public void SetIsMovimg(bool new_state)
    {
        isMoving = new_state;
    }
}