using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
	void Start () {
	
	}

    /*void OnTriggerEnter(Collider other)
    {
        
    }*/
    int Score;
	bool shieldActivated;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StageElement")
        {
            youCanJump = true;
        }

        //if (other.gameObject.name == "Collectible")
        //{
        //    this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + 10f, this.gameObject.transform.localScale.y+10f
        //        , this.gameObject.transform.localScale.z+10f);
        //    this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z);
        //    other.gameObject.SetActive(false);
        //}
		if (other.gameObject.tag == "Shield") {
			other.gameObject.transform.parent = this.gameObject.transform;
			other.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x + 30f, this.gameObject.transform.position.y,
				this.gameObject.transform.position.z);
			other.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.up, 10f);
			shielfObject = other;
			shieldActivated = true;
		}

        if (other.gameObject.tag == "Collectible")
        {
            Score++;
            other.gameObject.SetActive(false);
        }
    }

    bool youCanJump = true;
	Collider shielfObject;
	GameObject anotherShield;
	int i = 0;
	// Update is called once per frame
	void Update () {
		if (shieldActivated) {
			shielfObject.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.up, 10f);
			//anotherShild.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.right, 10f);
			//if (i>20) {
			//	shieldObject.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x +30f,
			//		this.gameObject.transform.position.y,
			//		this.gameObject.transform.position.z);
			//	anotherShield.gameObject.transform.position=new Vector3(this.gameObject.transform.position.x,
			//		this.gameObject.transform.position.y -30f,
			//		this.gameObject.transform.position.z);
			//	i=0;
			//}
		}
	}
    float speed = 5000f;
    void FixedUpdate()
    {
        if(ButtonManagement.slideScrollGameCanBeStarted)
        {

            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            this.gameObject.GetComponent<Rigidbody>().AddForce(movement * speed);

            if (Input.GetKeyDown(KeyCode.Space) && youCanJump)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 200000f, 0.0f));
                youCanJump = false;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                this.gameObject.transform.position = new Vector3(SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].x,
            SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].y,
            SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].z);
            }
        }


        
    }

}
