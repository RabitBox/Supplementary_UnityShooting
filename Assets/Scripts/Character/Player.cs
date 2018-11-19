using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤークラス
/// </summary>
public class Player : CharaBase
{
	protected override void Move()
	{
		if (GameContoroller.Instance == null || GameContoroller.Instance.NowMode != GameContoroller.Mode.Play) return;

		var moveDirection = Vector2.zero;
		if (Input.GetKey(KeyCode.W)) { moveDirection += Vector2.up; }
		else if (Input.GetKey(KeyCode.S)) { moveDirection += Vector2.down; }
		if (Input.GetKey(KeyCode.A)) { moveDirection += Vector2.left; }
		else if (Input.GetKey(KeyCode.D)) { moveDirection += Vector2.right; }

		var nextPosition = _rectTransform.anchoredPosition + moveDirection.normalized * _speed;

		nextPosition = Vector2Clamp(
			nextPosition,
			(GameContoroller.Instance.ScreenMin + _rectTransform.sizeDelta / 2),
			(GameContoroller.Instance.ScreenMax - _rectTransform.sizeDelta / 2));
		//nextPosition.x = Mathf.Clamp(
		//	nextPosition.x,
		//	(GameContoroller.Instance.ScreenMin.x + _rectTransform.sizeDelta.x / 2),
		//	(GameContoroller.Instance.ScreenMax.x - _rectTransform.sizeDelta.x / 2));
		//nextPosition.y = Mathf.Clamp(
		//	nextPosition.y,
		//	(GameContoroller.Instance.ScreenMin.y + _rectTransform.sizeDelta.y / 2),
		//	(GameContoroller.Instance.ScreenMax.y - _rectTransform.sizeDelta.y / 2));

		this._rectTransform.anchoredPosition = nextPosition;
	}

	/// <summary>
	/// 特定の値を最大値と最小値の間に補正する
	/// </summary>
	/// <param name="target"> 変換する値 </param>
	/// <param name="min"> 最小値 </param>
	/// <param name="max"> 最大値 </param>
	/// <returns> 変換後の値 </returns>
	Vector2 Vector2Clamp(Vector2 target, Vector2 min, Vector2 max)
	{
		target.x = Mathf.Clamp( target.x, min.x, max.x );
		target.y = Mathf.Clamp( target.y, min.y, max.y );
		return target;
	}

	//-------------------------------------------------------
	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		base.OnTriggerEnter2D(collision);
		if (collision.gameObject.tag == "Enemy")
		{
			Damage(1);
		}
	}
}
