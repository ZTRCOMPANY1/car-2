using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class PerformanceUI : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public RectTransform grafico;

    public GameObject pontoPrefab;

    List<GameObject> pontos = new List<GameObject>();

    float deltaTime = 0.0f;
    int maxPontos = 50;

    bool mostrar = true;

    void Update()
    {
        // Toggle
        if (Input.GetKeyDown(KeyCode.F3))
            mostrar = !mostrar;

        gameObject.SetActive(mostrar);

        // FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // RAM
        long memoria = GC.GetTotalMemory(false) / (1024 * 1024);

        // Texto
        texto.text =
            $"FPS: {fps:0}\n" +
            $"RAM: {memoria} MB\n" +
            $"CPU: {SystemInfo.processorType}\n" +
            $"GPU: {SystemInfo.graphicsDeviceName}";

        AtualizarGrafico(fps);
    }

    void AtualizarGrafico(float fps)
    {
        if (pontos.Count > maxPontos)
        {
            Destroy(pontos[0]);
            pontos.RemoveAt(0);
        }

        GameObject ponto = Instantiate(pontoPrefab, grafico);
        pontos.Add(ponto);

        RectTransform rt = ponto.GetComponent<RectTransform>();

        float altura = Mathf.Clamp(fps, 0, 120);

        rt.anchoredPosition = new Vector2(pontos.Count * 5, altura);

        for (int i = 0; i < pontos.Count; i++)
        {
            pontos[i].GetComponent<RectTransform>().anchoredPosition =
                new Vector2(i * 5, pontos[i].GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
}