using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveController : MonoBehaviour
{
    public void Start()
    {
        string data = PlayerPrefs.GetString("SavedLevel", null);
        Button button = this.GetComponent<Button>();
        if (data != null && data == SceneManager.GetActiveScene().name)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
