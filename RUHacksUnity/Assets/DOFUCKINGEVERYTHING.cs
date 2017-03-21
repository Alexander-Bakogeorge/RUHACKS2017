using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AC.TimeOfDaySystemFree;

using System;
using System.Collections;
using UnityEngine.Networking;
using System.Net;


public class DOFUCKINGEVERYTHING : MonoBehaviour {
    public AudioSource  sound;
    public AudioSource music;
    public GameObject Horse; 
    ArrayList Horses = new ArrayList();
    public  GameObject Player;
    public GameObject Weather;
    public GameObject particle;

    WWW web;
    WebRequest request;
    UploadHandler uLoader;
    DownloadHandler dLoader;
    UnityWebRequest uRequest;
    String url;
    static String lastCall;
    float currentTime;
   int currentState;
    int prevState;
    // Use this for initialization
    void Start()
    {
        currentState = -1;
        prevState = -1;
        float currentTime = Time.deltaTime;
        url = "http://ec2-34-207-77-15.compute-1.amazonaws.com/Webform1.aspx";
        web = new WWW(url);
        web.ToString();
        //uRequest = new UnityWebRequest(url);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 5)
        {
            web = new WWW(url);
            String x = GetInfo();
            print("This is my command" + x.ToString());
            currentTime = 0;
            //  String[] q = x.ToString().Split('+');
            // print(q[0]);
            string line;
            using (System.IO.StringReader reader = new System.IO.StringReader(x.ToString()))
            {
                 line = reader.ReadLine();
            }
            if(line != String.Empty) { 
            String [] q = line.Split('+');
            currentState = Int32.Parse( q[0]);
                if (!(currentState == prevState) || prevState == -1)
                {
                    prevState = (currentState);
                    print(q[1]);

                    DoEverything(Int32.Parse(q[1].ToString()));

                }
            }

        }
        //print(currentTime);
        currentTime += Time.deltaTime;
    }
    public String GetInfo()
    {

        while (!web.isDone)
        {
        }
        return web.text.ToString();
    }
    public  void DoEverything(int num) {
        switch (num) {
            case 0:
                sound.volume  += 0.1f;
                
                break;
            case 1:
                sound.volume -= 0.1f;
                break;
            case 2:
                sound.Stop();
                break;
            case 3:
                sound.Play();
                break;
            case 4:
                sound.clip =(AudioClip) sound.GetComponent<soundRandom>().audios[(UnityEngine.Random.Range(0, 3))];
                sound.Play();
                break;
            case 5:
                music.volume += 0.1f;
                break;
            case 6:
                music.volume -= 0.1f;
                break;
           case 7:
                music.Stop();
                break;
            case 8:
                music.Play();
                break;
            case 9:
                music.clip = (AudioClip)music.GetComponent<MusicRandom>().audios[(UnityEngine.Random.Range(0, 3))];
                music.Play();
                break;
            case 10:
                Player.GetComponent<NavMeshAgent>().destination  = new Vector3(204.67f, 111.85f, 53.3f); ;
                break;
            case 11:
                Player.GetComponent<NavMeshAgent>().destination = new Vector3(145, 101.54F, 46);
                break;
            case 12:
                Player.GetComponent<NavMeshAgent>().destination = Player.transform.position;
                break;
            case 13:
               // this function returns control to the user
                break;
            case 14:
                //sets the se
                break;
            case 15:

                break;
            case 16:

                break;
            case 17:

                break;
            case 18:
                //
                break;
            case 19:
                Weather.GetComponent<TimeOfDayManager>().setHour (12); 
                break;
            case 20:
                Weather.GetComponent<TimeOfDayManager>().setHour(0);
                break;
            case 21:
                Weather.GetComponent<TimeOfDayManager>().setHour(6);
                break;
            case 22:
                Weather.GetComponent<TimeOfDayManager>().setHour(18);
                break;
            case 23:
                Weather.GetComponent <TimeOfDayManager>().setDay( Weather.GetComponent<TimeOfDayManager>().getDay() + 100);
                break;
            case 24:
                Weather.GetComponent<TimeOfDayManager>().setDay(Weather.GetComponent<TimeOfDayManager>().getDay() -100);
                break;
            case 25:
               Horses.Add( GameObject.Instantiate(Horse, Player.transform.position, Quaternion.identity));
                break;
            case 26: 
                foreach(GameObject o in Horses){
                    Destroy(o);
                }
                break;
            case 27:
                foreach (GameObject o in Horses)
                {
                    if (o != null)
                    {
                        o.transform.FindChild(particle.name).gameObject.SetActive(true);
                    }
                    }
                break;
            case 28:
                foreach (GameObject o in Horses)
                {
                    o.GetComponent<NavMeshAgent>().speed += 2;
                }
                break;
            case 29:
                foreach (GameObject o in Horses)
                {
                    o.GetComponent<NavMeshAgent>().speed -= 2;
                }
                break;
            case 30:
                DoEverything(UnityEngine.Random.Range(0, 29));
                break;
            
            default:

                break;
        }
    }





}
