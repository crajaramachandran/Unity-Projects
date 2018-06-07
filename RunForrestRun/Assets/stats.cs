using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "coinstxt")
        {
            GetComponent<TextMesh>().text = "Coins :" + GM.coinTotal;
        }
        if (gameObject.name == "timetxt")
        {
            GetComponent<TextMesh>().text = "Time :" + GM.TimeTotal;
        }
        if (gameObject.name == "runstatus")
        {
            GetComponent<TextMesh>().text = GM.lvlCompStatus;
        }


    }
}
