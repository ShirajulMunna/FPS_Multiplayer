using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject shootPoint;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioClip gunShot;

    [SerializeField] private AudioSource _audioSource;
    PhotonView _pView;


    private void Start()
    {
        _audioSource= GetComponent<AudioSource>();
        _pView= GetComponent<PhotonView>();
    }
    void Update()
    {
        if (!_pView.IsMine)
            return;
        
        if (Input.GetMouseButton(0)) 
        {
          _pView.RPC("Shoot",RpcTarget.All)  ;
        
        }
        
    }

    [PunRPC]
    public void Shoot() 
    {
        _audioSource.PlayOneShot(gunShot);
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);

           PlayerTarget target= hit.transform.GetComponent<PlayerTarget>();
           if (target != null) 
           {
                target.TakeDamage(10);
           }
            if (hit.collider.tag == "Player") 
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            }
            
        }
    
    }
}
