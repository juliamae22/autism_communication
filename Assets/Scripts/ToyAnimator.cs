using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyAnimator : MonoBehaviour {

    private bool rotate = false;
    public float delta;
    public Vector3 RotationDirection;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() 
	{
        if (rotate)
        {
        	transform.Rotate(RotationDirection * Time.deltaTime * delta);
        }
    }

    void OnTriggerEnter(Collider toy)
    {
        rotate = true;
    }

	void OnTriggerExit(Collider toy)
	{
		rotate = false;
	}
}
