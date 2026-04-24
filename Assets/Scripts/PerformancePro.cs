using UnityEngine;
using System;

public class PerformancePro : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    public string GetInfo()
    {
        float fps = 1.0f / deltaTime;

        long memoria = GC.GetTotalMemory(false) / (1024 * 1024);

        string cpu = SystemInfo.processorType;
        string gpu = SystemInfo.graphicsDeviceName;

        return
            $"FPS: {fps:0}\n" +
            $"RAM: {memoria} MB\n" +
            $"CPU: {cpu}\n" +
            $"GPU: {gpu}";
    }
}