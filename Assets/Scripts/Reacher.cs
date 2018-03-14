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

    // Use this for initialization
    void Start () {
        
		userHand = GetComponent<Rigidbody>();

		item1 = GameObject.Find("Item 1");
		item2 = GameObject.Find("Item 2");
		item3 = GameObject.Find("Item 3");
		gui = GameObject.Find ("GUI");

		colliderItem1 = GetComponent<Collider> ();
		colliderItem2 = GetComponent<Collider> ();
		colliderItem3 = GetComponent<Collider> ();

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
        
		if (!levelStarted) {
			
			if (Input.GetKeyDown (KeyCode.Q)) { // Change this to: when gazing Car && grabs
				//remove canvas
				item1.SetActive (true);
				colliderItem1.enabled = true;
				itemLocation = item1.transform.position;
				levelStarted = true;
				gui.SetActive (false);
			}
			if (Input.GetKeyDown (KeyCode.W)) { // Change this to: when gazing Dog && grabs
				//remove canvas
				item2.SetActive (true);
				colliderItem2.enabled = true;
				itemLocation = item2.transform.position;
				levelStarted = true;
				gui.SetActive (false);
			}
			if (Input.GetKeyDown (KeyCode.E)) { // Change this to: when gazing Ball && grabs
				//remove canvas
				item3.SetActive (true);
				colliderItem3.enabled = true;
				itemLocation = item3.transform.position;
				levelStarted = true;
				gui.SetActive (false);
			}
		} 
		else {
			//be looking out for racast ()
			if (Input.GetKeyDown (KeyCode.P)) 
			{
				setNewPosition (itemLocation);

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
