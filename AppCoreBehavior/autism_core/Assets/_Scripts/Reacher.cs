using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reacher : MonoBehaviour {

    public float deltaPos;
    public Transform toyCar;
    public Transform toyDog;
    public Transform toyBall;
    public AudioSource audioSuccess;
    public AudioSource audioFail;

    private Rigidbody userHand;
    private bool rotateTrigger = false;

    //bool keyPen = false;
    //bool keyDog = false;
    //bool keyBall = false;


    // Use this for initialization
    void Start () {
        userHand = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) // Change this to: when gazing Car at && grabs
        {
            setNewPosition(toyCar);
        }
        if (Input.GetKeyDown(KeyCode.D)) // Change this to: when gazing Dog at && grabs
        {
            setNewPosition(toyDog);
        }
        if (Input.GetKeyDown(KeyCode.B)) // Change this to: when gazing Ball at && grabs
        {
            setNewPosition(toyBall);
        }

        if (rotateTrigger)
        {
            toyCar.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
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
            //toy.gameObject.SetActive(false);
        }

        if (toy.name == "ToyCar")
        {
            audioSuccess.Play();
            
            rotateTrigger = true;
        }
    }
}
