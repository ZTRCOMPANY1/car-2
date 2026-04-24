using UnityEngine;
using System.IO;

public class ScreenshotSystem : MonoBehaviour
{
    public KeyCode teclaPrint = KeyCode.F11;

    void Update()
    {
        if (Input.GetKeyDown(teclaPrint))
        {
            // Pega a pasta "Imagens" do Windows
            string pastaImagens = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);

            // Cria caminho: Imagens/Race Low Poly/Capturas
            string pasta = Path.Combine(pastaImagens, "Race Low Poly", "Capturas");

            // Cria a pasta se não existir
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            // Nome do arquivo
            string nomeArquivo = "print_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

            string caminhoCompleto = Path.Combine(pasta, nomeArquivo);

            // Tira o print
            ScreenCapture.CaptureScreenshot(caminhoCompleto);

            Debug.Log("Print salvo em: " + caminhoCompleto);
        }
    }
}