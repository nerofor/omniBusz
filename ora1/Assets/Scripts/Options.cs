using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {


    public static float speed;

    public GameObject slider;
    public GameObject sliderValue;

    public GameObject backToMenu;
    public GameObject loadingButton;
    public GameObject settingsButton;
    public GameObject newGameButton;

    public GameObject camera;

    public GameObject quitButton;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Setting()
    {
        slider.SetActive(true);
        sliderValue.GetComponent<Text>().enabled = true;

        loadingButton.SetActive(false);
        settingsButton.SetActive(false);
        backToMenu.SetActive(true);
        newGameButton.SetActive(false);
        quitButton.SetActive(false);
    }
    public void BackToMenu()
    {
        slider.SetActive(false);
        sliderValue.GetComponent<Text>().enabled = false;


        loadingButton.SetActive(true);
        settingsButton.SetActive(true);
        newGameButton.SetActive(true);
        backToMenu.SetActive(false);
        quitButton.SetActive(true);
    }
    public void SliderValueChange()
    {
        sliderValue.GetComponent<Text>().text = slider.GetComponent<Slider>().value.ToString();
    }
}
