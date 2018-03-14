using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyAnimator : MonoBehaviour {

    public bool rotate = false;
    public float delta;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (rotate)
        {
        transform.Rotate(Vector3.up * Time.deltaTime * delta);
        }
    }

    void OnTriggerEnter(Collider toy)
    {
        rotate = true;
        
    }
}
