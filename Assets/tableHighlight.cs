using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;
using UnityEngine.UI;


public class tableHighlight : MonoBehaviour {

	private Camera cam;

	public GameObject table;
	public GameObject cube;

	public GameObject cup;
	public GameObject landingZone;
	public GameObject audiance;

	 
	public UnityEngine.UI.Text dtext;

	private Vector3 target;


	private GazePoint gaze;

	private float smoothing = 2f;


	private LayerMask lmask = 0x01;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		DemoController.step = DemoController.demoSteps.calibration;
	}
		
		
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		var dstatus = "status:\n";
		dstatus += DemoController.step.ToString () + "\n";
		gaze = EyeTracking.GetGazePoint ();
		var presence = EyeTracking.GetUserPresence ();

		if (presence.IsUserPresent) {
			dstatus += "user present\n";
		} else {
			dstatus += "user absent\n";
		}

		//get the target if valid
		if (gaze.IsValid) {
			dstatus += "gaze VALID\n";
			dstatus += "x: " + gaze.Screen.x.ToString () + " y: " + gaze.Screen.y.ToString () + "\n";
			Ray ray = cam.ScreenPointToRay (new Vector3 (gaze.Screen.x, gaze.Screen.y, 0f));

			Debug.DrawRay (ray.origin, ray.direction * 5f, Color.red, 1f);

			if (Physics.Raycast (ray, out hit, 10f, lmask)) {
				target = hit.point;
			}

		} else {
			dstatus += "gaze INVALID\n";
		}

		//smoothed move
		var smoothedPosition = cube.transform.position;
		smoothedPosition += (target - smoothedPosition) * Time.deltaTime * smoothing;
		cube.transform.position = smoothedPosition;

		//smoothing options
		if (Input.GetKeyDown (KeyCode.UpArrow) && smoothing <10f) {
			smoothing += 0.5f;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && smoothing > 1f) {
			smoothing -= 0.5f;
		}


		if(Input.GetKeyDown(KeyCode.Alpha1)){
			cup.transform.position = cube.transform.position;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2)){
			landingZone.transform.position = cube.transform.position;
		}

		if(Input.GetKeyDown(KeyCode.Alpha3)){
			audiance.transform.position = cube.transform.position;
		}

		if(Input.GetKeyDown(KeyCode.P)){
			ArduinoSend.WriteToArduino ("n");
		}

		if(Input.GetKeyDown(KeyCode.Z)){
			DemoController.setStep(DemoController.demoSteps.calibration);
		}

		if(Input.GetKeyDown(KeyCode.X)){
			DemoController.setStep(DemoController.demoSteps.pickup);
		}

		if(Input.GetKeyDown(KeyCode.C)){
			DemoController.setStep(DemoController.demoSteps.place);
		}

		if(Input.GetKeyDown(KeyCode.V)){
			DemoController.setStep(DemoController.demoSteps.audience);
		}


		dstatus += "smoothing: " + smoothing.ToString () + "\n";


		dstatus += "cubeX: " + cube.transform.position.x.ToString() + "\n";
		dstatus += "cubeX scaled: " + ((int) ((cube.transform.position.x + 3) * 30)).ToString() + "\n";

		dtext.text = dstatus;
	}
}
