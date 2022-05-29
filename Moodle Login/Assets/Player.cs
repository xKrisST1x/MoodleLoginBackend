using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public WebRequest webRequest;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
       webRequest = GetComponent<WebRequest>();
    }

}
