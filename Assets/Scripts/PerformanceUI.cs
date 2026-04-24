using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class PerformanceUI : MonoBehaviour
{
    [Header("UI")]
    public GameObject painel;
    public TextMeshProUGUI texto;

    [Header("Gráficos")]
    public RectTransform graficoFPS;
    public RectTransform graficoRAM;
    public GameObject pontoPrefab;

    List<GameObject> pontosFPS = new List<GameObject>();
    List<GameObject> pontosRAM = new List<GameObject>();

    float deltaTime = 0.0f;
    int maxPontos = 50;

    bool mostrar = true;
    bool modoDev = true;

    void Update()
    {
        // Toggle UI
        if (Input.GetKeyDown(KeyCode.F3))
            mostrar = !mostrar;

        // Modo Dev / Player
        if (Input.GetKeyDown(KeyCode.F1))
            modoDev = !modoDev;

        painel.SetActive(mostrar);

        if (!mostrar) return;

        // FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // RAM
        long memoria = GC.GetTotalMemory(false) / (1024 * 1024);

        // Cor dinâmica FPS
        Color corFPS = Color.green;
        if (fps < 50) corFPS = Color.yellow;
        if (fps < 30) corFPS = Color.red;

        // Texto
        if (modoDev)
        {
            texto.text =
                $"<color=#{ColorUtility.ToHtmlStringRGB(corFPS)}>FPS: {fps:0}</color>\n" +
                $"RAM: {memoria} MB\n" +
                $"CPU: {SystemInfo.processorType}\n" +
                $"GPU: {SystemInfo.graphicsDeviceName}";
        }
        else
        {
            texto.text =
                $"<color=#{ColorUtility.ToHtmlStringRGB(corFPS)}>FPS: {fps:0}</color>";
        }

        AtualizarGrafico(fps, pontosFPS, graficoFPS, 120);
        AtualizarGrafico(memoria, pontosRAM, graficoRAM, 8000);
    }

    void AtualizarGrafico(float valor, List<GameObject> lista, RectTransform grafico, float maxValor)
    {
        if (lista.Count > maxPontos)
        {
            Destroy(lista[0]);
            lista.RemoveAt(0);
        }

        GameObject ponto = Instantiate(pontoPrefab, grafico);
        lista.Add(ponto);

        RectTransform rt = ponto.GetComponent<RectTransform>();

        float altura = Mathf.Clamp(valor, 0, maxValor);
        altura = (altura / maxValor) * grafico.sizeDelta.y;

        rt.anchoredPosition = new Vector2(lista.Count * 5, altura);

        for (int i = 0; i < lista.Count; i++)
        {
            var p = lista[i].GetComponent<RectTransform>();
            p.anchoredPosition = new Vector2(i * 5, p.anchoredPosition.y);
        }
    }
}