using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerTarget : MonoBehaviour
{
    public float heath = 50f;
    PhotonView _photonView;

    PlayerManager _playerManager;

    private void Awake()
    {
        _photonView= GetComponent<PhotonView>();
        _playerManager = PhotonView.Find((int)_photonView.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    public void TakeDamage(float damage) 
    {
        _photonView.RPC("Rpc_TakeDamage", RpcTarget.All, damage);
     
    }
    [PunRPC]
    public void Rpc_TakeDamage(float damage) 
    {
        if (!_photonView.IsMine)
            return;
        heath -= (float)damage;
        if (heath <= 0f)
        {
            Die();
        }

    }

    public void Die() 
    {
        _playerManager.Die();
    }
    
    
}
