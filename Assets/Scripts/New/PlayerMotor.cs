using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Vector3 velocity;
    void Start()
    {
        _playerRb= GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity= _velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
    }

    void PerformMovement() 
    {
        if (velocity != Vector3.zero) 
        {
            _playerRb.MovePosition(_playerRb.position + velocity * Time.deltaTime);
        }
    
    }
}
