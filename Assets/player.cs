using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;
    bool hitting;
    float force = 13;
    Animator animator;
    public Transform ball;
    private Ball ballScript;
    Vector3 aimTargetInitialPosition;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();    
        aimTargetInitialPosition = aimTarget.position;
        // Check that 'ball' has been assigned in the Inspector before trying to use it.
        if (ball != null)
        {
            ballScript = ball.GetComponent<Ball>();
        }
        else
        {
            UnityEngine.Debug.LogError("Player script: The 'Ball' Transform is not assigned in the Inspector!");
        }

        // Add a check to see if the component was found
        if (ballScript == null)
        {
            UnityEngine.Debug.LogError("Player script: Could not find the 'Ball' component on the assigned Ball object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting = true;
        }else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false;
        }

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed*2 * Time.deltaTime);
        }

        if ((h != 0 || v != 0) && !hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position ;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0,5,0);

            Vector3 ballDir = ball.position - transform.position;
            if (ballDir.x > 0)
            {
                animator.Play("forehand");
                int flag = 0;
                UnityEngine.Debug.Log("player hit");
                if (ballScript != null )
                {
                    ballScript.Flag = 1; 
                }
                UnityEngine.Debug.Log(ballScript.Flag);
            }
            else if (ballDir.x < 0)
            {
                animator.Play("backhand");
                
                UnityEngine.Debug.Log("player hit");
                if (ballScript != null )
                {
                    ballScript.Flag = 1; 
                }
                UnityEngine.Debug.Log(ballScript.Flag);
            }
            aimTarget.position = aimTargetInitialPosition;
        }
    }
}
