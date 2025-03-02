using System;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public static void TakeScreenShot() => ScreenCapture.CaptureScreenshot($"Buscaminas-{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.png");
}