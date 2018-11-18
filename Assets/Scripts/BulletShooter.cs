using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾生成クラス
/// 弾を持つキャラは全て持つ
/// </summary>
[RequireComponent(typeof(CharaBase)), DisallowMultipleComponent]
public class BulletShooter : MonoBehaviour
{
	/// <summary>
	/// 生成する弾プレハブ
	/// </summary>
	[SerializeField]private GameObject _bulletPrefab;

	/// <summary>
	/// 弾生成間隔(フレーム単位)
	/// </summary>
	[SerializeField] private int _fireRate = 5;

	/// <summary>
	/// 現在のレート
	/// </summary>
	private int _nowRateTime = 0;

	/// <summary>
	/// 生成済みの弾
	/// </summary>
	private List<BulletBase> _bullets = new List<BulletBase>();

	/// <summary>
	/// 生成座標
	/// </summary>
	[SerializeField]private List<Vector2> _createPosition;

	//--------------------------------------------------
	/// <summary>
	/// 弾生成処理
	/// </summary>
	/// <param name="createrPosition">生成者のポジション</param>
	/// <param name="createTarget">生成するゲームオブジェクト</param>
	public void Shot(Vector2 createrPosition, Transform createTarget = null)
	{
		_nowRateTime--;

		if (_nowRateTime <= 0 && _bulletPrefab != null)
		{
			foreach(var position in _createPosition)
			{
				BulletBase data = null;
				foreach (var bullet in _bullets)
				{
					if (bullet.gameObject.activeSelf == false)
					{
						bullet.gameObject.SetActive(true);
						data = bullet;
						break;
					}
				}

				if(data == null)
				{
					data = Instantiate(_bulletPrefab, createTarget).GetComponent<BulletBase>();
					data.CreaterTag = this.gameObject.tag;
					_bullets.Add(data);
				}

				data.SetPosition(createrPosition + position);
			}
			_nowRateTime = _fireRate;
		}
	}

	/// <summary>
	/// 初期設定を行う
	/// </summary>
	/// <param name="createTarget">生成時の親オブジェクト</param>
	/// <param name="defaultCreateNumber">初期生成量</param>
	//public void SetUp(Transform createTarget, int defaultCreateNumber = 10)
	//{
	//	for (int count = 0; count < defaultCreateNumber; count++)
	//	{
	//		var createdData = Instantiate(_bulletPrefab, createTarget).GetComponent<BulletBase>();
	//		createdData.CreaterTag = this.gameObject.tag;
	//		_bullets.Add(createdData);
	//	}
	//}

	//--------------------------------------------------
	private void OnDisable()
	{
		foreach(var bullet in _bullets)
		{
			bullet.gameObject.SetActive(false);
		}
	}
}
