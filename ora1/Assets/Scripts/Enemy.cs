using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            
            Destroy(gameObject);
            
        }

       // if (other.gameObject.name == "Collectible")
       // {
       //     this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + 10f, this.gameObject.transform.localScale.y + 10f
       //         , this.gameObject.transform.localScale.z + 10f);
       //     this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z);
       //     other.gameObject.SetActive(false);
       // }
       // if (other.gameObject.tag == "Shield")
       // {
       //     other.gameObject.transform.parent = this.gameObject.transform;
       //     other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 30f, this.gameObject.transform.position.y,
       //         this.gameObject.transform.position.z);
       //     other.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.up, 10f);
       //     shielfObject = other;
       //     shieldActivated = true;
       // }
    }



	void Start () {
	
	}
	
	void Update () {
	
	}
}
