using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class gazemove : MonoBehaviour {



	private GazePoint gaze;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gaze = EyeTracking.GetGazePoint ();
		var v = gaze.Viewport * 10f;


		if (gaze.IsValid) {
			transform.position = new Vector3 (v.x, v.y, 0f);
		}

	}
}
