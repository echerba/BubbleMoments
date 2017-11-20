using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(SteamVR_TrackedObject))]
public class BubbleGun : MonoBehaviour {

    [Tooltip("This is the object that will be spawned")]
    public GameObject bubbleObject;

    [Tooltip("Bubble Spawn location")]
    public Vector3 position;

    [Tooltip("Maximum scale that the bubble can reach, generally between 1 and 2.")]
    public float MaxScale = 2f;

    [Tooltip("Time in seconds the bubble should live")]
    public float BubbleTime = 20f;

    [Tooltip("Time in MS for a bubble to hit max size")]
    public float MaxBlowTime = 5f;

    [Tooltip("Speed that the bubble launches at")]
    public float LaunchSpeed = 1.5f;
    // Use this for initialization
    //private SteamVR_TrackedObject bubbleGun;
    private SteamVR_TrackedController bubbleGun;

    private GameObject newBubble;
    private float timeblowing;

    private void OnEnable () {
        //bubbleGun = GetComponent<SteamVR_TrackedObject>();
        bubbleGun = GetComponent<SteamVR_TrackedController>();
        if (bubbleGun == null)
        {
            Debug.Log("Component not found");
        }
        else
        {
            bubbleGun.TriggerClicked += StartBlowBubble;
            bubbleGun.TriggerUnclicked += FinishBlowBubble;
        }
    }
    private void OnDisable()
    {
        bubbleGun.TriggerClicked -= StartBlowBubble;
        bubbleGun.TriggerUnclicked -= FinishBlowBubble;
    }
    void StartBlowBubble(object sender, ClickedEventArgs e)
    {
        Debug.Log("Trigger Pressed");
        newBubble = Instantiate(bubbleObject, transform);
        newBubble.transform.Translate(position);
        newBubble.transform.parent = this.transform;
        newBubble.GetComponent<Rigidbody>().isKinematic = false;
        timeblowing = 0;
    }

    void FinishBlowBubble(object sender, ClickedEventArgs e)
    {
        if (newBubble)
        {
            Debug.Log("Trigger UnPressed");
            newBubble.GetComponent<Rigidbody>().velocity = newBubble.transform.parent.forward * LaunchSpeed;
            newBubble.transform.parent = null;

            Destroy(newBubble, (float)BubbleTime);
            newBubble = null;
        }
        else
        {
            Debug.Log("BubbleAlreadyFinished shouldn't happen.");
        }
    }
    // Update is called once per frame
    void Update () {
        if(newBubble)
        {
            timeblowing += Time.deltaTime;

            Debug.LogFormat("TimeBlowing {0}, tVale {1}", timeblowing, timeblowing / MaxBlowTime);

            //Scale up based on time till we hit max.
            float newScale = Mathf.Lerp(1, MaxScale, timeblowing/MaxBlowTime);
            Debug.LogFormat("scaling bubble: {0}",newScale);
            newBubble.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}
