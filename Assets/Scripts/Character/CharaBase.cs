using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各キャラクターのベースクラス
/// </summary>
public class CharaBase : MonoBehaviour
{
	/// <summary>
	/// 体力
	/// </summary>
	[SerializeField] protected int _hp = 1;

	/// <summary>
	/// 移動速度
	/// </summary>
	[SerializeField] protected float _speed = 1f;

	/// <summary>
	/// トランスフォーム
	/// </summary>
	protected RectTransform _rectTransform = null;

	/// <summary>
	/// ポジション
	/// </summary>
	public Vector2 Position
	{
		get { return _rectTransform.anchoredPosition; }
		set { if(_rectTransform) _rectTransform.anchoredPosition = value; }
	}

	//--------------------------------------------------
	private void Start()
	{
		_rectTransform = this.gameObject.GetComponent<RectTransform>();
	}

	void Update()
	{
		Move();
		Shot();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Damage();	
	}

	/// <summary>
	/// 移動処理
	/// </summary>
	protected virtual void Move()
	{
		Debug.Log("Base Move");
		if (GameContoroller.Instance == null || GameContoroller.Instance.NowMode != GameContoroller.Mode.Play) return;
		Position += Vector2.down * _speed;
	}

	/// <summary>
	/// 弾発射処理
	/// </summary>
	protected virtual void Shot(){}

	/// <summary>
	/// ダメージ処理
	/// </summary>
	public virtual void Damage()
	{
		_hp--;
		if(_hp <= 0)
		{
			this.gameObject.SetActive(false);
		}
	}
}
