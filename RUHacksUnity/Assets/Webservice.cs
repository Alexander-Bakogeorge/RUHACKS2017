using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;
using System.Net;




public class Webservice : MonoBehaviour {
    WWW web;
    WebRequest request;
    UploadHandler uLoader;
    DownloadHandler dLoader;
    UnityWebRequest uRequest;
    String url;
    static String lastCall;
    float currentTime;
    // Use this for initialization
    void Start () {
        float currentTime = Time.deltaTime;
        url = "http://ec2-34-207-77-15.compute-1.amazonaws.com/Webform1.aspx";
        web = new WWW(url);
        web.ToString();
        //uRequest = new UnityWebRequest(url);
        
    }
	
	// Update is called once per frame
	void Update () {
        if ( currentTime >= 5)
        {
            web = new WWW(url);
            String x = GetInfo();
            print("This is my command" + x.ToString());
            currentTime = 0;
            
        }
        //print(currentTime);
        currentTime += Time.deltaTime;
        }
    public String   GetInfo() {

        while(!web.isDone)
        {
        }
        return web.text.ToString();
    }



}
