using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_World_1 : MonoBehaviour
{
    public GameObject PFGem_0_0 = null;
    public GameObject PFGem_0_1 = null;
    public GameObject PFGem_1_1 = null;
    public GameObject PFGem_1_2 = null;
    public List<GameObject> GemList = new List<GameObject>();

    public List<GameObject> StoneList = new List<GameObject>();
    public List<GameObject> OnGemList = new List<GameObject>();

    PlayerDataManager DataMgr = null;
    public GameObject PFSavePoint = null;
    public List<GameObject> SavePointList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CSoundsMgr.Getinstance().MusicAllStop();
        CSoundsMgr.Getinstance().PlayBgm(0);

        CSgtGameData.GetInstance().InStart_DashGemLV = PlayerPrefs.GetInt("DashGemLv");
        CSgtGameData.GetInstance().InStart_JumpGemLV = PlayerPrefs.GetInt("JumpGemLv");
        CSgtGameData.GetInstance().Move_Gem = false;
        CSgtGameData.GetInstance().Create_Gem = false;
        CSgtGameData.GetInstance().Destroy_Gem = false;

        GameObject tGem1 = Instantiate<GameObject>(PFGem_0_1, new Vector3(29.0f, 1.0f, 0.0f), Quaternion.identity);
        GemList.Add(tGem1);
        GameObject tGem2 = Instantiate<GameObject>(PFGem_0_0, new Vector3(86.0f, 1.0f, 0.0f), Quaternion.identity);
        GemList.Add(tGem2);
        GameObject tGem3 = Instantiate<GameObject>(PFGem_1_2, new Vector3(29.0f, 5.0f, 0.0f), Quaternion.identity);
        GemList.Add(tGem3);
        GameObject tGem4 = Instantiate<GameObject>(PFGem_1_1, new Vector3(42.0f, 4.0f, 0.0f), Quaternion.identity);
        GemList.Add(tGem4);
        GameObject tGem5 = Instantiate<GameObject>(PFGem_1_1, new Vector3(71.0f, 5.0f, 0.0f), Quaternion.identity);
        GemList.Add(tGem5);

        GameObject tSP1 = Instantiate<GameObject>(PFSavePoint, new Vector3(83f, -0.3f, 0f), Quaternion.identity);
        SavePointList.Add(tSP1);
        GameObject tSP2 = Instantiate<GameObject>(PFSavePoint, new Vector3(122.34f, 9.58f, 60.57f), Quaternion.identity);
        tSP2.SetActive(false);
        SavePointList.Add(tSP2);

        DataMgr = FindObjectOfType<PlayerDataManager>();
        if (CSgtGameData.GetInstance().FromStart == 0)
        {
            DataMgr.Load_Playing(1);
        }
        else
        {
            DataMgr.Load_Playing_FromStart(1);
            CSgtGameData.GetInstance().FromStart = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
