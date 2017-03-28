using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour {

    public GameObject player;
    private int offset = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, offset, player.transform.position.z);
    }

    public void deeper()
    {
        offset = offset - 10;
    }

}
