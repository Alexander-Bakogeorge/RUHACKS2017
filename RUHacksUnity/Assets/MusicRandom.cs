using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandom : MonoBehaviour {
    public AudioClip audio1, audio2, audio3, audio4;
    public ArrayList audios = new ArrayList();
    // Use this for initialization
    void Start () {
        audios.Add(audio1);
        audios.Add(audio2);
        audios.Add(audio3);
        audios.Add(audio4);
    }
	

}
