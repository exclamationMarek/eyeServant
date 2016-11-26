using UnityEngine;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
public class SpinOnGaze : MonoBehaviour 
{
	private GazeAware _gazeAware;

	void Start()
	{
		_gazeAware = GetComponent<GazeAware>();
	}

	void Update()
	{
		if (_gazeAware.HasGazeFocus)
		{
			transform.Rotate(Vector3.forward);
		}
	}
}	