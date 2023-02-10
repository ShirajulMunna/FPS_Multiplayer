using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PManager : MonoBehaviourPunCallbacks
{
    public static PManager Instance;
    PhotonView photonView;
    private GameObject spawnedPlayer;

   // public ListOfTrainee listOfTrainee;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) 
        {
            CreateController();
        }
    }


    void CreateController() 
    {
      spawnedPlayer=  PhotonNetwork.Instantiate(Path.Combine("PhotonPrefs", "PlayerVR"), new Vector3(-38.90f,52,25), Quaternion.identity);
    }



    public override void OnLeftRoom()
    {
        Debug.Log("Deleted");
       // listOfTrainee.DeleteSessionInformation(Login.user_id);
     //   StartCoroutine(DestroyPlayer());
        PhotonNetwork.LoadLevel("Login");
        PhotonNetwork.Destroy(spawnedPlayer);
    }

  /*  IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(10f);
        PhotonNetwork.Destroy(spawnedPlayer);
    }
  */

    

    
}
