using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
    public Text countText;
    public Text winText;
    public int jump;
    public GameObject shadow;

    private Rigidbody rb;
    private int count;
    private bool grounded;
    private bool level2 = false;
    private bool level2finished = false;
    private bool level3 = false;
    private bool level3finished = false;
    private bool level4 = false;
    private bool level4finished = false;
    private bool level5 = false;
    private bool level5finished = false;
    private GameObject WallsLevel1;
    private GameObject WallsLevel2;
    private GameObject WallsLevel3;
    private GameObject WallsLevel4;
    private GameObject LevelLight1;
    private GameObject LevelLight2;
    private GameObject LevelLight3;
    private GameObject GroundStage1;
    private GameObject StageFinished1;
    private GameObject PickupsLevel1;
    private GameObject ObstaclesLevel1;
    private GameObject PickupsLevel2;
    private GameObject ObstaclesLevel2;
    private GameObject PickupsLevel3;
    private GameObject ObstaclesLevel3;
    private GameObject PickupsLevel4;
    private GameObject ObstaclesLevel4;
    private GameObject Stage1;


    void Start ()
	{

		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        winText.text = "";
        WallsLevel1 = GameObject.Find("Walls Level 1");
        WallsLevel2 = GameObject.Find("Walls Level 2");
        WallsLevel3 = GameObject.Find("Walls Level 3");
        WallsLevel4 = GameObject.Find("Walls Level 4");

        Stage1 = GameObject.Find("Stage 1");

        GroundStage1 = GameObject.Find("Ground Stage 1");
        for (int i = 0; i < GroundStage1.transform.childCount; ++i)
        {
            if (GroundStage1.transform.GetChild(i).gameObject.name == "Level Light 1")
            {
                LevelLight1 = GroundStage1.transform.GetChild(i).gameObject;
            }
            if (GroundStage1.transform.GetChild(i).gameObject.name == "Level Light 2")
            {
                LevelLight2 = GroundStage1.transform.GetChild(i).gameObject;
            }
            if (GroundStage1.transform.GetChild(i).gameObject.name == "Level Light 3")
            {
                LevelLight3 = GroundStage1.transform.GetChild(i).gameObject;
            }
        }
        for (int i = 0; i < GameObject.Find("Stage 1").transform.childCount; ++i)
        {
            if(GameObject.Find("Stage 1").transform.GetChild(i).gameObject.name == "Stage Finished 1")
            {
                StageFinished1 = GameObject.Find("Stage Finished 1").transform.GetChild(i).gameObject;
            }
        }

        for (int i = 0; i < GameObject.Find("Stage 1").transform.childCount; ++i)
        {
            if (Stage1.transform.GetChild(i).name == "Pickups Level 1") { PickupsLevel1 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Pickups Level 2") { PickupsLevel2 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Pickups Level 3") { PickupsLevel3 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Pickups Level 4") { PickupsLevel4 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Obstacles Level 1") { ObstaclesLevel1 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Obstacles Level 2") { ObstaclesLevel2 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Obstacles Level 3") { ObstaclesLevel3 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Obstacles Level 4") { ObstaclesLevel4 = Stage1.transform.GetChild(i).gameObject; }
            if (Stage1.transform.GetChild(i).name == "Stage Finished 1") { StageFinished1 = Stage1.transform.GetChild(i).gameObject; }
        }

        PickupsLevel2.SetActive(false);
        ObstaclesLevel2.SetActive(false);
        PickupsLevel3.SetActive(false);
        ObstaclesLevel3.SetActive(false);
        PickupsLevel4.SetActive(false);
        ObstaclesLevel4.SetActive(false);
        StageFinished1.gameObject.SetActive(false);

    }

	void Update()
	{
        if (count == 12 && level2 == false)
        {
               level2 = true;
               setLevel(level2, 2);
        }
        else if (count < 12 && level2 && level2finished == false)
        {
                level2 = false;
                setLevel(level2, 2);
        }
        if (count == 13 && level3 == false)
        {
                level3 = true;
                setLevel(level3, 3);
        }
        else if (count < 13 && level3 && level3finished == false)
        {
                level3 = false;
                setLevel(level3, 3);
        }
        if (count == 14 && level4 == false)
        {
            level4 = true;
            setLevel(level4, 4);
        }
        else if (count < 14 && level4 && level4finished == false)
        {
            level4 = false;
            setLevel(level4, 4);
        }
        if (count == 13 && level5 == false && level4finished)
        {
            level5 = true;
            StageFinished1.SetActive(true);
        }
        else if (count < 13 && level5 && level5finished == false)
        {
            level5 = false;
            StageFinished1.SetActive(false);
        }
    }

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        int moveRect;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            moveRect = jump;
        }
        else
        {
            moveRect = 0;
        }

        Vector3 movement = new Vector3 (moveHorizontal, moveRect, moveVertical);

		rb.AddForce (movement * speed);
        

	}
    


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.name == "East Wall Trigger" && other.transform.parent.gameObject.name == "Walls Level 1")
        {
            count = 0;
            other.gameObject.SetActive(false);
            level2finished = true;
        }
        if (other.gameObject.name == "North Wall Trigger" && other.transform.parent.gameObject.name == "Walls Level 2")
        {
            count = 0;
            other.gameObject.SetActive(false);
            level3finished = true;
        }
        if (other.gameObject.name == "North Wall Trigger" && other.transform.parent.gameObject.name == "Walls Level 3")
        {
            count = 0;
            other.gameObject.SetActive(false);
            level4finished = true;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (collision.transform.GetChild(0).gameObject.activeSelf)
            {
                count = count + 1;
                SetCountText();
            }
            if (collision.transform.GetChild(0).gameObject.activeSelf == false)
            {
                count = count - 1;
                SetCountText();
            }
        }
        if (collision.gameObject.CompareTag("WallLevel2") && level2)
        {
            collision.gameObject.SetActive(false);
            LevelLight1.SetActive(false);
            for (int i = 0; i < WallsLevel2.transform.childCount; ++i)
            {
                if (WallsLevel2.transform.GetChild(i).gameObject.name == "Ceiling")
                {
                    WallsLevel2.transform.GetChild(i).gameObject.SetActive(false);
                }
                if (WallsLevel2.transform.GetChild(i).gameObject.name == "South Wall")
                {
                    WallsLevel2.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            PickupsLevel2.SetActive(true);
            ObstaclesLevel2.SetActive(true);
        }
        if (collision.gameObject.CompareTag("WallLevel3") && level3)
        {
            collision.gameObject.SetActive(false);
            LevelLight2.SetActive(false);
            for (int i = 0; i < WallsLevel3.transform.childCount; ++i)
            {
                if (WallsLevel3.transform.GetChild(i).gameObject.name == "Ceiling")
                {
                    WallsLevel3.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            PickupsLevel3.SetActive(true);
            ObstaclesLevel3.SetActive(true);
        }
        if (collision.gameObject.CompareTag("WallLevel4") && level4)
        {
            collision.gameObject.SetActive(false);
            LevelLight3.SetActive(false);
            for (int i = 0; i < WallsLevel3.transform.childCount; ++i)
            {
                if (WallsLevel3.transform.GetChild(i).gameObject.name == "Ceiling")
                {
                    WallsLevel3.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            PickupsLevel4.SetActive(true);
            ObstaclesLevel4.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Stage Finished"))
        {
            collision.gameObject.SetActive(false);
            GroundStage1.SetActive(false);
            WallsLevel1.SetActive(false);
            WallsLevel2.SetActive(false);
            WallsLevel3.SetActive(false);
            WallsLevel4.SetActive(false);
            PickupsLevel1.SetActive(false);
            PickupsLevel2.SetActive(false);
            PickupsLevel3.SetActive(false);
            PickupsLevel4.SetActive(false);
            ObstaclesLevel1.SetActive(false);
            ObstaclesLevel2.SetActive(false);
            ObstaclesLevel3.SetActive(false);
            ObstaclesLevel4.SetActive(false);
            shadow.SendMessage("deeper");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
    
    
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count == 12)
        {
            
        }
    }

    void setLevel(bool activate, int level)
    {
        for (int i = 0; i < GroundStage1.transform.childCount; ++i)
        {
            if (level == 2)
            {
                if (GroundStage1.transform.GetChild(i).name == "Level Light 1" && activate)
                {
                    GroundStage1.transform.GetChild(i).gameObject.SetActive(true);
                }
                else if (GroundStage1.transform.GetChild(i).name == "Level Light 1" && !activate)
                {
                    GroundStage1.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            else if (level == 3)
            {
                if (GroundStage1.transform.GetChild(i).name == "Level Light 2" && activate)
                {
                    GroundStage1.transform.GetChild(i).gameObject.SetActive(true);
                }
                else if (GroundStage1.transform.GetChild(i).name == "Level Light 2" && !activate)
                {
                    GroundStage1.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            else if (level == 4)
            {
                if (GroundStage1.transform.GetChild(i).name == "Level Light 3" && activate)
                {
                    GroundStage1.transform.GetChild(i).gameObject.SetActive(true);
                }
                else if (GroundStage1.transform.GetChild(i).name == "Level Light 3" && !activate)
                {
                    GroundStage1.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}