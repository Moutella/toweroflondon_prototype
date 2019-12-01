using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public int ballNumber;
    public bool onPole;
    public bool isHolding;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        isHolding = true;
        rb.useGravity = false;
    }
    private void OnMouseUp()
    {
        isHolding = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHolding) { 
            var screenPoint = Input.mousePosition;
            screenPoint.z = 33.5f; //distance of the plane from the camera
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        }

    }
}
