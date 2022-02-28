using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
	public Animator anim;
	// public GameObject player;
	private Rigidbody3D rb3d;
	// private float position;
	// public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
    	this.rb3d = GetComponent<Rigidbody3D>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = -2;
        // Debug.Log(this.anim);
        // if (!isDead) {
        	this.transform.position += new Vector3(dx * Time.deltaTime, 0, 0);
        // }
        if (this.transform.position.y < -10) {
        	this.anim.SetBool("isDead", false);
        	this.transform.position = new Vector3(6, 0, 0);
        }
    }
}
