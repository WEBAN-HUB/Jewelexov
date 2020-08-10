using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrap : MonoBehaviour
{
    public List<GameObject> mCheckPointNum = new List<GameObject>();

    public GameObject mActive = null;

    int StartPoint = 0;
    int TargetPoint = 1;
    float mSpeed = 0.05f;

    Vector3 MoveVector = Vector3.zero;

    bool Triggershield = true;

    // Start is called before the first frame update
    void Start()
    {
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

        this.transform.position = mCheckPointNum[0].transform.position;

        MoveVector = (mCheckPointNum[TargetPoint].transform.position - this.transform.position).normalized;
        MoveVector.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(MoveVector*mSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("tagCheckPoint"))
        {
            if (Triggershield == false)
            {
                Triggershield = true;
                TargetPoint++;
                StartPoint++;
                MoveVector = (mCheckPointNum[TargetPoint].transform.position - this.transform.position).normalized;
                MoveVector.y = 0;
            }
        }

        if(other.CompareTag("tagWayCheck"))
        {
            mActive.transform.position = this.transform.position;

            mActive.SetActive(true);
            this.gameObject.SetActive(false);
        }
          
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("tagCheckPoint"))
        {
            if (Triggershield == true)
            {
                Triggershield = false;
            }
        }
    }
}
