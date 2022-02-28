using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
	// public GameObject player;
	// private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
    	// this.rb2d = GetComponent<Rigidbody2D>();
    }

    // void update()
    // {
    // }

    // Update is called once per frame
    void Update()
    {
    	GameObject player = GameObject.Find("player");
    	transform.position = new Vector3(
        	player.transform.position.x,
        	this.transform.position.y,
        	this.transform.position.z
        );
    	// float position = player.transform.position.x;
    	// if (position < 0.5) {
    	// 	position = 0;
    	// } else {
    	// 	position = position - position / 2 + position / 4;
    	// }

    	// float x = Input.GetAxisRaw("Horizontal");
    	// rb2d.AddForce(Vector2.right * x * 20);
    	// float velX = rb2d.velocity.x;
    	// if (Mathf.Abs(velX) > 5) {
     //    	if (velX > 5.0f) {
     //    		rb2d.velocity = new Vector2(5.0f, 0);
     //    	}
     //    	if (velX < -5.0f) {
     //    		rb2d.velocity = new Vector2(-5.0f, 0);
     //    	}
     //    }


        // transform.position = new Vector3(
        // 	position,
        // 	this.transform.position.y,
        // 	this.transform.position.z
        // );
    }
}
