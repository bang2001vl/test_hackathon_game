using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    public static string PlayerName = null;

    [SerializeField] InputField inputField;

    public void UpdatePlayerName()
    {
        PlayerName = inputField.text;
    }
}
