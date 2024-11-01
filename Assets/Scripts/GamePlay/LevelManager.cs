using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;

    void Start()
    {
        if (GameGlobal.level < levels.Length)
        {
            Vector3 position = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.identity;

            Instantiate(levels[GameGlobal.level], position, rotation);
        }
        else
        {
            Debug.LogError("Invalid level index: " + levels);
        }
    }
}
