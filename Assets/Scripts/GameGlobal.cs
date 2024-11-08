using TMPro;
using UnityEngine.SceneManagement;

public static class GameGlobal
{
    public static int level = 0;
    public static int highestLevelUnlocked = 0;
    public static TextMeshProUGUI messageText;

    public static void Play(int lv)
    {
        level = lv;
        Restart();
    }

    public static void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void WorldMap()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public static void ShowMessage(string message)
    {
        messageText.text = message;
    }

}
