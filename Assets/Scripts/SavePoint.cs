using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    PlayerDataManager DataMgr = null;
    public GameObject SavePointEffect = null;
    public GameObject SaveText = null;

    int WorldNum = 0;
    bool SaveTextOn = false;
    int SaveTextCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        DataMgr = FindObjectOfType<PlayerDataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true == SaveTextOn)
        {
            SaveTextCount++;
            if (SaveTextCount == 1)
            {
                SavePointEffect.SetActive(false);
                this.GetComponent<BoxCollider>().enabled = false;
                SaveText.SetActive(true);
            }
            else if (SaveTextCount == 120)
            {
                SaveText.SetActive(false);
            }
            else if (SaveTextCount > 120)
            {
                SaveTextOn = false;
                this.gameObject.SetActive(false);
                DataMgr.Save_SPActive(WorldNum);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tagWayCheck"))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "SceneWorld_1":
                    {
                        WorldNum = 1;
                    }
                    break;
                case "SceneWorld_2":
                    {
                        WorldNum = 2;
                    }
                    break;
            }

            DataMgr.Save_Playing(WorldNum, this.gameObject.transform);
            SaveTextOn = true;
        }
    }
}
