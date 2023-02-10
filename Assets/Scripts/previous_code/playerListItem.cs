using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class playerListItem : MonoBehaviourPunCallbacks
{
    Player player;
    public Text text;
    public void SetPlayerData(Player _player ) 
    {
        player = _player;
        text.text = _player.NickName;
    
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (player == otherPlayer) 
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
