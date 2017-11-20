using UnityEngine;
using System.Collections;

public class BubbleFloat : MonoBehaviour {



    public float FloatStrength;
    public float MaxRotationStrength;
    private float randomXrot;
    private float randomYrot;
    private float randomZrot;
    
	// Use this for initialization
	void Start () {
        randomXrot = Random.Range(-MaxRotationStrength, MaxRotationStrength);
        randomYrot = Random.Range(-MaxRotationStrength, MaxRotationStrength);
        randomZrot = Random.Range(-MaxRotationStrength, MaxRotationStrength);

//        Rigidbody body = GetComponent(typeof(Rigidbody)) as Rigidbody;
        //body.AddForce(-Physics.gravity * body.mass);
  //      body.AddForce(-2*Physics.gravity, ForceMode.Acceleration);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(randomXrot, randomYrot, randomZrot);
        Rigidbody body = GetComponent(typeof(Rigidbody)) as Rigidbody;
        //body.AddForce(-Physics.gravity * body.mass);
        //body.AddForce(-Physics.gravity, ForceMode.Acceleration);
    }
}
