using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    public string GetFPS()
    {
        float fps = 1.0f / deltaTime;
        return $"FPS: {fps:0}";
    }
}