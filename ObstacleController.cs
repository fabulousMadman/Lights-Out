using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {


    private bool activated = false;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool wasActivated()
    {
        return activated;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.gameObject.CompareTag("Enemy"))
        {
            if (activated == false)
            {
                for (int i = 0; i < this.transform.childCount; ++i)
                {
                    this.transform.GetChild(i).gameObject.SetActive(false);
                }
                activated = true;
            }
            else if (activated)
            {
                for (int i = 0; i < this.transform.childCount; ++i)
                {
                    this.transform.GetChild(i).gameObject.SetActive(true);
                }
                activated = false;
            }
        }
        
    }
}
