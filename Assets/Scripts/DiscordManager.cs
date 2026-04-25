using UnityEngine;
using UnityEngine.SceneManagement;
using Discord.SDK;

public class DiscordManager : MonoBehaviour
{
    public static DiscordManager Instance;

    [Header("Discord App ID")]
    [SerializeField] private long applicationId = 1497385328728870932;

    private Discord discord;

    void Awake()
    {
        // Singleton
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

        // Inicia Discord
        try
        {
            discord = new Discord(applicationId);
            Debug.Log("Discord conectado!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro Discord: " + e.Message);
        }

        // Escuta mudança de cena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        UpdateDiscordByScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (discord != null)
            discord.RunCallbacks();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateDiscordByScene(scene.name);
    }

    void UpdateDiscordByScene(string sceneName)
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
                SetPresence("Jogando", "Explorando o jogo", "logo");
                break;
        }
    }

    void SetPresence(string state, string details, string image)
    {
        if (discord == null) return;

        var activity = new Activity()
        {
            Name = "Race Low Poly",
            State = state,
            Details = details,
            Type = ActivityType.Playing
        };

        activity.Assets.LargeImage = image;
        activity.Assets.LargeText = "Race Low Poly";

        discord.GetActivityManager().UpdateActivity(activity, result =>
        {
            Debug.Log("Discord atualizado: " + details);
        });
    }

    void OnApplicationQuit()
    {
        if (discord != null)
        {
            discord.Dispose();
            discord = null;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}