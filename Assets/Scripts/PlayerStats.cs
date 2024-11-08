using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    private float playTime;      
    private int stepCount;       

    private bool isPlaying;

    public TextMeshProUGUI stepText;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        playTime = 0f;
        stepCount = 0;
        isPlaying = true;

        StartCoroutine(TrackPlayTime());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void AddStep()
    {
        stepCount++;
    }
    public void MinusStep()
    {
        stepCount--;
    }
    private IEnumerator TrackPlayTime()
    {
        while (isPlaying)
        {
            playTime += Time.deltaTime;  
            yield return null;
        }
    }

    private void UpdateUI()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + "\n" + GetPlayTime();
        }

        if (stepText != null)
        {
            stepText.text = "Steps: " + stepCount;
        }
    }

    private string GetPlayTime()
    {
        int minutes = Mathf.FloorToInt(playTime / 60F);
        int seconds = Mathf.FloorToInt(playTime % 60F);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopGame()
    {
        isPlaying = false;
    }
}
