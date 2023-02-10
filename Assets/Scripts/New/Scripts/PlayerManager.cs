using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;


public class PlayerManager : MonoBehaviour
{
    PhotonView photonView;
    GameObject controller;
 

    void Awake()
    {
        photonView = GetComponent<PhotonView>();

    }

    void Start()
    {

        if (photonView.IsMine)
        {
            CreateController();
        }
    }



    void CreateController()
    {
        if (PlayerInstance.localPlayerInstance == null)
        {           
             Transform spawn = SpawnManager.instance.GetSpawnPoints();
             controller= PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), spawn.position, spawn.rotation,0,new object[] { photonView.ViewID});                           

        }

    }

    public void Die() 
    {
        PhotonNetwork.Destroy(controller);
    
    }

}
