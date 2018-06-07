using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static int coinTotal = 0;
    public static float TimeTotal = 0;
    public float waittoload = 0;
    public static float zVelAdj = 1;

    public float zScenePos=54f;

    public Transform bbNoPit;
    public Transform bbPitMid;
    public Transform coinObj;
    public Transform obstacleObj;
    public Transform capsuleObj;

    public int randNum;

    public static string lvlCompStatus = "";

	// Use this for initialization
	void Start () {
        Instantiate(bbNoPit, new Vector3(0.42f,0.96f,38f), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0.42f, 0.96f, 42f), bbNoPit.rotation);
        Instantiate(bbPitMid, new Vector3(0.42f, 0.96f, 46f), bbPitMid.rotation);
        Instantiate(bbPitMid, new Vector3(0.42f, 0.96f, 50f), bbPitMid.rotation);
    }
	
	// Update is called once per frame
	void Update ()
    {
        randNum = Random.Range(0, 10);
        if (randNum < 3)
        {
            Instantiate(coinObj, new Vector3(-1, 1.2f, zScenePos), coinObj.rotation);
        }
        if (randNum > 7)
        {
            Instantiate(coinObj, new Vector3(1, 1.2f, zScenePos), coinObj.rotation);
        }
        if (randNum == 4)
        {
            Instantiate(obstacleObj, new Vector3(1, 1.2f, zScenePos), obstacleObj.rotation);
        }
        if (randNum == 5)
        {
            Instantiate(obstacleObj, new Vector3(0, 1.2f, zScenePos), obstacleObj.rotation);
        }

        if (zScenePos < 150)
        {
            Instantiate(bbNoPit, new Vector3(0.42f, 0.96f, zScenePos), bbNoPit.rotation);
            zScenePos += 4;
        }

        TimeTotal += Time.deltaTime;
        if (lvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;
        }

        if (waittoload > 2)
        {
            SceneManager.LoadScene("LevelComp");

        }
		
	}
}
