using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class bot : MonoBehaviour
{

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
                int flag = 1;
                UnityEngine.Debug.Log("bot hit "+flag);
            }
            else
            {
                animator.Play("backhand");
                int flag = 1;
                UnityEngine.Debug.Log("Player spawned");

            }
        }
    }
}
