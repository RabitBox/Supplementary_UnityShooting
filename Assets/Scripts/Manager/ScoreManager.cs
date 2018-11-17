using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコア管理クラス
/// </summary>
public class ScoreManager : MonoBehaviour
{
	/// <summary>
	/// スコア
	/// 加算時に自動更新
	/// </summary>
	private int _score;
	public int Score
	{
		get { return _score; }
		set
		{
			_score = value;
			if (_scoreText)
			{
				_scoreText.text = "SCORE:" + _score.ToString("00000000");
			}
		}
	}

	/// <summary>
	/// スコアテキスト
	/// </summary>
	[SerializeField]private Text _scoreText;
}
