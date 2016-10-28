using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {

        other.gameObject.transform.position = new Vector3(SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].x,
            SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].y,
            SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].z);

    }
}
