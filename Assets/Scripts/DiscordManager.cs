using UnityEngine;
using UnityEngine.SceneManagement;
using Discord.Sdk;

public class DiscordManager : MonoBehaviour
{
    public static DiscordManager Instance;

    [Header("Discord Application ID")]
    [SerializeField] private ulong applicationId = 1497385328728870932;

    private Client client;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        try
        {
            client = new Client();
            Debug.Log("Discord conectado!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao conectar Discord: " + e.Message);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        UpdateDiscord(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateDiscord(scene.name);
    }

    void UpdateDiscord(string sceneName)
    {
        switch (sceneName)
        {
            case "MENU":
                SetPresence("No menu principal", "Escolhendo opções", "menu");
                break;

            case "MAPA1":
                SetPresence("Correndo", "Mapa 1", "mapa1");
                break;

            case "MAPA2":
                SetPresence("Correndo", "Mapa 2", "mapa2");
                break;

            case "MAPAPRIN":
                SetPresence("Correndo", "Mapa Principal", "mapaprin");
                break;

            case "MAPAPRIN(PISTA2)":
                SetPresence("Correndo", "Mapa Principal - Pista 2", "pista2");
                break;

            default:
                SetPresence("Jogando", "Explorando", "logo");
                break;
        }
    }

    void SetPresence(string state, string details, string image)
    {
        if (client == null) return;

        Activity activity = new Activity();
        activity.SetName("Race Low Poly");
        activity.SetType(ActivityTypes.Playing);
        activity.SetState(state);
        activity.SetDetails(details);

        ActivityAssets assets = new ActivityAssets();
        assets.SetLargeImage(image);
        assets.SetLargeText("Race Low Poly");

        activity.SetAssets(assets);

        client.UpdateRichPresence(activity, result =>
        {
            Debug.Log("Discord atualizado: " + details);
        });
    }

    void OnApplicationQuit()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        if (client != null)
        {
            client.Dispose();
            client = null;
        }
    }
}