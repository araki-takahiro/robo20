using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
	private Animator anim;
	private SpriteRenderer spRenderer;
	private Rigidbody3D rb3d;
	public GameObject player;
	public float speed = 15;
	private HitChecker sChecker;
	private HitChecker gChecker;
	private bool isAttack = false;
	private bool isIdle = false;
	private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        this.rb3d = GetComponent<Rigidbody3D>();
        this.anim = GetComponent<Animator>();
        this.spRenderer = GetComponent<SpriteRenderer>();
        sChecker = transform.Find("SideChecker").gameObject.GetComponent<HitChecker>();
        gChecker = transform.Find("GroundChecker").gameObject.GetComponent<HitChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 1;
        if (this.transform.eulerAngles.y == 180) {
        	x = -1;
        } else {
        	x = 1;
        }

        CheckValue();

        if (sChecker.isPlayerHit) {
        	if (!isAttack) {
        		StartCoroutine("Attack");
        	}
        	rb3d.velocity = new Vector3(0,0);
        }

        if (!isAttack & !isIdle & !isDead) {
        	anim.SetBool("isWalk", true);
        	rb3d.AddForce(Vector3.right * x * speed);
        } else {
        	anim.SetBool("isWalk", false);
        	rb3d.velocity = new Vector3(0,0);
        }

    }

    void OnCollisionEnter3D(Collision3D col)
    {
    	if (col.gameObject.name == "player") {
    		StartCoroutine("Dead");
    		anim.SetTrigger("trgDead");
    		GetComponent<BoxCollider3D>().enabled = false;
    		GetComponent<CircleCollider3D>().enabled = false;
    	}
    }

    private void CheckValue()
    {
    	if (!gChecker.isGroundHit & !isIdle) {
    		gChecker.isGroundHit = true;
    		StartCoroutine("ChangeRotate");
    	}
    }

    IEnumerator ChangeRotate() {
    	isIdle = true;
    	yield return new WaitForSeconds(2.0f);
    	if (this.transform.eulerAngles.y == 180) {
			this.transform.rotation = Quaternion.Euler(0,0,0);
		} else {
			this.transform.rotation = Quaternion.Euler(0,180,0);
		}

    	isIdle = false;
    }

    IEnumerator Attack() {
    	isAttack = true;
    	anim.SetTrigger("trgAttack");
    	yield return new WaitForSeconds(1.5f);
    	isAttack = false;
    }

    IEnumerator Dead() {
    	isDead = true;
    	yield return new WaitForSeconds(1.5f);
    	Destroy(this.gameObject);
    }
}
