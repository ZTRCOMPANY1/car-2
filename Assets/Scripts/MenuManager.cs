using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void CarregarMapa1()
    {
        SceneManager.LoadScene("Mapa1");
    }

    public void CarregarMapa2()
    {
        SceneManager.LoadScene("Mapa2");
    }

    public void CarregarMapaPrincipal()
    {
        SceneManager.LoadScene("MapaPrin");
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}