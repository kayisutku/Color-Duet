using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    private int imageNum = 1;
    public string screenShotName = "sample";

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot(screenShotName + imageNum + ".png");
            imageNum++;
        }
    }
}
