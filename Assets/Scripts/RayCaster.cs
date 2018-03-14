using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    public float x;
    public float z;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(x,0,z);
        Debug.DrawRay(transform.position, fwd,Color.green);
        if (Physics.Raycast(transform.position, fwd, 100))
        { print("Something There"); }
        else
        { print("Some"); }
    }
}
