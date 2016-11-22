using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    //ORAI
    // Use this for initialization
    void Start()
    {

    }

    /*void OnTriggerEnter(Collider other)
    {
        
    }*/
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
                //itt csak elmentettem a colliderből kinyert változót egy gameobject változóba...
                //ennek sok értelme nincs, csak le akartam tesztelni valamit
                anotherShield = (GameObject)Instantiate(bla, new Vector3(this.gameObject.transform.position.x,
                    this.transform.position.y + 30f, this.transform.position.z), Quaternion.identity);
                anotherShield.transform.parent = this.gameObject.transform;
                //itt legeneráltam egy új objektumot, amit majd a függőleges pörgéshez akarok használni
                //átállítom a szülőjét a játékosra, hogy ez az objektum (a felvett) végig kövesse a játékost
                other.gameObject.transform.parent = this.gameObject.transform;
                //ezután amiről a másolatot csinálom, annál is átállítom a szülőt, hogy ő is
                //kövesse a játékost (ez az obj. fog vízszintesen pörögni
                other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 30f,
                    this.gameObject.transform.position.y,
                    this.gameObject.transform.position.z);
                //az anohershieldet úgy hoztuk ltére, hogy függőlegesen már el legyen tolva
                //ennek az eltolása itt következett be
                shieldObject = other;
                //kimentem a shieldobjectet is, hogy mind az anorhershieldet, mind a shieldobjectet
                //kívülről tudjuk használni (másik metódusból)
                shieldActivated = true;
                runOnlyOnce = true;
                //a runonlyonce-al azt a kivételt kezeljük le, hogy ha 
                //megnőtt a golyó, újra érintkezhetne a körülötte forgó objektummal
                //és ezt nem szeretnénk
                //a shieldActivateddel pedig az Update-ből kezeljük az objektumokat
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
            //ezekkel a sorokkal állítottam be azt, hogy mik körül forogjanak minden egyes képkockában (a felvétel után)
            //az objektumok
            //20 képkockánként állítok a pozíciójukon
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

        if (iCanUseCanon && ButtonManagement.slideScrollGameCanBeStarted && Input.GetMouseButtonDown(0))
        {
            Vector3 bulletpos = new Vector3(transform.position.x + (50f * Vector3.Normalize(worldPoint - transform.position).x),
                transform.position.y + (50f * Vector3.Normalize(worldPoint - transform.position).y), transform.position.z);
            GameObject bullet = (GameObject)Instantiate(sphere, bulletpos, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().AddForce((worldPoint - transform.position) * 10f, ForceMode.Impulse);
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
            //ha a bal nyilat megnyomom, akkor -1-et tárolok el benne
            //ha nem nyomok nyilat, akkor 0 van benne
            //ha jobbra nyomom a nyilat, akkor 1-es kerül bele

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