using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable
{

	public Vector3 Speed = new Vector3(5.0f, 0.0f, 0.0f);

	private Rigidbody2D Body;
	private SpriteRenderer Spriter;
	private float Direction = 1.0f;
	private float LifeTime = 5.0f;

	void Start()
	{
		Spriter = GetComponent<SpriteRenderer>();
		StartCoroutine(DestroyLater());
	}

	public void LaunchTo(float direction)
	{
		this.Direction = direction;
	}

	IEnumerator DestroyLater()
	{
		yield return new WaitForSeconds(LifeTime);
		Destroy(this.gameObject);
	}

	public void FixedUpdate()
	{
		if (Direction != 0)
		{
			if (Direction != .0f)
			{
				Spriter.flipX = Direction < 0;
			}

			if (Mathf.Abs(Direction) > 0)
			{
				this.transform.position += Speed * Direction * Time.deltaTime;
			}
		}
	}

    protected override void onRabitHit(Rabit rabit)
    {
        LevelControler.current.RabitDeath(rabit);
        CollectedHide();
    }

}