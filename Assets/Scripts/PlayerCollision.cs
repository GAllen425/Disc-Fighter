using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerCollision : MonoBehaviour
{
    [SerializeField] bool logging = true;
    [SerializeField] private GameObject lastHit, currentHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (logging)
            {
                Debug.Log("Player collided with " + collision.gameObject.name);
            }
            currentHit = collision.gameObject;
        }
    }

    public void knockedOutOfRing ()
    {
        if (currentHit != lastHit)
        {
            currentHit.transform.localScale *= 2;
            lastHit = currentHit;
        }
    }
}
