using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _animator;
    int velocityZHash;
    int velocityXHash;

    float velocityX = 0.0f;
    float velocityZ = 0.0f;

    public float accelaration = 2.0f;
    public float decelaration = 2.0f;
    public float maximumWalkVelocity = 1f;
    public float maximumRunVelocity = 2f;
    void Start()
    {
        _animator= GetComponent<Animator>();
        velocityZHash = Animator.StringToHash("Z_Velocity");
        velocityXHash = Animator.StringToHash("X_Velocity");
    }
    void LockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity) 
    {
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -1f && velocityX < 1f))
        {
            velocityX = 0.0f;
        }
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * decelaration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 1f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 1f))
        {
            velocityZ = currentMaxVelocity;
        }


    }

    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity) 
    {
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * accelaration;
        }
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * accelaration;
        }
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * accelaration;
        }
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * decelaration;
        }

       
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * decelaration;
        }
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * decelaration;
        }

    }

   
    void Update()
    {
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPress = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVelocity=runPressed? maximumRunVelocity : maximumWalkVelocity;


        ChangeVelocity(forwardPress, leftPressed, rightPress, runPressed, currentMaxVelocity);
        LockOrResetVelocity(forwardPress, leftPressed, rightPress, runPressed, currentMaxVelocity);

        _animator.SetFloat(velocityXHash, velocityX);
        _animator.SetFloat(velocityZHash, velocityZ);

    }
}
