using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porterTeleporter : MonoBehaviour
{

    public Transform player;
    public Transform reciever;
    public GameObject target;


    public bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime);
        if (playerIsOverlapping)
        {
            StartCoroutine(Portal());
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {

                // Teleport him!
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);
                //transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.deltaTime * 1);
                

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
    IEnumerator Portal()
    {
        yield return new WaitForSeconds(0.3f);

    }
}
    