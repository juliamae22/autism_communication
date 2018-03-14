using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class OnClick : MonoBehaviour, IInputClickHandler{

	private GameObject player;
	private Collider collider;

	// Called by GazeGestureManager when the user performs a Select gesture
	void Start (){
		player = GameObject.Find("Player");
		collider = GetComponent<Collider> ();
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		if (collider.enabled)
		{
			player.transform.position = transform.position;
		}
	}

}

