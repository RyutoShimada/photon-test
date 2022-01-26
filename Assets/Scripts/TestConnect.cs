using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    

    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PhotonNetwork.Disconnect();
        }
    }

    /// <summary>
    /// マスターサーバーへ接続成功したら呼ばれる
    /// </summary>
    public override void OnConnectedToMaster()
    {
        //print("Connectd to server.");
        //print(PhotonNetwork.LocalPlayer.NickName);
        Debug.Log("Connectd to Photon.", this);

        Debug.Log("My nickname is ." + PhotonNetwork.LocalPlayer.NickName, this);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    /// <summary>
    /// マスターサーバーからの接続が切れたら呼ばれたら
    /// </summary>
    /// <param name="cause"></param>
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server for reason " + cause.ToString(), this);
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby");
    }
}
