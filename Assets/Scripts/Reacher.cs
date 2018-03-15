using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reacher : MonoBehaviour {

    public float deltaPos;
	private GameObject item1;
	private GameObject item2;
	private GameObject item3;
	private GameObject gui;

	private Collider colliderItem1;
	private Collider colliderItem2;
	private Collider colliderItem3;
    
	private Vector3 itemLocation;

	private bool levelStarted = false;

	public AudioSource audioSuccess;
    public AudioSource audioFail;

    private Rigidbody userHand;
    private bool rotateTrigger = false;

	private int level = 1;
	private int stage = 1;

	public float x;
	public float z;

	//timers
	private float startRewardTime;
	private float elapsedRewardTime;

	private string itemSelected;

	void Awake()
	{
		startRewardTime = 0;
	}


	void Start () {
        
		userHand = GetComponent<Rigidbody>();

		item1 = GameObject.Find("Item 1");
		item2 = GameObject.Find("Item 2");
		item3 = GameObject.Find("Item 3");
		gui = GameObject.Find ("GUI");

		colliderItem1 = item1.GetComponent<Collider> ();
		colliderItem2 = item2.GetComponent<Collider> ();
		colliderItem3 = item3.GetComponent<Collider> ();

		item1.SetActive (false);
		item2.SetActive (false);
		item3.SetActive (false);
		gui.SetActive (true);

		colliderItem1.enabled = false;
		colliderItem2.enabled = false;
		colliderItem3.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
		if (startRewardTime > 0)
		{
			elapsedRewardTime = Time.time - startRewardTime;
		}

		if (elapsedRewardTime > 3.0f) 
		{
			userHand.position = new Vector3 (100,100,100);

			if (stage != 1) 
			{
				startRewardTime = 0;
				elapsedRewardTime = 0;
				SetLevelAndStage (level, stage);
			}
		}

		if (elapsedRewardTime > 5.0f) 
		{
			startRewardTime = 0;
			elapsedRewardTime = 0;

			//restart and begin next level
			if (stage == 1) 
			{
				Debug.Log ("test2");

				levelStarted = false;
				item1.SetActive (false);
				item2.SetActive (false);
				item3.SetActive (false);

				colliderItem1.enabled = false;
				colliderItem2.enabled = false;
				colliderItem3.enabled = false;
			}
		}

		if (!levelStarted) {
			
			if (Input.GetKeyDown (KeyCode.Q)) { // Change this to: when gazing Car && grabs
				//remove canvas
				item1.SetActive (true);
				colliderItem1.enabled = true;
				itemLocation = item1.transform.position;
				levelStarted = true;
				gui.SetActive (false);
				itemSelected = "Item1";
			}
			if (Input.GetKeyDown (KeyCode.W)) { // Change this to: when gazing Pew Pew && grabs
				//remove canvas
				item2.SetActive (true);
				colliderItem2.enabled = true;
				itemLocation = item2.transform.position;
				levelStarted = true;
				gui.SetActive (false);
				itemSelected = "Item2";

			}
			if (Input.GetKeyDown (KeyCode.E)) { // Change this to: when gazing Ball && grabs
				//remove canvas
				item3.SetActive (true);
				colliderItem3.enabled = true;
				itemLocation = item3.transform.position;
				levelStarted = true;
				gui.SetActive (false);
				itemSelected = "Item3";
			}
		} 
		else {
			//be looking out for racast ()
			if (Input.GetKeyDown (KeyCode.P)) 
			{
				setNewPosition (itemLocation);
				startRewardTime = Time.time;
				Debug.Log("stage" + stage);
				if (stage == 3) {
					level = level + 1;
					stage = 1;
				} 
				else {
					stage = stage + 1;
				}

			}
		}
    }

	void SetLevelAndStage (int level, int stage)
	{
		if (itemSelected == "Item1") {
			if (stage == 2) {
				item3.SetActive (true);
			}
			else if(stage == 3) {
				item2.SetActive (true);
			}
		} 
		else if (itemSelected == "Item2") {
			if (stage == 2) {
				item1.SetActive (true);
			}
			else if(stage == 3) {
				item3.SetActive (true);
			}
		} 
		else {
			if (stage == 2) {
				item1.SetActive (true);
			}
			else if(stage == 3) {
				item2.SetActive (true);
			}
		}

	}

	// move hand object to start animation
	void setNewPosition(Vector3 itemLocation)
    {
		userHand.position = itemLocation;
    }

	// reward event; animates toy and plays sound
    void OnTriggerEnter(Collider toy)
    {
            audioSuccess.Play();
    }
		
}
