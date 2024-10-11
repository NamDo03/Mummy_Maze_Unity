using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public int currentLevel;

    void Start()
    {
        LoadLevel(currentLevel);
    }

    void LoadLevel(int levelIndex)
    {

        if (levelIndex >= 0 && levelIndex < levelPrefabs.Length)
        {
            Vector3 position = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.identity;

            Instantiate(levelPrefabs[levelIndex], position, rotation);
        }
        else
        {
            Debug.LogError("Invalid level index: " + levelIndex);
        }
    }
}
