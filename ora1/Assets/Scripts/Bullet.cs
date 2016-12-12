using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    static public int damage = 35;
    
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "StageELement")
        {
            Destroy(this.gameObject);
        }*/
       
    }
   
	// Update is called once per frame
	void Update () {
        
    }
}
