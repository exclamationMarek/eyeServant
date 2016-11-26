using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var pos = this.transform.position;
		pos.y += 0.01f;
		this.transform.position = pos;
	}
}
