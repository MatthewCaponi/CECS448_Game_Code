using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginViewItem : MonoBehaviour
{
    public GameObject Username;
    public GameObject Password;
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

    // Login using TextMeshPro
    public void Login(string Username, string Password)
    {
        this.Username.GetComponent<TextMeshPro>().text = Username;
        this.Password.GetComponent<TextMeshPro>().text = Password;


        if (usernameInput.text == "")
        {
            errorMessage.SetMessage("Please input a username");
        }
        else if (passwordInput.text == "")
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

    public void CloseLogin()
    {
        loginWindow.SetActive(false);
    }

    public void ToRegister()
    {
        registerWindow.SetActive(true);
        loginWindow.SetActive(false);
    }
}
