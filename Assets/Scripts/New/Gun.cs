using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject shootPoint;
    public ParticleSystem muzzleFlash;


    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Shoot();
        
        }
        
    }

    public void Shoot() 
    {
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
        }
    
    }
}
