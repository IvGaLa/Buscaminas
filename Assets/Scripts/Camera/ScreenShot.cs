using System;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public static void TakeScreenShot()
    {
        string title = ConfigVariables.GetConfigValue<string>(ConfigTypes.TITLE);
        string dateFormat = DateTime.Now.ToString(ConfigVariables.GetConfigValue<string>(ConfigTypes.DATE_FORMAT));
        string extension = ConfigVariables.GetConfigValue<string>(ConfigTypes.SCREENSHOT_EXTENSION);
        // Replace ":" for "_"
        string screenshot = $"{title}-{dateFormat}{extension}".Replace(":", "_");
        ScreenCapture.CaptureScreenshot(screenshot);
    }
}