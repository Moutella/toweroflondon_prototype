using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        SphereController sphereController = other.gameObject.GetComponent<SphereController>();
        if (!sphereController.isHolding) { 
            sphereController.onPole = true;
            rb.useGravity = true;
        }
        other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, other.gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        SphereController sphereController = other.gameObject.GetComponent<SphereController>();
        sphereController.onPole = false;
    }
}
