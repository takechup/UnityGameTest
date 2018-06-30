using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main
{
	public class EnemyAnimation {

				private const float thresholdWalk = 0.20f;

		// コンストラクタ
		public EnemyAnimation () 
		{
		}
		
		// 初期化
		public void Initialize(GameObject aObj)
		{
			mObj = aObj;
			mEnemy = mObj.transform.GetComponent<Enemy>();
		}

		// 更新
		public void Update()
		{
			StopAll();
		
			// 右
			if(mEnemy.Velocity().x > thresholdWalk)
			{
				mEnemy.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				mEnemy.Animator().SetBool("Walk", true);
			} 
			else
			{
				mEnemy.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
				mEnemy.Animator().SetBool("Walk", true);
			} 
		}


		/// アニメ用便利関数
		private void StartWalk() { mEnemy.Animator().SetBool("Walk", true); }
		private void StopWalk()  { mEnemy.Animator().SetBool("Walk", false); }

		private void StopAll()
		{
			StopWalk();
		}

		/// ---------------------------------------------------
		/// データ(仮)
		Enemy mEnemy;
		GameObject mObj;
		Animator mAnimator;

	}
}
