using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {

    bool runOnlyOnce = false;

    public int saveId;

    void OnTriggerEnter(Collider other)
    {
        if(!runOnlyOnce)
        {
            youHaveWonTheGame = true;
            winText.enabled = true;

            SaveLoad.savedGame.whichPosition = saveId;
            SaveLoad.Save();

            runOnlyOnce = true;
        }

    }
    bool youHaveWonTheGame;
    public Text winText;
    int i = 0;
	void Start () {
        StartCoroutine(NewThread());
	}
	
	void Update () {
	
	}
    IEnumerator NewThread()
    {
        while (true)
        {
            if (youHaveWonTheGame)
            {
                i += 1;              
                if(i>120)
                {
                    youHaveWonTheGame = false;
                    i = 0;
                    winText.enabled = false;
                }
                
            }
            yield return null;
        }
        
    }
}
