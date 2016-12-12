using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {
    #region Variables
    //static variables
    public static string Emai = "";
    public static string Password = "";


    //private variables
    private string LoginUrl = "";


    //public variables
    public string CurrentMenu = "Login";

    //GUI test section
    public float X;
    public float Y;
    public float Width;
    public float Height;
    #endregion

    // Use this for initialization
    void Start () {
	
	}

    void onGUI() {
        if(CurrentMenu == "Login")
        {
            LoginGUI();
        }    
    }

    #region
    void LoginGUI()
    {
        GUI.Box(new Rect(X,Y,Width, Height),"");
    }
    #endregion
}
