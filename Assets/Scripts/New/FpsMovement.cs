using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FpsMovement : MonoBehaviour
{
   
    public float speed = 5f;

    private PlayerMotor _playerMotor;
    
   
    PhotonView photonView;
    PlayerManager _playerManager;

    void Awake() 
    {
        photonView = GetComponent<PhotonView>();
        _playerMotor = GetComponent<PlayerMotor>();
        _playerManager = PhotonView.Find((int)photonView.InstantiationData[0]).GetComponent<PlayerManager>();


    }

    void Start()
    {
        if (!photonView.IsMine) 
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        
        }
    }

    void Update()
    {
        if (!photonView.IsMine) 
        {
            return;
        }
       
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 _velocity = (transform.right * x + transform.forward * z).normalized * speed;

        _playerMotor.Move(_velocity);

        if (transform.position.y < -10f) 
        {
            _playerManager.Die();
        }

      
    }
}
