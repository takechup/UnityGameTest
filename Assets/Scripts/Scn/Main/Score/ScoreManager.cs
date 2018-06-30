using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Take.Scn.Main.Score
{
	/// スコアを管理するマネージャ
	/// シーンの空オブジェクトにアタッチしてください
	public class ScoreManager : MonoBehaviour {

		public void Start()
		{
			mScoreText = GameObject.Find("Canvas/Score").GetComponent<TextMeshProUGUI>();
			mScore = 0;
		}


		public void Update()
		{
			mScoreText.text = "Score: " + mScore.ToString();
		}

		/// ---------------------------------------------------------
		/// データ
		public int mScore { get; set; }

		private TextMeshProUGUI mScoreText;


	}
}
