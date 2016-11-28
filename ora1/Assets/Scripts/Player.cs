using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    void Start()
    {

    }

    bool selectedSniper=false;
    bool selectedCanon = false;
    bool shieldActivated;
    bool runOnlyOnce = false;
    bool iCanUseSniper = false;
    bool iCanUseCanon = false;


    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name == "Sniper")
        {
            iCanUseSniper = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "Canon")
        {
            iCanUseCanon = true;
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "StageElement")
        {
            youCanJump = true;
        }

        if (other.gameObject.name == "Collectible")
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + 10f, this.gameObject.transform.localScale.y + 10f
                , this.gameObject.transform.localScale.z + 10f);
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Shield")
        {


            if (!runOnlyOnce)
            {
                GameObject bla = other.gameObject;
                anotherShield = (GameObject)Instantiate(bla, new Vector3(this.gameObject.transform.position.x,
                    this.transform.position.y + 30f, this.transform.position.z), Quaternion.identity);
                anotherShield.transform.parent = this.gameObject.transform;
                other.gameObject.transform.parent = this.gameObject.transform;
                other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 30f,
                    this.gameObject.transform.position.y,
                    this.gameObject.transform.position.z);
                shieldObject = other;
                shieldActivated = true;
                runOnlyOnce = true;
            }


        }
    }


    bool youCanJump = true;
    Collider shieldObject;
    GameObject anotherShield;
    Vector3 worldPoint = Vector3.zero;
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (shieldActivated)
        {
            shieldObject.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.up, 10f);
            anotherShield.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.right, 10f);

            if (i > 20)
            {
                shieldObject.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 30f,
                    this.gameObject.transform.position.y,
                this.gameObject.transform.position.z);
                anotherShield.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y - 30f,
                    this.gameObject.transform.position.z);
                i = 0;
            }


        }


        Vector3 screenPoint = Input.mousePosition;

        screenPoint.z = transform.position.z;
        worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        Vector3 direction = worldPoint - transform.position;

         if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedCanon=false;
            selectedSniper=true;
            Debug.Log("Sniper Selected");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
		    selectedSniper=false;
            selectedCanon=true;
            Debug.Log("Canon Selected");
	    }

        if (selectedSniper==true)
        {
            if (iCanUseSniper && ButtonManagement.slideScrollGameCanBeStarted)
            {


                RaycastHit[] hits = Physics.RaycastAll(transform.position, direction);

                Debug.DrawLine(transform.position, worldPoint, Color.green);

                if (hits.Length > 0)
                {
                    print("sugaram: " + hits[0].transform.gameObject.name);

                    if (Input.GetMouseButtonDown(0) && hits[0].transform.gameObject.name == "Dummy")
                    {
                        Destroy(hits[0].transform.gameObject);
                    }
                }



            }
        }



        if (selectedCanon==true)
        {
                    if (iCanUseCanon && ButtonManagement.slideScrollGameCanBeStarted && Input.GetMouseButtonDown(0))
        {
            Vector3 bulletpos = new Vector3(transform.position.x + (50f * Vector3.Normalize(worldPoint - transform.position).x),
                transform.position.y + (50f * Vector3.Normalize(worldPoint - transform.position).y), transform.position.z);
            GameObject bullet = (GameObject)Instantiate(sphere, bulletpos, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().AddForce((worldPoint - transform.position) * 10f, ForceMode.Impulse);
        }
        }


        i = i + 1;
    }
    public GameObject sphere;
    float speed = 5000f;
    void FixedUpdate()
    {
        if (ButtonManagement.slideScrollGameCanBeStarted)
        {

            float moveHorizontal = Input.GetAxis("Horizontal");


            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            this.gameObject.GetComponent<Rigidbody>().AddForce(movement * speed);

            if (Input.GetKeyDown(KeyCode.Space) && youCanJump)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 200000f, 0.0f));
                youCanJump = false;
            }
        }



    }

}