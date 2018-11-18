using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム進行管理クラス
/// </summary>
[RequireComponent(typeof(ScoreManager))]
public class GameContoroller : SingletonMonoBehavior<GameContoroller>
{
	/// <summary>
	/// 現在のモード
	/// </summary>
	public Mode NowMode { get; private set; }

	/// <summary>
	/// ポーズ画面
	/// </summary>
	[SerializeField] private GameObject _pause;
	
	/// <summary>
	/// ゲームオーバー画面
	/// </summary>
	[SerializeField] private GameObject _gameOver;

	/// <summary>
	/// プレイヤーオブジェクト
	/// </summary>
	[SerializeField] private GameObject _player;

	/// <summary>
	/// スコアマネージャ
	/// </summary>
	[SerializeField] private ScoreManager _scoreManager = null;
	public ScoreManager Score { get { return _scoreManager; } }

	/// <summary>
	/// スクリーン座標の最大値
	/// </summary>
	private Vector2 _max;
	public Vector2 ScreenMax { get { return _max; } }

	/// <summary>
	/// スクリーン座標の最小値
	/// </summary>
	private Vector2 _min;
	public Vector2 ScreenMin { get { return _min; } }

	//--------------------------------------------------
	private void Awake()
	{
		NowMode = Mode.Play;
		var size = this.transform.parent.GetComponent<RectTransform>().sizeDelta;
		_min -= _max = (size / 2);
	}

	private void Update()
	{
		if (_player.activeSelf == false)
		{
			NowMode = Mode.GameOver;
		}

		switch (NowMode)
		{
			case Mode.Play:
				if (_pause.activeSelf) _pause.SetActive(false);
				if (_gameOver.activeSelf) _gameOver.SetActive(false);
				break;

			case Mode.Pause:
				if (!_pause.activeSelf) _pause.SetActive(true);
				if (_gameOver.activeSelf) _gameOver.SetActive(false);
				break;

			case Mode.GameOver:
				if (_pause.activeSelf) _pause.SetActive(false);
				if (!_gameOver.activeSelf) _gameOver.SetActive(true);
				break;
		}
	}

	//--------------------------------------------------
	// uGUI
	/// <summary>
	/// ポーズボタン
	/// </summary>
	public void OnClick_Pause()
	{
		NowMode = Mode.Pause;
	}

	/// <summary>
	/// コンティニューボタン
	/// </summary>
	public void OnClick_Continue()
	{
		NowMode = Mode.Play;
	}

	/// <summary>
	/// リトライボタン
	/// </summary>
	public void OnClick_Retry()
	{
		SceneManager.LoadScene("Play");
	}

	/// <summary>
	/// タイトルボタン
	/// </summary>
	public void OnClick_Title()
	{
		SceneManager.LoadScene("Title");
	}

	//--------------------------------------------------
	/// <summary>
	/// プレイシーンのモード
	/// </summary>
	public enum Mode
	{
		Play,
		Pause,
		GameOver,
	}
}
