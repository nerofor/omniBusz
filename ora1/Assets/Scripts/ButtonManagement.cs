using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;

public class ButtonManagement : MonoBehaviour {

    public GameObject camera;
    public GameObject newGameButton;
	public GameObject quitButton;
	bool newGameCanBeStarted;   
    public GameObject loadingButton;
    public GameObject settingsButton;

    public GameObject player;

    Stopwatch sw;

    
    GameObject cube;
    GameObject obj;

    bool alreadyDestroyed = false;

	void Start () {

        sw = new Stopwatch();
        sw.Start();

        cube = GameObject.Find("Cube");
	}
    public GameObject slider;

	void Update () {

        if (slideScrollGameCanBeStarted)
        {




        }



        if(newGameCanBeStarted)
        {
            if (alreadyDestroyed)
            {
                //-412   -72    394.4
                obj = (GameObject)Instantiate(cube, new Vector3(-412f, -72f, 394.4f), Quaternion.identity);

                sw = new Stopwatch();

                sw.Start();

                alreadyDestroyed = false;
            }
            if (sw.ElapsedMilliseconds > 3000f)
            {
                Destroy(obj);
                alreadyDestroyed = true;
                UnityEngine.Debug.Log("pusztitva");
            }

            if (obj != null)
            {
                obj.transform.position = new Vector3(obj.transform.position.x + slider.GetComponent<Slider>().value
                    , obj.transform.position.y, obj.transform.position.z);
                UnityEngine.Debug.Log("mozgat" + obj.transform.position.x);
            }
        }

		
	}
    public GameObject newGame2Button;
    public void NewGame()
    {
        
        camera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
        newGameButton.SetActive(false);
		newGameCanBeStarted = true;

        quitButton.SetActive(false);

        loadingButton.SetActive(false);
        settingsButton.SetActive(false);

    }
    public static bool slideScrollGameCanBeStarted;
    public void NewGame2()
    {
        camera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
        newGameButton.SetActive(false);
        

        //slider.SetActive(false);
        quitButton.SetActive(false);

        loadingButton.SetActive(false);
        settingsButton.SetActive(false);
        newGame2Button.SetActive(false);


        SaveLoad.Load();
        player.transform.position = new Vector3(SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].x,
            SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].y,
            SaveLoad.savedGame.positions[SaveLoad.savedGame.whichPosition].z);
        CameraControl.runOnlyOnce = false;

        slideScrollGameCanBeStarted = true;



    }

	public void Quit(){
		Application.Quit();
	}

}
