using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcGreen: MonoBehaviour {

	public enum Mode {
		GoToA = 0, GoToB = 1, Attack = 2, Die = 3
	}

	public float speed = 1f;
	public float runSpeed = 2.5f;
	public float hitRange = 2f;
	public Vector3 destVector = Vector3.one;

	void Start() {
		body = GetComponent<Rigidbody2D>();
		spriter = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
		pointA = transform.position;
		destVector.y = destVector.z = 0;
		pointB = pointA + destVector;
	}

	void FixedUpdate() {
		if (mode == Mode.Die) return;
		Vector3 rabbitPosition = Rabit.rabit.transform.position;
		Vector3 orcPosition = this.transform.position;

		if ((rabbitPosition.x > pointA.x && rabbitPosition.x < pointB.x))/* ||
		    (rabbitPosition.x > pointB.x && rabbitPosition.x < pointA.x))*/
			mode = Mode.Attack;
		else if ((mode == Mode.GoToA || mode == Mode.Attack) && HasArrived(orcPosition, pointA))
			mode = Mode.GoToB;
		else if ((mode == Mode.GoToB || mode == Mode.Attack) && HasArrived(orcPosition, pointB))
			mode = Mode.GoToA;
		Run();
		if (mode == Mode.Attack && IsCloseToRabit()) {
			if (IsDirectlyUnderRabit())
				mode = Mode.Die;
			else if (((waitTime -= Time.deltaTime) <= .0f) && transform.position.y >= rabbitPosition.y) {
				BumpRabit();
				waitTime = 0;
			}
		}
		StartCoroutine(Die());
	}

	float getDirection() {
		Vector3 rabbitPosition = Rabit.rabit.transform.position;
		Vector3 orcPosition = transform.position;
		if (mode == Mode.Attack) {
			return orcPosition.x - rabbitPosition.x < -1 ? 1 :
				   orcPosition.x - rabbitPosition.x > 1 ? -1 : 0;
		}
		return mode == Mode.GoToA ? -1 : mode == Mode.GoToB ? 1 : 0;
	}

	private bool HasArrived(Vector3 position, Vector3 target) {
		position.z = 0;
		target.z = 0;
		return Vector3.Distance(position, target) < 0.5f;
	}

	private void Run() {
		float direction = this.getDirection();

		if (direction != .0f)
			spriter.flipX = direction > 0;
		if (Mathf.Abs(direction) > 0) {
			Vector2 vel = body.velocity;
			if (mode == Mode.Attack) vel.x = direction * runSpeed;
			else vel.x = direction * speed;
			body.velocity = vel;
		}
		if (mode == Mode.Attack) {
			animator.SetBool("Run", Mathf.Abs(direction) > 0);
			animator.SetBool("Walk", !(Mathf.Abs(direction) > 0));
		}
		else {
			animator.SetBool("Walk", Mathf.Abs(direction) > 0);
			animator.SetBool("Run", !(Mathf.Abs(direction) > 0));
		}
	}

	private bool IsCloseToRabit() {
		Vector3 rp = Rabit.rabit.transform.position;
		Vector3 op = this.transform.position;
		if (!Rabit.rabit.isBig) return Mathf.Abs(transform.position.x
					   - Rabit.rabit.transform.position.x) < 2.1f;
		else return Mathf.Abs(transform.position.x
					   - Rabit.rabit.transform.position.x) < 3.1f;
		}


	private bool IsDirectlyUnderRabit() {
		return Rabit.rabit.transform.position.y > transform.position.y
			&& Mathf.Abs(Rabit.rabit.transform.position.y - this.transform.position.y) < 2.3f;
	}

	private void BumpRabit() {
		animator.SetBool("Attack", true);
		waitTime = 1.0f;
		LevelControler.current.RabitDeath(Rabit.rabit);
		animator.SetBool("Attack", false);
	}

	private IEnumerator Die() {
		if (mode == Mode.Die) {
			animator.SetBool("Die", true);
			GetComponent<BoxCollider2D>().isTrigger = true;
			if (body) Destroy(body);

			yield return new WaitForSeconds(1f);
			animator.SetBool("Die", false);
			Destroy(this.gameObject);
		}
	}

	private const float DEATH_HEIGHT = 1;
	private float waitTime;
	public Mode mode = Mode.GoToB;
	private Rigidbody2D body;
	private SpriteRenderer spriter;
	private Animator animator;
	public Vector3 pointA;
	public Vector3 pointB;

}