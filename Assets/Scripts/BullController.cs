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
    public GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {

        if (speed < 0)
        {
            return;
        }
        //else
        {

            if (startRunning)
            {
                count++;
                speed = speed + (acceleration * Time.deltaTime);
                //Debug.Log(speed);
                transform.position = Vector3.MoveTowards(transform.position, moveToTarget, speed * Time.deltaTime);
                if (transform.position.Equals(moveToTarget))
                {
                    Debug.Log("AAAA" + count.ToString());
                    count = 0;
                    startRunning = false;
                }
            }
            else
            {
                count++;
                speed = speed + (deceleration * Time.deltaTime);
                //Debug.Log(speed);
                if (speed < 0 || transform.position.Equals(realTarget))
                {
                    Debug.Log("BBBB " + count.ToString() + "  " + speed.ToString());
                    gameController.ChaseEnemy();
                    return;
                }
                transform.position = Vector3.MoveTowards(transform.position, realTarget, speed * Time.deltaTime);
            }

            //if (speed < 0 || transform.position.Equals(realTarget))
            //{
            //    Debug.Log("XXXXX");
            //    speed = 0;
            //    gameController.ChaseEnemy();
            //}
        }
    }

    public void RunTo(Vector3 target, Vector3 real) {
        speed = 0;
        startRunning = true;
        moveToTarget = target;
        realTarget = real;
    }
}