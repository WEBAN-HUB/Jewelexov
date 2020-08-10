using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

	3D sound를 적용하기 위해서는 
	이 방법이 더 맞을 수도 있다. 

	3D sound 로 하려면 Spatial Blend 가 3D로 설정되어야 한다. 

	https://docs.unity3d.com/Manual/class-AudioSource.html
*/


public class CRyuSndUnit : MonoBehaviour {


	void Awake()
	{
		//AudioSource tAS = this.gameObject.GetComponent<AudioSource> ();

		AudioSource[] tASArray = this.gameObject.GetComponents<AudioSource> ();

		foreach (AudioSource tAS in tASArray) 
		{
			CSoundsMgr.Getinstance().DoRegist(tAS);

			//CRyuMgr.GetInst ().DoDisplayAll ();
		}
	}

	// Use this for initialization
	void Start () {

		

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
