using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedMenuController : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hideExitLevelDialog();
            hideHighScoreDialog();
        }
    }

    [SerializeField] GameObject exitLevelDialog;

    public void showExitLevelDialog()
    {
        exitLevelDialog.SetActive(true);
    }
    public void hideExitLevelDialog()
    {
        exitLevelDialog.SetActive(false);
    }


    [SerializeField] GameObject highScoreDialog;

    public void showHighScoreDialog()
    {
        highScoreDialog.SetActive(true);
    }

    public void hideHighScoreDialog()
    {
        highScoreDialog.SetActive(false);
    }


    public void ClickResume()
    {
        SceneManager.UnloadSceneAsync(1);
        Time.timeScale = 1;
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
