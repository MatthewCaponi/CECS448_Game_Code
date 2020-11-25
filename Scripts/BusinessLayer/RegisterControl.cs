using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RegisterControl : MonoBehaviour
{
    public GameObject registerWindow;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;
    public MessageController errorMessage;
    public Button username;
    public Button loginButton;

    public void OpenRegister()
    {
        registerWindow.SetActive(true);
    }

    public void CloseRegister()
    {
        registerWindow.SetActive(false);
    }

    public void Register()
    {
        if (usernameInput.text == "")
        {
            errorMessage.SetMessage("Please input a username");
        }
        else if (passwordInput.text == "")
        {
            errorMessage.SetMessage("Please input a password");
        }
        else if (passwordInput.text != confirmPasswordInput.text)
        {
            errorMessage.SetMessage("The two passwords do not match");
        }
        else
        {
            username.GetComponentInChildren<TMP_Text>().text = usernameInput.text;
            username.gameObject.SetActive(true);
            loginButton.gameObject.SetActive(false);
            CloseRegister();
        }
    }
}
