using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 当たり判定クラスTrexの
public class HitChecker : MonoBehaviour
{
	public bool isGroundHit;
	public bool isPlayerHit;
	public bool isEnemyHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter3D(Collider2D col)
    {
    	if (col.gameObject.name == "StageMap") {
    		isGroundHit = true;
    	}

    	if (col.gameObject.name == "player") {
    		isPlayerHit = true;
    	}
    }

    void OnTriggerExit3D(Collider3D col)
    {
    	if (col.gameObject.name == "StageMap") {
    		isGroundHit = false;
    	}

    	if (col.gameObject.name == "player") {
    		isPlayerHit = false;
    	}
    }
}
