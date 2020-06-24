using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UFOMovement : MonoBehaviour
{
    [FormerlySerializedAs("LeftEngine")] public Rigidbody leftEngine;
    [FormerlySerializedAs("RightEngine")] public Rigidbody rightEngine;

    public float force = 20;
    public float rotateMultiplier = 0.5f;
    public AudioSource engineAudio;

    private UI_GamePlay uiGame;
    private float direction;

    private Vector3 leftForce = Vector3.zero;
    private Vector3 rightForce = Vector3.zero;

    private Rigidbody rb;
    void Awake()
    {
        uiGame = GetComponent<UI_GamePlay>();
        uiGame.SetMaxValueOfSlider(force);
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 minForce = Vector3.up * (force * rotateMultiplier);
        Vector3 maxForce = Vector3.up * force;
        
        if(Input.GetKey(Managers.Control.KeyCodes["PushUp"])){
            leftForce = maxForce;
            rightForce = maxForce;
            direction = 1;
            if(!engineAudio.isPlaying) engineAudio.Play();
        }
        else if(Input.GetKey(Managers.Control.KeyCodes["PushDown"])){
            leftForce = -maxForce;
            rightForce = -maxForce;
            direction = -1;
            if(!engineAudio.isPlaying) engineAudio.Play();
        }
        else{
            leftForce = Vector3.zero;
            rightForce = Vector3.zero;
        }

        //Разделил управление по осям для удобства игрока. 
        if(Input.GetKey(Managers.Control.KeyCodes["PushLeft"])){
            leftForce = maxForce * direction;
            rightForce = minForce * direction;   
            if(!engineAudio.isPlaying) engineAudio.Play();
        }
        else if(Input.GetKey(Managers.Control.KeyCodes["PushRight"])){
            leftForce = minForce * direction;
            rightForce = maxForce * direction;
            if(!engineAudio.isPlaying) engineAudio.Play();
        }

        if (leftForce == Vector3.zero && rightForce == Vector3.zero)
        {
            engineAudio.Stop();
        }
        
        uiGame.SetValueAltimeter(transform.position.y);
    }

    private void FixedUpdate()
    {
        leftEngine.AddRelativeForce(leftForce);
        rightEngine.AddRelativeForce(rightForce);
        uiGame.SetValueLeftEngine(Mathf.Abs(leftForce.y));
        uiGame.SetValueRightEngine(Mathf.Abs(rightForce.y));
        //uiGame.RotateDirectionPointer(-transform.rotation.eulerAngles.x);
        uiGame.DirectionUfo(rb.velocity);
    }
}

