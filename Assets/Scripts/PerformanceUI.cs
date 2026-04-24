using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Diagnostics;

public class PerformanceUI : MonoBehaviour
{
    [Header("UI")]
    public GameObject painel;
    public TextMeshProUGUI texto;

    [Header("Graficos")]
    public RectTransform graficoFPS;
    public RectTransform graficoRAM;
    public GameObject pontoPrefab;

    List<GameObject> pontosFPS = new List<GameObject>();
    List<GameObject> pontosRAM = new List<GameObject>();

    float deltaTime = 0.0f;
    int maxPontos = 50;

    bool mostrar = true;

    // CPU %
    Process processo;
    float ultimoTempoCPU;
    float ultimoTempo;
    float cpuUso;

    void Start()
    {
        processo = Process.GetCurrentProcess();
        ultimoTempoCPU = (float)processo.TotalProcessorTime.TotalMilliseconds;
        ultimoTempo = Time.realtimeSinceStartup;
    }

    void Update()
    {
        // Toggle UI (F3)
        if (Input.GetKeyDown(KeyCode.F3))
        {
            mostrar = !mostrar;
            painel.SetActive(mostrar);
        }

        if (!mostrar) return;

        // FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // RAM (uso do jogo)
        long memoria = GC.GetTotalMemory(false) / (1024 * 1024);

        // VRAM (estimativa)
        int vramTotal = SystemInfo.graphicsMemorySize;
        int vramUso = (int)(UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() / (1024 * 1024));

        // CPU %
        float tempoAtual = Time.realtimeSinceStartup;
        float tempoCPUAtual = (float)processo.TotalProcessorTime.TotalMilliseconds;

        float deltaCPU = tempoCPUAtual - ultimoTempoCPU;
        float deltaTempo = (tempoAtual - ultimoTempo) * 1000f;

        cpuUso = (deltaCPU / (deltaTempo * SystemInfo.processorCount)) * 100f;

        ultimoTempoCPU = tempoCPUAtual;
        ultimoTempo = tempoAtual;

        // GPU % (estimado baseado em FPS)
        float gpuUso = Mathf.Clamp(100f - cpuUso, 0f, 100f);

        // Cor dinâmica FPS
        Color corFPS = Color.green;
        if (fps < 50) corFPS = Color.yellow;
        if (fps < 30) corFPS = Color.red;

        // TEXTO FINAL
        texto.text =
            $"<color=#{ColorUtility.ToHtmlStringRGB(corFPS)}>FPS: {fps:0}</color>\n" +
            $"CPU: {cpuUso:0}%\n" +
            $"GPU: {gpuUso:0}% (estimado)\n" +
            $"RAM: {memoria} MB\n" +
            $"VRAM: {vramUso} / {vramTotal} MB\n" +
            $"CPU: {SystemInfo.processorType}\n" +
            $"GPU: {SystemInfo.graphicsDeviceName}";

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