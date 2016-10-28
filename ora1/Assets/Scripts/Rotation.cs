using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //this.gameObject.transform.localEulerAngles = new Vector3(this.transform.rotation.x+10f, this.transform.rotation.y, this.transform.rotation.z);
        this.gameObject.transform.Rotate(Vector3.up, 10f,Space.World);
	}
}
