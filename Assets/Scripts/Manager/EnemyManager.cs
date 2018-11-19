using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーマネージャ
/// </summary>
public class EnemyManager : MonoBehaviour
{
	/// <summary>
	/// エネミーの生成ターゲット
	/// </summary>
	[SerializeField] private Transform _createTarget;

	/// <summary>
	/// エネミープレハブ
	/// </summary>
	[SerializeField] private GameObject _enemy;

	/// <summary>
	/// スポーンタイム
	/// </summary>
	[SerializeField] private float _spawnTime = 5f;
	
	/// <summary>
	/// 経過時間
	/// </summary>
	private float _elapseTime = 0f;

	private void Update()
	{
		if (GameContoroller.Instance.NowMode != GameContoroller.Mode.Play) return;

		_elapseTime += Time.deltaTime;
		if (_elapseTime > _spawnTime)
		{
			if (_enemy)
			{
				var created = Instantiate(_enemy, _createTarget).GetComponent<CharaBase>();
				var x = Random.Range(GameContoroller.Instance.ScreenMin.x + 100f, GameContoroller.Instance.ScreenMax.x - 100f);
				created.Position = new Vector2(x, 1000f);
			}

			_elapseTime = 0f;
		}
	}
}
