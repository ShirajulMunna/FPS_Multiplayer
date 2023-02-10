using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class ServerConnect : MonoBehaviourPunCallbacks
{
    public static ServerConnect Instance;

    public Text updateTxt;
    public Text roomNameText;
    public InputField roomNameInputField;

    [SerializeField] private Transform roomListContent;
    [SerializeField] private GameObject roomListItemPrefab;
    [SerializeField] private Transform playerListContent;
    [SerializeField] private GameObject playerListPrefab;
    [SerializeField] private GameObject startButton;

    void Awake()
    {
        
            Instance = this;
                   
        
    }

   
    void Start()
    {      
        PhotonNetwork.ConnectUsingSettings();
        updateTxt.text = "Connecting To Server";

        
    }

    public override void OnConnectedToMaster()
    {
        updateTxt.text = "Connected To Master";
      
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnJoinedLobby()
    {
        updateTxt.text = "Joined On Lobby";
        PhotonNetwork.NickName = "Player" +UnityEngine.Random.Range(0,100).ToString("000");
          
    }

    public void CreateRoom() 
    {
        if (string.IsNullOrEmpty(roomNameInputField.text)) 
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
              
        
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed");
    }
   
    public void joinedRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
       
    }
    public override void OnJoinedRoom()
    {
       
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListPrefab, playerListContent).GetComponent<PlayerList>().SetupPlayerName(players[i]);
        }

        startButton.SetActive(PhotonNetwork.IsMasterClient);

    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public void LeaveRoom() 
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        updateTxt.text = "Retrun To Lobby.Left From Room";
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().Setup(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListPrefab, playerListContent).GetComponent<PlayerList>().SetupPlayerName(newPlayer);
    }
    public void StartGame() 
    {
        PhotonNetwork.LoadLevel(1);
    }







}
