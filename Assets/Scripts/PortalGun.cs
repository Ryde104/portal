using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public Camera fpsCam1;
    private RaycastHit LastRaycastHit;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Player;


    public object GetLookedAtObject()
    {
        Vector3 origin = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float range = 100;
        if (Physics.Raycast (origin,direction,out LastRaycastHit, range))
        {
            return LastRaycastHit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    private void TeleportToLookAt()
    {
        Portal1.transform.position = LastRaycastHit.point + LastRaycastHit.normal * 2;
    }
    private void TeleportToLookAt2()
    {
        Portal2.transform.position = LastRaycastHit.point + LastRaycastHit.normal * 2;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Pshoot1();          
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Pshoot2();
        }
    }


    //Portal1
    void Pshoot1()
     {
        if (GetLookedAtObject() != null)
        {
            TeleportToLookAt();
        }
    }

    void Pshoot2()
    {
        if (GetLookedAtObject() != null)
        {
            TeleportToLookAt2();
        }
    }
}
