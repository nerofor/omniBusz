using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
           
            other.gameObject.SetActive(false);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
