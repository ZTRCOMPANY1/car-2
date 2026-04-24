using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapa1UI : MonoBehaviour
{
    public GameObject painelMapa1;

    public void AbrirMapa1()
    {
        painelMapa1.SetActive(true);
    }

    public void FecharMapa1()
    {
        painelMapa1.SetActive(false);
    }

    public void EntrarMapa1()
    {
        SceneManager.LoadScene("MAPA1");
    }
}