using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightController : MonoBehaviour {

    private GameObject attachedObject;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        attachedObject = transform.parent.gameObject;
        offset = transform.position - attachedObject.transform.position;
        transform.position = attachedObject.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
