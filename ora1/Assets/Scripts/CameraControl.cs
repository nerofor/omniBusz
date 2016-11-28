using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    Vector3 offset;
    public static bool runOnlyOnce;

	void Start () {
	    
	}

    public GameObject player;
	// Update is called once per frame
	void Update () {
	    if(ButtonManagement.slideScrollGameCanBeStarted)
        {
            if (!runOnlyOnce)
            {
                //this.transform.position ugyanúgy a scriptet tartalmazó objektumra vonatkozik, mint
                //a transform.position

                //Vector3 newCameraPosition = new Vector3(393f, 0f, -10f);
                Vector3 newCameraPosition = player.transform.position;


                this.transform.position = newCameraPosition;
                offset = transform.position - player.transform.position;
                runOnlyOnce = true;
            }

            //transform.position = player.transform.position + offset;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z - 200f);
        }
	}
}
