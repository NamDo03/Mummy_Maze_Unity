using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PyramidButton : MonoBehaviour
{
    public int level;

    void OnMouseUpAsButton()
    {
        if (level > GameGlobal.highestLevelUnlocked)
        {
            GameObject messageTextObj = GameObject.FindGameObjectWithTag("Level");
            GameGlobal.messageText = messageTextObj.GetComponent<TextMeshProUGUI>();
            GameGlobal.ShowMessage($"You must complete Level {GameGlobal.highestLevelUnlocked} before playing Level {level}");
            StartCoroutine(RemoveMessage());
        }
        else
        {
            GameGlobal.Play(level);
        }
    }

    private IEnumerator RemoveMessage()
    {
        yield return new WaitForSeconds(3f);
        GameGlobal.messageText.text = "";
    }
}
