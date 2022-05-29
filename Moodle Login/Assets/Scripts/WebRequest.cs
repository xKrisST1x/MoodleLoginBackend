using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class WebRequest : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetDate("http://localhost/UnityBackendLoginMoodle/GetDate.php"));
        //StartCoroutine(GetUsers("http://localhost/UnityBackendLoginMoodle/GetUsers.php"));
        //StartCoroutine(Login("teststudent", "123456"));
        //StartCoroutine(RegisterUser("teststudent3", "1994"));


        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetDate(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
     IEnumerator GetUsers(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

      public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        // submits the information to the php file (Login.php) through a post.
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackendLoginMoodle/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

      IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        // submits the information to the php file (Login.php) through a post.
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        //form.AddField("loginEmail", email);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackendLoginMoodle/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}