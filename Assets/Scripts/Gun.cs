using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    public Camera fpsCam;
    public Material red;
    public Material Trans;
    public GameObject Object;
    public GameObject Object2;
    public LayerMask groundMask;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            shoot();

        }


    }
    void shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {      
            if (hit.collider.tag == "Enemy")
            {
                StartCoroutine(CourseCoroutine());
                Object.GetComponent<MeshRenderer>().material = red;
                Object2.GetComponent<MeshRenderer>().material = red;
            }     

            Debug.Log(hit.transform.name);

           enemy enemy = hit.transform.GetComponent<enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

        }

    }
    IEnumerator CourseCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        Object.GetComponent<MeshRenderer>().material = Trans;
        Object2.GetComponent<MeshRenderer>().material = Trans;
    }
}
