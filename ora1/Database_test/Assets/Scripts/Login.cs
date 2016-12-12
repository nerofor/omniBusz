using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

    public string inputUsername;
    public string inputPassword;
    string LoginURL = "localhost/omnibusz_database/Login.php";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoginToDB(inputUsername, inputPassword));
        }
    }

    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(LoginURL, form);

        yield return www;

        Debug.Log(www.text);

    }
}
