using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Security.Cryptography;
using UnityEngine;

public class bot : MonoBehaviour
{
    private Ball ballScript;
     
    float speed = 3f;
    Animator animator;
    public Transform ball;
    public Transform aimTarget;
    float force = 13;

    Vector3 targetposition;
    public Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
        targetposition = transform.position;    
        animator = GetComponent<Animator>();
        ballScript = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        targetposition.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetposition, speed*Time.deltaTime);
    }

    Vector3 PickTarget()
    {
        int randomValue = UnityEngine.Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = PickTarget()- transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 6, 0);

            Vector3 ballDir = ball.position - transform.position;
            if (ballDir.x > 0)
            {
                animator.Play("forehand");
                
                
                if (ballScript != null)
                {
                    ballScript.Flag = 0; 
                }
                UnityEngine.Debug.Log(ballScript.Flag);
            }
            else
            {
                animator.Play("backhand");
                
                if (ballScript != null)
                {
                    ballScript.Flag = 0; 
                }
                
                UnityEngine.Debug.Log(ballScript.Flag);

            }
        }
    }
}
