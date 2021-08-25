using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject redBall;
    public GameObject blueBall;

    private void Start()
    {
        redBall = GameObject.Find("Red Ball");
        blueBall = GameObject.Find("Blue Ball");
    }
    void Update()
    {
        ReStartLevel();
        FailCheck();
    }
    public void ReStartLevel()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void FailCheck()
    {
        if (!redBall.active && !blueBall.active )
        {
            Invoke("ReStart", 1f);
        }    
    }

    private void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

