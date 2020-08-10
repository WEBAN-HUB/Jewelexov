using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class UISetting : MonoBehaviour
{
    public GameObject Title = null;

    public Text MusicVolumeTxt = null;
    public Text EffectVolumeTxt = null;
    

    public Slider mpSlider = null;
    public Slider mpSlider2 = null;

    public float VolumeLevel = 1;
    public float VolumeLevel2 = 1;

    // Start is called before the first frame update
    void Start()
    {
        mpSlider.value = CSoundsMgr.Getinstance().MusicVolumeLevel;
        mpSlider2.value = CSoundsMgr.Getinstance().EffectVolume;

        MusicVolumeTxt.text = "음악 볼륨: " + Mathf.CeilToInt(CSoundsMgr.Getinstance().MusicVolumeLevel * 100).ToString();

        EffectVolumeTxt.text = "이펙트 볼륨: " + Mathf.CeilToInt(CSoundsMgr.Getinstance().EffectVolume * 100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void ChangeVolumeLevel()
    {
        VolumeLevel = mpSlider.value;

        CSoundsMgr.Getinstance().MusicVolume(VolumeLevel);

        MusicVolumeTxt.text = "음악 볼륨: " + Mathf.CeilToInt(VolumeLevel * 100).ToString(); ;
    }

    public void ChangeEffectVolumeLevel()
    {
        VolumeLevel2 = mpSlider2.value;

        CSoundsMgr.Getinstance().EffectVolumeSlider(VolumeLevel2);

        EffectVolumeTxt.text = "이펙트 볼륨: " + Mathf.CeilToInt(VolumeLevel2 * 100).ToString();
    }

    public void GotoTitle()
    {
        Title.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
