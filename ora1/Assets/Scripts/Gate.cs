using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
    
    bool decrease;

	void Start () {
	
	}
	void Update () {
        if (!decrease)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y + 2f, this.transform.localScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - 2f, this.transform.localScale.z);
        }

        if (this.transform.localScale.y >= 100 || this.transform.localScale.y <= 17)
        {
            decrease = !decrease;
        }
	}
}
