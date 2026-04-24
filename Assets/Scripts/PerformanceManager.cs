using UnityEngine;

public class PerformanceManager : MonoBehaviour
{
    FPSDisplay fpsDisplay;
    PerformancePro performancePro;

    public bool mostrar = true;
    int modo = 0;

    void Start()
    {
        // Procura automaticamente na cena
        fpsDisplay = FindObjectOfType<FPSDisplay>();
        performancePro = FindObjectOfType<PerformancePro>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
            mostrar = !mostrar;

        if (Input.GetKeyDown(KeyCode.F2))
        {
            modo++;
            if (modo > 1) modo = 0;
        }
    }

    void OnGUI()
    {
        if (!mostrar) return;

        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.green;

        string texto = "";

        if (modo == 0 && fpsDisplay != null)
            texto = fpsDisplay.GetFPS();

        if (modo == 1 && performancePro != null)
            texto = performancePro.GetInfo();

        GUI.Label(new Rect(10, 10, 600, 300), texto, style);
    }
}