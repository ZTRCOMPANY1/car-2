using UnityEngine;

public class CursorToggle : MonoBehaviour
{
    private bool cursorVisivel = false;

    void Start()
    {
        // Começa com cursor escondido e travado no centro
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Quando apertar ALT
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