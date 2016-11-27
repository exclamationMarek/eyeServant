using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class cup : MonoBehaviour {

	private GazeAware gaze;

	public Material notLookingAt;
	public Material lookingAt;

	public MeshRenderer targetMesh;

	public DemoController.demoSteps activeStep;

	private bool isBeingLookedAt;
	private float timestamp;

	public float delayTime = 0f;
	private bool triggered = false;

	public AudioSource ping;

	// Use this for initialization
	void Start () {
		gaze = gameObject.GetComponent<GazeAware> ();
		if(targetMesh == null){
			targetMesh = gameObject.GetComponent<MeshRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {


		if (triggered && Time.time > delayTime) {
			DemoController.AdvanceDemo ();
			gameObject.transform.Rotate (0.5f, 0.5f, 0.3f);
			isBeingLookedAt = false;
			triggered = false;
		}

		if (DemoController.step == activeStep) {
			if (isBeingLookedAt) {
				targetMesh.material = lookingAt;
				if (gaze.HasGazeFocus == false) {
					isBeingLookedAt = false;
				}
				if (Time.time - timestamp > 0.7f && triggered == false) {
					triggered = true;
					ping.Play ();
					delayTime += Time.time;
				} 

			} else {
				targetMesh.material = notLookingAt;
				if (gaze.HasGazeFocus) {
					isBeingLookedAt = true;
					timestamp = Time.time;
				}
			}
		}

	}
}
