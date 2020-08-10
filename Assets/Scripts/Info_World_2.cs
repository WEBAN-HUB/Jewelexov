using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_World_2 : MonoBehaviour
{
    public GameObject PFGem_1_0 = null;
    public GameObject PFGem_1_1 = null;
    public GameObject PFGem_1_2 = null;
    public List<GameObject> GemList = new List<GameObject>();

    public List<GameObject> GemCaseList = new List<GameObject>();
    public List<GameObject> OnGemList = new List<GameObject>();

    PlayerDataManager DataMgr = null;

    // Start is called before the first frame update
    void Start()
    {
        CSoundsMgr.Getinstance().MusicAllStop();
        CSoundsMgr.Getinstance().PlayBgm(2);

        CSgtGameData.GetInstance().InStart_DashGemLV = PlayerPrefs.GetInt("DashGemLv");
        CSgtGameData.GetInstance().InStart_JumpGemLV = PlayerPrefs.GetInt("JumpGemLv");
        CSgtGameData.GetInstance().Move_Gem = false;
        CSgtGameData.GetInstance().Create_Gem = false;
        CSgtGameData.GetInstance().Destroy_Gem = false;

        GameObject tGem1 = Instantiate<GameObject>(PFGem_1_2, new Vector3(179.0f, 3.0f, 210.0f), Quaternion.identity);
        GemList.Add(tGem1);
        GameObject tGem2 = Instantiate<GameObject>(PFGem_1_0, new Vector3(167.0f, 12.0f, 172.0f), Quaternion.identity);
        GemList.Add(tGem2);
        GameObject tGem3 = Instantiate<GameObject>(PFGem_1_1, new Vector3(172.0f, 28.0f, 189.0f), Quaternion.identity);
        GemList.Add(tGem3);
        GameObject tGem4 = Instantiate<GameObject>(PFGem_1_1, new Vector3(167.0f, 24.0f, 172.0f), Quaternion.identity);
        GemList.Add(tGem4);

        DataMgr = FindObjectOfType<PlayerDataManager>();
        //DataMgr.Load_Playing(2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
