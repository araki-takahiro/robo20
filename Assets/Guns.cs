using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalMan : MonoBehaviour
{
	private GameObject Guns;
	private GameObject Shoot;
	private Text clearComponent;
    // Start is called before the first frame update
    void Start()
    {
    	Guns = GameObject.Find("Guns");
    	Guns.gameObject.SetActive (false);
        Shoot = GameObject.Find("Shoot");
        clearComponent = clearTxt.GetComponent<Text>();
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    void OnCollisionEnter3D(Collision2D col)
    {
    	if (col.gameObject.name == "player") {
    		clearComponent.enabled = true;
    		Guns.gameObject.SetActive (true);
    	}
    }
}
