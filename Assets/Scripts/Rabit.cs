using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabit : MonoBehaviour {

	public float speed = 5;
	Rigidbody2D rBody = null;
	SpriteRenderer sr = null;
	Transform rabitParent = null;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		LevelControler.current.setStartPosition (transform.position);
		rabitParent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		float value = Input.GetAxis ("Horizontal");

		Animator an = GetComponent<Animator> ();
		an.SetBool ("run", Mathf.Abs(value) > 0);
		an.SetBool ("jump", !isGrounded);
		an.SetBool("isAlive", !getingDead);
		//an.SetBool ("isAlive " , LevelControler.current.getLifesCount() > 0);
	}
	
	void FixedUpdate() {
		float value = Input.GetAxis("Horizontal");

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = rBody.velocity;
			vel.x = value * speed;
			rBody.velocity = vel;
		}
		if (value < 0) sr.flipX = true;
		else if (value > 0) sr.flipX = false;

		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");

		RaycastHit2D hit = Physics2D.Linecast (from, to, layer_id);
		isGrounded = hit;

		//Debug.DrawLine (from, to, Color.red);

		if (Input.GetButtonDown ("Jump") && isGrounded)
			this.isJumpActive = true;

		if (this.isJumpActive) {
			if (Input.GetButton ("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 v = rBody.velocity;
					v.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
					rBody.velocity = v;
				}
			} else {
				this.isJumpActive = false;
				this.JumpTime = 0;
			}
		}

		//RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);

		if (hit) {
			if (hit.transform != null && hit.transform.GetComponent<MovingPlatform>() != null)
				setNewParent(transform, hit.transform);
		}
		else setNewParent(transform, rabitParent);

		// get bigger
		if (getingBiger) {
			if (wait > 0) {
				wait -= Time.deltaTime;
				transform.localScale = new Vector2(transform.localScale.x + 0.02f, transform.localScale.y + 0.02f);
			}
			else {
				getingBiger = false;
				isBig = true;
			}
		}

		// get smaller

		if (getingSmaller) {
			if (wait > 0) {
				wait -= Time.deltaTime;
				transform.localScale = new Vector2(transform.localScale.x - 0.02f, transform.localScale.y - 0.02f);
			}
			else {
				getingSmaller = false;
				isBig = false;
			}
		}
	}

	static void setNewParent(Transform obj, Transform newParent) {
		if (obj.transform.parent != newParent) {			Vector3 pos = obj.transform.position;
			obj.transform.parent = newParent;
			obj.transform.position = pos;
		}
	}

	public void startGetingBiger() {
		if (!isBig) {
			getingBiger = true;
			wait = timeToWait;
		}
	}

	public void onBomb() {
		if (isBig) { 
			getingSmaller = true;
			wait = timeToWait;
		} else { 
			LevelControler.current.RabitDeath(this);
		}
	}

	public void setDying(bool d) {
		getingDead = d;
	}

	float timeToWait = 1f;
	float wait;
	bool isGrounded;
	bool isJumpActive;
	bool isBig;
	bool getingBiger;
	bool getingSmaller;
	bool getingDead;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
}


// edit - project settings - physics 2D