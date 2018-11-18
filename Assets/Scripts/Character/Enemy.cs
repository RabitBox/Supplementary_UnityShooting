using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharaBase
{
	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		base.OnTriggerEnter2D(collision);
		if (collision.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}

	public override void Damage(int damageValue = 0)
	{
		_hp -= damageValue;
		if (_hp <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnDestroy()
	{
		GameContoroller.Instance.Score.Score += 100;
	}
}
