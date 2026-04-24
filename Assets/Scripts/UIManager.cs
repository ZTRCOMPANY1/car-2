using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelSelecao;
    public GameObject painelConfirmacao;

    [Header("Mapa (Imagem única)")]
    public Image imagemMapa;
    public Sprite spritePista1;
    public Sprite spritePista2;

    private Pista pistaSelecionada;

    public enum Pista
    {
        Nenhuma,
        Pista1,
        Pista2
    }

    // =========================
    // ABRIR MENU DE SELEÇÃO
    // =========================
    public void AbrirSelecao()
    {
        painelSelecao.SetActive(true);
        painelConfirmacao.SetActive(false);

        pistaSelecionada = Pista.Nenhuma;
    }

    // =========================
    // FECHAR MENU DE SELEÇÃO
    // =========================
    public void FecharSelecao()
    {
        painelSelecao.SetActive(false);
    }

    // =========================
    // SELECIONAR PISTA 1
    // =========================
    public void SelecionarPista1()
    {
        pistaSelecionada = Pista.Pista1;

        painelConfirmacao.SetActive(true);

        // troca imagem do mapa
        imagemMapa.sprite = spritePista1;
    }

    // =========================
    // SELECIONAR PISTA 2
    // =========================
    public void SelecionarPista2()
    {
        pistaSelecionada = Pista.Pista2;

        painelConfirmacao.SetActive(true);

        // troca imagem do mapa
        imagemMapa.sprite = spritePista2;
    }

    // =========================
    // CANCELAR (voltar)
    // =========================
    public void Cancelar()
    {
        painelConfirmacao.SetActive(false);

        // NÃO desativa botão nenhum
        // só volta pra seleção
        painelSelecao.SetActive(true);

        pistaSelecionada = Pista.Nenhuma;
    }

    // =========================
    // ENTRAR NA PISTA
    // =========================
    public void Entrar()
    {
        if (pistaSelecionada == Pista.Nenhuma)
        {
            Debug.Log("Nenhuma pista selecionada!");
            return;
        }

        switch (pistaSelecionada)
        {
            case Pista.Pista1:
                SceneManager.LoadScene("MAPAPRIN");
                break;

            case Pista.Pista2:
                SceneManager.LoadScene("MAPAPRIN(PISTA2)");
                break;
        }
    }
}