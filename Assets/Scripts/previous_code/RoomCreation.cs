using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class RoomCreation : MonoBehaviourPunCallbacks
{
    
    public Text roomUpdate;
    public GameObject PlayerListPref;
    public Transform playerListContent;
    public GameObject startGameBtn;

    public void OnClick_CreateRoom() 
    {

        ServerConnect.Instance.CreateRoom();

    
    }

    public override void OnJoinedRoom()
    {
       /* Player[] player = PhotonNetwork.PlayerList;
        for (int i = 0; i < player.Count(); i++) 
        {
            Instantiate(PlayerListPref, playerListContent).GetComponent<playerListItem>().SetPlayerData(player[i]);
        }

        roomUpdate.text = PhotonNetwork.CurrentRoom.Name;*/
        startGameBtn.SetActive(PhotonNetwork.IsMasterClient);
      //  Debug.Log("Nickname: " + Login.playerName);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PlayerListPref, playerListContent).GetComponent<playerListItem>().SetPlayerData(newPlayer);
    }
   
    /*public void OnClick_StartGame() 
    {
        ServerConnect.Instance.StartGame();
    
    }*/



   
}
