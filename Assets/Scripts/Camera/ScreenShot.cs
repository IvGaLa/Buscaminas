using System;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public static void TakeScreenShot() => ScreenCapture.CaptureScreenshot($"{ConfigVariables.GetConfigValue<string>(ConfigTypes.TITLE)}-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
}