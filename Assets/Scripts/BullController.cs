using System;
using UnityEngine;
using UnityEngine.UI;

public class BullController : MonoBehaviour
{
    public float speed = 0;
    public float acceleration = 50.0f;
    public float deceleration = 40.0f;
    public bool startRunning;
    int count = 0;
    public Vector3 moveToTarget;
    public Vector3 realTarget;
    public int targetIndex;
    public GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void FixedUpdate()
    {
        if (startRunning)
        {
            count++;
            speed = speed + (acceleration * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, moveToTarget, speed * Time.deltaTime);
            if (transform.position.Equals(moveToTarget))
            {
                
                count = 0;
                if (gameController.CheckTarget(targetIndex) == true)
                {
                    return;
                }
                startRunning = false;
            }
        }
        else
        {
            count++;
            //if (speed - (deceleration * Time.deltaTime) > 0)
            //{
            speed = speed - (deceleration * Time.deltaTime);
            //}

            if (speed < 0 || transform.position.Equals(realTarget))
            {
                Debug.Log("xxxxx");
                speed = 0;

                gameController.ChaseEnemy();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, realTarget, speed * Time.deltaTime);
        }
    }

    private void Update()
    {
    }

    public void RunTo(int index, Vector3 target, Vector3 next) {
        speed = 0;
        acceleration = UnityEngine.Random.Range(10.0f, 12.0f);
        deceleration = acceleration - UnityEngine.Random.Range(0.0f, 2.0f);
        targetIndex = index;
        startRunning = true;
        moveToTarget = target;
        realTarget = next;
    }
}