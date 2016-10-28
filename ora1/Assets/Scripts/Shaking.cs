using UnityEngine;
using System.Collections;

public class Shaking : MonoBehaviour {

	// Use this for initialization
    bool increase = true;
    bool stay = false;
    float x;
    int i = 0;
	void Start () {
        x = 1109f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!stay)
        {
            if (increase)
            {
                this.transform.Translate(2f, 0f, 0f);
                x += 2f;
            }
            if (!increase)
            {
                this.transform.Translate(-2f, 0f, 0f);
                x -= 2f;
            }
        }

        if (x <= 1109)
        {
            increase = true;
            stay = true;
        }
        if (x >= 1344)
        {
            increase = false;
            stay = true;
        }
        if (stay)
        {
            i = i + 1;
            if (i >= 120)
            {
                i = 0;
                stay = false;

            }
        }
	}
}
