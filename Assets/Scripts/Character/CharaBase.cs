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
	/// バレットシューター
	/// </summary>
	protected BulletShooter _shooter = null;

	/// <summary>
	/// ポジション
	/// </summary>
	public Vector2 Position
	{
		get { return _rectTransform.anchoredPosition; }
		set
		{
			if (!_rectTransform) _rectTransform = this.gameObject.GetComponent<RectTransform>();
			_rectTransform.anchoredPosition = value;
		}
	}

	//--------------------------------------------------
	protected virtual void Start()
	{
		_rectTransform = this.gameObject.GetComponent<RectTransform>();
		_shooter = this.gameObject.GetComponent<BulletShooter>();
	}

	protected virtual void Update()
	{
		if (GameContoroller.Instance.NowMode == GameContoroller.Mode.Play)
		{
			Move();
			if (_shooter) { _shooter.Shot(Position, this.transform.parent); }
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			if(collision.gameObject.GetComponent<BulletBase>().CreaterTag != this.gameObject.tag)
			{
				Damage(1);
				collision.gameObject.SetActive(false);
			}
		}
	}

	//--------------------------------------------------
	/// <summary>
	/// 移動処理
	/// </summary>
	protected virtual void Move()
	{
		Position += Vector2.down * _speed;
	}

	/// <summary>
	/// ダメージ処理
	/// </summary>
	public virtual void Damage(int damageValue = 0)
	{
		_hp -= damageValue;
		if (_hp <= 0)
		{
			this.gameObject.SetActive(false);
		}
	}
}
