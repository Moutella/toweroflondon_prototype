using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    private GameController gameController;
    // Start is called before the first frame update
    public int pole;
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        SphereController sphere = other.gameObject.GetComponent<SphereController>();
        if(pole == 1) {
            gameController.stack1.Add(sphere.ballNumber);
            gameController.size1 += 1;
        }
        if (pole == 2)
        {
            gameController.stack2.Add(sphere.ballNumber);
            gameController.size2 += 1;
        }
        if (pole == 3)
        {
            gameController.stack3.Add(sphere.ballNumber);
            gameController.size3 += 1;
        }
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
        gameController.number_of_plays += 1;
        if (pole == 1)
        {
            gameController.stack1.RemoveAt(gameController.stack1.Count - 1);
            gameController.size1 -= 1;
        }
        if (pole == 2)
        {
            gameController.stack2.RemoveAt(gameController.stack2.Count - 1);
            gameController.size2 -= 1;
        }
        if (pole == 3)
        {
            gameController.stack3.RemoveAt(gameController.stack3.Count - 1);
            gameController.size3 -= 1;
        }
    }
}
