using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reacher : MonoBehaviour {

    public float deltaPos;
    public Transform toyCar;
    public Transform toyPen;
    public Transform toyBall;
    public AudioSource audioSuccess;
    public AudioSource audioFail;

    private Rigidbody userHand;
    private bool rotateTrigger = false;
    static private bool reachCar = false;
    private bool reachPen = false;
    private bool reachBall = false;

    //bool keyPen = false;
    //bool keyDog = false;
    //bool keyBall = false;


    // Use this for initialization
    void Start () {
        userHand = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) // Change this to: when gazing Car && grabs
        {
            reachCar = true;
            reachPen = false;
            reachBall = false;
        }
        if (Input.GetKeyDown(KeyCode.D)) // Change this to: when gazing Dog && grabs
        {
            reachCar = false;
            reachPen = true;
            reachBall = false;
        }
        if (Input.GetKeyDown(KeyCode.V)) // Change this to: when gazing Ball && grabs
        {
            reachCar = false;
            reachPen = false;
            reachBall = true;
        }

        if (reachCar)
        {
            setNewPosition(toyCar);
        }

        if (reachPen)
        {
            setNewPosition(toyPen);
        }
        if (reachBall)
        {
            setNewPosition(toyBall);
        }
    }

    void setNewPosition(Transform toy)
    {
        Vector3 diffPos = new Vector3((toy.position.x - userHand.position.x) * deltaPos, (toy.position.y - userHand.position.y) * deltaPos, (toy.position.z - userHand.position.z) * deltaPos);
        userHand.position = userHand.position + diffPos;
    }

    // Reward event. Correct animate toy and play sound. Incorrect play sound.
    void OnTriggerEnter(Collider toy)
    {
        if (toy.gameObject.CompareTag("Toy"))
        {
            Debug.Log("Reached " + toy.name);
        }

        if (toy.name == "ToyDog")
        {
            audioFail.Play();
        }

        if (toy.name == "ToyCar")
        {
            audioSuccess.Play();
        }
    }
}
