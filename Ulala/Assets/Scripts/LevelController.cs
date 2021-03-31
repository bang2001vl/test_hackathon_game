using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] int levelBuildOrder;
    [SerializeField] int level;
    [SerializeField] TMPro.TMP_Text txtTimer;
    [SerializeField] TMPro.TMP_Text txtLevel;
    [SerializeField] Button btnPause;

    TimeSpan timeSpan;

    private void Start()
    {
        txtLevel.text = string.Format("Level : {0}", level);
        timeSpan = TimeSpan.FromMilliseconds(0);
    }

    public void clickPause()
    {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

    private void FixedUpdate()
    {
        timeSpan = timeSpan.Add(TimeSpan.FromSeconds(Time.fixedDeltaTime));
        txtTimer.SetText(string.Format("Time : {0}:{1}:{2}:{3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds));
    }

    public void EndLevel()
    {
        HighScoreController.Rows row = new HighScoreController.Rows();
        row.PlayerName = UserController.PlayerName;
        row.BestLevel = level;
        row.BestTime = (int)timeSpan.TotalMilliseconds;

    }
}
