using UnityEngine;

public class CursorToggle : MonoBehaviour
{
    // Começa com cursor visível
    private bool cursorVisivel = true;

    void Start()
    {
        // Cursor aparece já no início
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Detecta ALT esquerdo ou direito
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cursorVisivel = !cursorVisivel;

            if (cursorVisivel)
            {
                // Mostra cursor
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                // Esconde cursor
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}