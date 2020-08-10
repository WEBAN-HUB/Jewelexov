using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	created by pokpoongryu

*/
public class CAudioBundle : MonoBehaviour {

	public AudioSource[] mArray = new AudioSource[4];

	// Use this for initialization
	void Start () 
    {
        if (false == CSoundsMgr.Getinstance().SoundLoadOnce)
        {
            CSoundsMgr.Getinstance().SoundLoadOnce = true;
            CSoundsMgr.Getinstance().SetAudioBundle(this);
        }
        

        CSoundsMgr.Getinstance().MusicAllStop();
        CSoundsMgr.Getinstance().PlayBgm(3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
