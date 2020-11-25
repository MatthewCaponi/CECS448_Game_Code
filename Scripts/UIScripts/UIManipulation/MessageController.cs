using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
    public TMP_Text messageText;

    public void SetMessage(string message)
    {
        messageText.text = message;
    }

}
