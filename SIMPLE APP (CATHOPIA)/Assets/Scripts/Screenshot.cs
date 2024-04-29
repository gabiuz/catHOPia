using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public void CaptureScreenshotOnClick()
    {
        ScreenCapture.CaptureScreenshot("CatHOPia-" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", 6);
    }
}
