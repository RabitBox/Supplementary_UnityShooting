using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾丸クラス
/// </summary>
public class Bullet : MonoBehaviour
{
	/// <summary>
	/// 親のタグ
	/// </summary>
	public string ParentTag { get; set; }

	/// <summary>
	/// スピード
	/// </summary>
	[SerializeField]protected float _speed = 3f;

	//--------------------------------------------------
	protected virtual void Update()
	{
		this.transform.position += Vector3.up * _speed;
	}
}
