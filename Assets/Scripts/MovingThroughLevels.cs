using UnityEngine;

public class MovingThroughLevels : MonoBehaviour {

	private GameObject item1;
	private GameObject item2;
	private GameObject item3;
	private GameObject stars;

	//private List<GameObject> itemList;
	private int level;
	private int stage;

	private bool spacebar;



	void Start () {
		item1 = GameObject.Find ("Item1");
		item2 = GameObject.Find ("Item2");
		item3 = GameObject.Find ("Item3");
		stars = GameObject.Find ("Stars");

		//itemList = new List<GameObject> ();

		item1.SetActive (false);
		item2.SetActive (false);
		item3.SetActive (false);

		level = 1;
		stage = 1;

	}
		
	void Update () {
		
		spacebar = Input.GetKeyUp (KeyCode.Space);


		if (spacebar) 
		{
			item1.SetActive (true);
		}

		//listening for click - for now we have a moust input
		//Vector3 click = Input.GetMouseButtonUp;

		//if (click)
		//{
			
	//	}


	}
}
