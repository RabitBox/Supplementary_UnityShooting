using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム進行管理クラス
/// </summary>
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

	private Vector2 _max;
	public Vector2 ScreenMax { get { return _max; } }
	private Vector2 _min;
	public Vector2 ScreenMin { get { return _min; } }

	//--------------------------------------------------
	private void Awake()
	{
		NowMode = Mode.Play;
		var size = this.transform.parent.GetComponent<RectTransform>().sizeDelta;
		_min -= _max = (size / 2);
	}

	//--------------------------------------------------
	// uGUI
	/// <summary>
	/// ポーズボタン
	/// </summary>
	public void OnClick_Pause()
	{
		if(_pause != null)
		{
			_pause.SetActive( !_pause.activeSelf );
			NowMode = Mode.Pause;
		}
	}

	/// <summary>
	/// コンティニューボタン
	/// </summary>
	public void OnClick_Continue(GameObject target = null)
	{
		if(target != null)
		{
			target.SetActive( !target );
			NowMode = Mode.Play;
		}
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
