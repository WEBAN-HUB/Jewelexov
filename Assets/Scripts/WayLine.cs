using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayLine : MonoBehaviour
{
    private LineRenderer line = null;

    public List<GameObject> mCheckPointNum = new List<GameObject>();
    
    void Start()
    {
        line = this.gameObject.GetComponent<LineRenderer>();

        GameObject[] tWaypointArray = GameObject.FindGameObjectsWithTag("tagCheckPoint");

        SortedDictionary<string, GameObject> tSD = new SortedDictionary<string, GameObject>();
        foreach (var t in tWaypointArray)
        {
            tSD.Add(t.gameObject.name, t.gameObject);
        }
        foreach (var t in tSD)
        {
            mCheckPointNum.Add(t.Value);
        }

        line.positionCount =mCheckPointNum.Count;
        for(int i = 0; i  < mCheckPointNum.Count; i++)
        {
            line.SetPosition(i,mCheckPointNum[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
