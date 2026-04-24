using UnityEngine;

public class PerformanceManager : MonoBehaviour
{
    public FPSDisplay fpsDisplay;
    public PerformancePro performancePro;

    public bool mostrar = true;

    int modo = 0; // 0 = simples | 1 = pro

    void Update()
    {
        // Mostrar / esconder
        if (Input.GetKeyDown(KeyCode.F3))
        {
            mostrar = !mostrar;
        }

        // Alternar modo
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

        if (modo == 0)
            texto = fpsDisplay.GetFPS();
        else
            texto = performancePro.GetInfo();

        GUI.Label(new Rect(10, 10, 600, 300), texto, style);
    }
}