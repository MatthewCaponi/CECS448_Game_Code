using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginController : MonoBehaviour
{
    public GameObject loginWindow;
    public GameObject registerWindow;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public MessageController errorMessage;
    public Button username;
    public Button loginButton;

    public void OpenLogin()
    {
        loginWindow.SetActive(true);
    }

    public void CloseLogin()
    {
        loginWindow.SetActive(false);
    }

    public void Login()
    {
        if (usernameInput.text=="")
        {
            errorMessage.SetMessage("Please input a username");
        }
        else if (passwordInput.text=="")
        {
            errorMessage.SetMessage("Please input a password");
        }
        else
        {
            username.GetComponentInChildren<TMP_Text>().text = usernameInput.text;
            username.gameObject.SetActive(true);
            loginButton.gameObject.SetActive(false);
            CloseLogin();
        }
    }
    public void ToRegister()
    {
        registerWindow.SetActive(true);
        loginWindow.SetActive(false);
    }
}
