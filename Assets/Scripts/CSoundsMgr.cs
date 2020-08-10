using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoundsMgr
{
    private static CSoundsMgr mInstance = null;

    public Dictionary<string, AudioSource> mDictionary = new Dictionary<string, AudioSource>();

    public CAudioBundle mAudioBundle = null;

    public float MusicVolumeLevel = 1f;


    public float EffectVolume = 1f;

    public bool SoundLoadOnce = false;

    protected CSoundsMgr()
    {
        mInstance = null;
    }


    public static CSoundsMgr Getinstance()
    {
        if(mInstance == null)
        {
            mInstance = new CSoundsMgr();
        }

        return mInstance;
    }


    public void DoRegist(AudioSource AS)
    {
        mDictionary.Add(AS.clip.name, AS);
    }


    public void DoUnRegist(AudioSource AS)
    {
        mDictionary.Remove(AS.clip.name);
    }

    public void Play(string tString)
    {
        mDictionary[tString].Play();
    }

    public void Stop(string tString)
    {
        mDictionary[tString].Stop();
    }

    public void SetAudioBundle(CAudioBundle tBundle)
    {
        mAudioBundle = tBundle;

        GameObject.DontDestroyOnLoad(mAudioBundle);
    }

    public void PlayBgm(int Index)
    {
        mAudioBundle.mArray[Index].Play();
    }

    public void StopBgm(int Index)
    {
        mAudioBundle.mArray[Index].Stop();
    }

    public void MusicVolume(float Level)
    {
        for(int ti = 0; ti < mAudioBundle.mArray.Length;ti++ )
        {
            mAudioBundle.mArray[ti].volume = Level;
        }
        MusicVolumeLevel = Level;
    }

    public void EffectVolumeSlider(float Level)
    {
        EffectVolume = Level;
    }

    public void SetEffectVolume()
    {
        foreach(KeyValuePair<string, AudioSource> tAs in mDictionary)
        {
            tAs.Value.volume = EffectVolume;
        }
    }

    public void MusicAllStop()
    {
        for (int ti = 0; ti < mAudioBundle.mArray.Length; ti++)
        {
            CSoundsMgr.Getinstance().StopBgm(ti);

        }
    }


}
