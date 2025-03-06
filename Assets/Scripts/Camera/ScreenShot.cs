using System;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public static void TakeScreenShot()
    {
#if !UNITY_EDITOR // Don't create screenshot on debug mode
        string title = ConfigVariables.GetConfigValue<string>(ConfigTypes.TITLE);
        string dateFormat = DateTime.Now.ToString(ConfigVariables.GetConfigValue<string>(ConfigTypes.DATE_FORMAT));
        string extension = ConfigVariables.GetConfigValue<string>(ConfigTypes.SCREENSHOT_EXTENSION);
        // Replace ":" por "_"
        string screenshot = $"{title}-{dateFormat}{extension}".Replace(":", "_");
        ScreenCapture.CaptureScreenshot(screenshot);
#endif
    }
}