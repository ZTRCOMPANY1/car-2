using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapa2UI : MonoBehaviour
{
    public GameObject painelMapa2;

    public void AbrirMapa2()
    {
        painelMapa2.SetActive(true);
    }

    public void FecharMapa2()
    {
        painelMapa2.SetActive(false);
    }

    public void EntrarMapa2()
    {
        SceneManager.LoadScene("MAPA2");
    }
}