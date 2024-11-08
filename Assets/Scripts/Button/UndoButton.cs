using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoButton : MonoBehaviour
{
    private LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        levelController = FindObjectOfType<LevelController>();

        if (levelController == null)
        {
            Debug.LogError("LevelController not found!");
        }
    }

    void OnMouseUpAsButton()
    {
        if (levelController != null)
        {
            levelController.Undo(); 
        }
    }
}
