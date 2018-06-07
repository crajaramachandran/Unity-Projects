using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorb : MonoBehaviour {

    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";
    
    public Transform boomObj;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3 (horizVel, 0, 4);

        if ((Input.GetKeyDown (moveL)) && (laneNum>1) && (controlLocked == "n")) {
            horizVel = -2;
            StartCoroutine (stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }
        if ((Input.GetKeyDown(moveR)) && (laneNum <= 2) && (controlLocked == "n"))
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }

    }

    IEnumerator stopSlide() {
        yield return new WaitForSeconds (.5f);
        horizVel = 0;
        controlLocked = "n";
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Lethal")
        {
            Destroy(gameObject);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.lvlCompStatus = "Fail";
        }
        if (other.gameObject.name == "Capsule(Clone)")
        {
            Destroy(other.gameObject);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "exit")
        {
            GM.lvlCompStatus = "Success";
            SceneManager.LoadScene("LevelComp");
        }

        if (other.gameObject.name == "coin(Clone)")
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
    }

}
