using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject upBall;
    public GameObject downBall;

    public GameState GameState
    {
        get; private set;
    }

    private void Start()
    {
        upBall = GameObject.Find("Up Ball");
        downBall = GameObject.Find("Down Ball");
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
        if (!upBall.active && !downBall.active )
        {
            Invoke("ReStart", 1f);
        }    
    }

    private void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


public enum GameState
{
    start,
    playing,
    victory,
    defeat
}
