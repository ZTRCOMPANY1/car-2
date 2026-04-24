using UnityEngine;
using System.Diagnostics;
using System;

public class PerformanceMonitor : MonoBehaviour
{
    public bool mostrar = true;

    float deltaTime = 0.0f;

    void Update()
    {
        // FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // Toggle F3
        if (Input.GetKeyDown(KeyCode.F4))
        {
            mostrar = !mostrar;
        }
    }

    void OnGUI()
    {
        if (!mostrar) return;

        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 60;
        style.normal.textColor = Color.blue;

        float fps = 1.0f / deltaTime;

        // RAM (MB)
        long memoria = GC.GetTotalMemory(false) / (1024 * 1024);

        // CPU / GPU info
        string cpu = SystemInfo.processorType;
        string gpu = SystemInfo.graphicsDeviceName;

        string texto =
            $"FPS: {fps:0}\n" +
            $"RAM: {memoria} MB\n" +
            $"CPU: {cpu}\n" +
            $"GPU: {gpu}";

        GUI.Label(new Rect(135, 10, 500, 200), texto, style);
    }
}