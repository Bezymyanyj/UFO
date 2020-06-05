using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public Rigidbody LeftEngine;
    public Rigidbody RightEngine;

    public float force = 20;
    public float rotateMultiplier = 0.5f;

    private UI_GamePlay uiGame;

    Vector3 leftForce = Vector3.zero;
    Vector3 rightForce = Vector3.zero;

    void Awake()
    {
        uiGame = GetComponent<UI_GamePlay>();
        uiGame.SetMaxValueOfSlider(force);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 minForce = Vector3.up * force * rotateMultiplier;
        Vector3 maxForce = Vector3.up * force;
        
        if(Input.GetKey(KeyCode.W)){
            leftForce = maxForce;
            rightForce = maxForce;
        }
        else if(Input.GetKey(KeyCode.S)){
            leftForce = -minForce;
            rightForce = -minForce;
        }
        else{
            leftForce = Vector3.zero;
            rightForce = Vector3.zero;
        }

        //Разделил управление по осям для удобства игрока. 
        if(Input.GetKey(KeyCode.A)){
            leftForce = maxForce;
            rightForce = minForce;            
        }
        else if(Input.GetKey(KeyCode.D)){
            leftForce = minForce;
            rightForce = maxForce;            
        }
        
        uiGame.SetValueAltimeter(transform.position.y);
    }

    private void FixedUpdate()
    {
        LeftEngine.AddRelativeForce(leftForce);
        RightEngine.AddRelativeForce(rightForce);
        uiGame.SetValueLeftEngine(Mathf.Abs(leftForce.y));
        uiGame.SetValueRightEngine(Mathf.Abs(rightForce.y));
    }
}

