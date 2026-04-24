using UnityEngine;

public class ToggleCameraKey : MonoBehaviour
{
    public GameObject cameraAlvo;
    public KeyCode tecla = KeyCode.C;

    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            cameraAlvo.SetActive(!cameraAlvo.activeSelf);
        }
    }
}