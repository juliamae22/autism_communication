using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ItemHit : MonoBehaviour, IInputClickHandler{

	// Called by GazeGestureManager when the user performs a Select gesture

	public void OnInputClicked(InputClickedEventData eventData)
	{

		if (!this.GetComponent<Rigidbody>())
		{
			var rigidbody = this.gameObject.AddComponent<Rigidbody>();
			rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
	}
}

