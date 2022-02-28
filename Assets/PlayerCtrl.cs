using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
	private Rigidbody3D rb3d;
	public float speed = 5;
	public float jumpForce = 900f;
	private bool isGround;
	public Animator anim;
	private SpriteRenderer spRenderer;
	public LayerMask groundLayer;
	private bool isDead = false;

	// テキスト
	private GameObject clearTxt;
	private GameObject gameOverTxt;
	private Text clearComponent;
	private Text gameOverComponent;

    // Start is called before the first frame update
    void Start()
    {
        this.rb3d = GetComponent<Rigidbody3D>();
        this.anim = GetComponent<Animator>();
        this.spRenderer = GetComponent<SpriteRenderer>();

        // テキスト
        clearTxt = GameObject.Find("Clear");
        clearComponent = clearTxt.GetComponent<Text>();
        gameOverTxt = GameObject.Find("GameOver");
        gameOverComponent = gameOverTxt.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    	float x = Input.GetAxisRaw("Horizontal");

    	// キャラの向き
    	if ( x < 0 ) {
    		spRenderer.flipX = true;
    	} else if (x > 0) {
    		spRenderer.flipX = false;
    	}

    	if (!isDead) {
    		anim.SetFloat("Speed", Mathf.Abs(x * speed));
    		rb3d.AddForce(Vector2.right * x * speed);
    	}


    	// ジャンプ
    	if ( Input.GetButtonDown("Jump") & isGround) {
        	anim.SetBool("isJump", true);
        	rb3d.AddForce(Vector2.up * jumpForce);
        }

        float velX = rb3d.velocity.x;
        float velY = rb3d.velocity.y;

		// ジャンプ中
        if (isGround) {
        	anim.SetBool("isJump", false);
        	anim.SetBool("isFall", false);
        }

        // ジャンプ中
        if (velY > 0.5f) {
        	anim.SetBool("isJump", true);
        }
        if (velY < -0.1f) {
        	anim.SetBool("isFall", true);
        }

        if (Mathf.Abs(velX) > 5) {
        	if (velX > 5.0f) {
        		rb3d.velocity = new Vector2(5.0f, velY);
        	}
        	if (velX < -5.0f) {
        		rb3d.velocity = new Vector2(-5.0f, velY);
        	}
        }

        // パンチボタンを押した時
        if (Input.GetKeyDown(KeyCode.Q)) {
        	anim.SetBool("isPunch", true);
        	GameObject enemy = GameObject.Find("enemy");
        	Vector2 myPos = this.transform.position;
	        Vector2 ePos = enemy.transform.position;
	        float distance = Vector2.Distance(ePos, myPos);
	        if (distance <= 2.4) { // 個別の当たり判定をつけるべきだったかも
	        	enemy.GetComponent<Animator>().SetBool("isDead", true);
	        	enemy.transform.position = new Vector3(this.transform.position.x - 5, 2, 0);
	        }
        }
        // パンチボタンから離れた時
        if (Input.GetKeyUp(KeyCode.Q)) {
        	anim.SetBool("isPunch", false);
        }
    }

    private void FixedUpdate()
    {
    	isGround = false;
    	Vector2 groundPos = new Vector2(
    		transform.position.x,
    		transform.position.y
    	);
    	Vector2 groundArea = new Vector2(0.5f, 0.5f);
    	Debug.DrawLine(groundPos + groundArea, groundPos - groundArea, Color.red);

    	isGround = Physics3D.OverlapArea(
			groundPos + groundArea,
			groundPos - groundArea,
			groundLayer
    	);
    }

    IEnumerator Dead() {
    	anim.SetBool("isDamage", true);
    	rb3d.velocity = new Vector2(0,0);
    	yield return new WaitForSeconds(0.5f);

    	Vector2 position = Vector2.up * jumpForce;
    	if (position.y > 900) {
    		position.y = 900f;
    	}
    	rb3d.AddForce(position);
    	// rb3d.AddForce(Vector2.up * jumpForce);
    	GetComponent<BoxCollider3D>().enabled = false;
    	gameOverComponent.enabled = true;
    }

    void OnCollisionEnter3D(Collision3D col)
    {
    	if (col.gameObject.tag == "Enemy") {
    		anim.SetBool("isJump", true);
    		Vector2 position = Vector2.up * jumpForce;
	    	if (position.y > 900) {
	    		position.y = 900f;
	    	}
    		rb3d.AddForce(position);
    	}

    	if (col.gameObject.tag == "Damage") {
    		isDead = true;
    		StartCoroutine("Dead");
    	}
    }

    void OnTriggerEnter3D(Collider3D col)
    {
    	if (col.gameObject.tag == "Enemy") {
    		isDead = true;
    		StartCoroutine("Dead");
    	}
    }






















}
