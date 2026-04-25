using UnityEngine;
using Discord.SDK;

public class DiscordManager : MonoBehaviour
{
    [Header("Discord App ID")]
    [SerializeField] private long applicationId = COLOQUE_SEU_ID;

    private Discord discord;

    void Start()
    {
        try
        {
            discord = new Discord(applicationId);

            Debug.Log("Discord conectado!");

            SetMenuPresence();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro Discord: " + e.Message);
        }
    }

    void Update()
    {
        if (discord != null)
        {
            discord.RunCallbacks();
        }
    }

    public void SetMenuPresence()
    {
        var activity = new Activity()
        {
            Name = "Race Low Poly",
            State = "No menu principal",
            Details = "Escolhendo opções",
            Type = ActivityType.Playing
        };

        activity.Assets.LargeImage = "logo";
        activity.Assets.LargeText = "Race Low Poly";

        discord.GetActivityManager().UpdateActivity(activity, result =>
        {
            Debug.Log("Rich Presence atualizado!");
        });
    }

    public void SetRacePresence(string mapa)
    {
        var activity = new Activity()
        {
            Name = "Race Low Poly",
            State = "Correndo",
            Details = "Mapa: " + mapa,
            Type = ActivityType.Playing
        };

        activity.Assets.LargeImage = "city";
        activity.Assets.LargeText = mapa;

        discord.GetActivityManager().UpdateActivity(activity, result =>
        {
            Debug.Log("Mapa atualizado!");
        });
    }

    void OnApplicationQuit()
    {
        if (discord != null)
        {
            discord.Dispose();
            discord = null;
        }
    }
}