using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main
{
	public class Attack : MonoBehaviour{

		// コンストラクタ
		public Attack () 
		{
		}
		
		// 初期化
		public void Initialize()
		{
		}

		public void Start()
		{
			/// スコア
			mScoreManager = GameObject.Find("ScoreManager").GetComponent<Score.ScoreManager>();
			mHero = GameObject.Find("Hero") as GameObject;
		}

		public void Update()
		{

		}

		// ぶつかった瞬間に呼び出される
		public void OnTriggerEnter2D (Collider2D c)
		{
			if(c.tag == "Enemy")
			{
				// 弾の削除
				++mScoreManager.mScore;
				Destroy(c.gameObject);
			}
		}


		/// -------------------------------------------------------
		/// データ
		private Score.ScoreManager mScoreManager;
		private GameObject mHero;

	}
}
