using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBallMovement : MonoBehaviour
{
    public float ballSpeed = 6;
    Vector3 horizontalMovement;


    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        horizontalMovement = new Vector3(0f, 0f, ballSpeed * Time.deltaTime);
        transform.Translate(horizontalMovement);
    }
}
