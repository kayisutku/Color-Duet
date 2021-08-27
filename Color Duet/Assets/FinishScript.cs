using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject horizontalBallMovement1;
    public GameObject horizontalBallMovement2;
    public GameObject horizontalBallMovement3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallController>())
        {
            horizontalBallMovement1.GetComponent<HorizontalBallMovement>().ballSpeed = 0;
            horizontalBallMovement2.GetComponent<HorizontalBallMovement>().ballSpeed = 0;
            horizontalBallMovement3.GetComponent<HorizontalBallMovement>().ballSpeed = 0;
        }
    }
}
