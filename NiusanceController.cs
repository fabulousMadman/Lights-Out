using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiusanceController : MonoBehaviour {

    public GameObject Player;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        float x = Player.transform.position.x - this.transform.position.x;
        float z = Player.transform.position.z - this.transform.position.z;
        Vector3 movement = new Vector3(x, 0, z);
        rb.AddForce(movement);
    }
}
