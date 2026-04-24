using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public bool mostrarFPS = true;

    float deltaTime = 0.0f;

    void Update()
    {
        // Calcula o FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // Toggle com F3
        if (Input.GetKeyDown(KeyCode.F3))
        {
            mostrarFPS = !mostrarFPS;
        }
    }

    void OnGUI()
    {
        if (!mostrarFPS) return;

        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(135, 10, w, h * 0.02f);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = Color.blue;

        float fps = 1.0f / deltaTime;
        string text = string.Format("FPS: {0:0.}", fps);

        GUI.Label(rect, text, style);
    }
}