using System;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public static void TakeScreenShot() => ScreenCapture.CaptureScreenshot($"Buscaminas-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
}