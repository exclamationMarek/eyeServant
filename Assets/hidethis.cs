using UnityEngine;
using System.Collections;

public class hidethis : MonoBehaviour {


	public KeyCode trigger;
	private MeshRenderer rend;

	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (trigger)) {
			rend.enabled = !rend.enabled;
		}
	}
}
