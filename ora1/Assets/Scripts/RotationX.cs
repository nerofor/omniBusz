using UnityEngine;
using System.Collections;

public class RotationX : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate(Vector3.up, 2f,Space.World);
		this.gameObject.transform.Rotate(0,2,0);
	}
}
