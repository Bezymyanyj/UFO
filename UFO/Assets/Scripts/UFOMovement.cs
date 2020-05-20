using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public Rigidbody LeftEngine;
    public Rigidbody RightEngine;

    public float force = 20;
    public float rotateMultiplier = 0.5f;


    // Update is called once per frame
    void Update()
    {
        Vector3 minForce = Vector3.up * force * rotateMultiplier;
        Vector3 maxForce = Vector3.up * force;

        Vector3 leftForce = Vector3.zero;
        Vector3 rightForce = Vector3.zero;

        if(Input.GetKey(KeyCode.W)){
            leftForce = maxForce;
            rightForce = maxForce;
        }
        if(Input.GetKey(KeyCode.A)){
            leftForce = maxForce;
            rightForce = minForce;            
        }
        else if(Input.GetKey(KeyCode.D)){
            leftForce = minForce;
            rightForce = maxForce;            
        }

        LeftEngine.AddRelativeForce(leftForce);
        RightEngine.AddRelativeForce(rightForce);
    }
}
