using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLoginController : MonoBehaviour
{
    private PlayerModel playerModel;
    private PlayerLoginDataGateway dataGateway;

    public PlayerLoginController(PlayerModel playerModel, PlayerLoginDataGateway dataGateway)
    {
        this.playerModel = playerModel;
        this.dataGateway = dataGateway;
    }

    // Start is called before the first frame update
    private void Start()
    {
        //playerModel = new PlayerModel();
        dataGateway = new PlayerLoginDataGateway();
    }

}
