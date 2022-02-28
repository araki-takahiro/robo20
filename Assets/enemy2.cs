using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCtrl : MonoBehaviour
{
	private Animator anim;
	public GameObject player;
	private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pPos = player.transform.position;
        Vector3 myPos = this.transform.position;
        float distance = Vector3.Distance(pPos, myPos);

        if (distance < 2 & (pPos.y - myPos.y) < 1) {
        	this.anim.SetTrigger("TrgAttack");
        }

        if (isDead) {
        	float level = Mathf.Abs(Mathf.Sin(Time.time * 20));
        	GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,level);
        }
    }

    void OnCollisionEnter3D(Collision3D col)
    {
    	anim.SetTrigger("TrgDead");
    	GetComponent<BoxCollider3D>().enabled = false;
    	GetComponent<CircleCollider3D>().enabled = false;
    	StartCoroutine("Dead");
    }

    IEnumerator Dead() {
    	isDead = true;
    	yield return new WaitForSeconds(1.5f);
    	Destroy(this.gameObject);
    }
}
