using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main.Hero
{
	/// アニメーション周りの管理をする人
	public class Animation 
	{

		// コンストラクタ
		public Animation ()
		{
		}
		
		// 初期化
		public void Initialize(Animator aAnim)
		{
			mAnimator = aAnim;
		}


		/// アクセサ
		public Animator Animator() { return mAnimator; }

		/// アニメ用便利関数
		/// 絶対やめたほうが良い
		public void StartWalk() { mAnimator.SetBool("Walk", true); }
		public void StopWalk()  { mAnimator.SetBool("Walk", false); }
		public void StartJump() { mAnimator.SetBool("Jump", true); }
		public void StopJump()  { mAnimator.SetBool("Jump", false); }
		public void StartFall() { mAnimator.SetBool("Fall", true); }
		public void StopFall()  { mAnimator.SetBool("Fall", false); }
		public void StartWait() { mAnimator.SetBool("Idle", true); }
		public void StopWait()  { mAnimator.SetBool("Idle", false); }

		public void StartAttack() { mAnimator.SetTrigger("Change"); }
		public bool IsAnimEnd(){ return mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f; }

		public void StopAll()
		{
			StopWalk();
			StopFall();
			StopJump();
			StopWait();
		}



		/// ---------------------------------------
		private Animator mAnimator;
	}
}
