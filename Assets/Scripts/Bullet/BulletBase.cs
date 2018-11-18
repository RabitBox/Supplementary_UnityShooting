using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾丸クラス
/// </summary>
public class BulletBase : MonoBehaviour
{
	/// <summary>
	/// 生成者のタグ
	/// </summary>
	public string CreaterTag { get; set; }

	/// <summary>
	/// スピード
	/// </summary>
	[SerializeField]protected float _speed = 3f;

	/// <summary>
	/// トランスフォーム
	/// </summary>
	protected RectTransform _rectTransform = null;

	//--------------------------------------------------
	protected virtual void Update()
	{
		if (_rectTransform) { _rectTransform.anchoredPosition += Vector2.up * _speed; }
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Wall") { this.gameObject.SetActive(false); }
	}

	//--------------------------------------------------
	/// <summary>
	/// 座標のセット
	/// </summary>
	/// <param name="position">セットする座標</param>
	public void SetPosition(Vector2 position)
	{
		if (_rectTransform == null) { _rectTransform = this.gameObject.GetComponent<RectTransform>(); }
		_rectTransform.anchoredPosition = position;
	}
}
