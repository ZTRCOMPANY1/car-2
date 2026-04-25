using UnityEngine;

public class DiscordManager : MonoBehaviour
{
    [SerializeField] string applicationId = "1497385328728870932";

    void Start()
    {
        Debug.Log("Discord iniciado!");
    }

    public void SetMenu()
    {
        Debug.Log("Status: Menu Principal");
    }

    public void SetRace()
    {
        Debug.Log("Status: Correndo");
    }
}