using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main
{
	public class HeroAnimation {

		private const float thresholdWalk = 0.20f;

		// コンストラクタ
		public HeroAnimation () 
		{
		}
		
		// 初期化
		public void Initialize(GameObject aObj)
		{
			mObj = aObj;
			mHero = mObj.transform.GetComponent<Hero>();
		}

		// 更新
		public void Update()
		{
			StopAll();

			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				StartChange();
			}
		
			// 右
			if(mHero.Velocity().x > thresholdWalk)
			{
				mHero.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				mHero.Animator().SetBool("Walk", true);

				/// 空中にいる
				if(!mHero.Controller2D().collisions.below)
				{
					// ジャンプ中
					if(mHero.Velocity().y > 0)
					{
						StopAll();
						StartJump();
					}
					else if(mHero.Velocity().y < 0)
					{
						StopAll();
						StartFall();
					}
				}
			} 
			else if(mHero.Velocity().x < -thresholdWalk)
			{
				mHero.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
				mHero.Animator().SetBool("Walk", true);

				/// 空中にいる
				if(!mHero.Controller2D().collisions.below)
				{

					if(mHero.Velocity().y > 0)
					{
						// ジャンプ中
						StopAll();
						StartJump();
					}
					else if(mHero.Velocity().y < 0)
					{
						// 落下中
						StopAll();
						StartFall();
					}
				}
			} 
			else 
			{
				/// 空中にいる
				if(!mHero.Controller2D().collisions.below)
				{

					if(mHero.Velocity().y > 0)
					{
						// ジャンプ中
						StopAll();
						StartJump();
					}
					else if(mHero.Velocity().y < 0)
					{
						// 落下中
						StopAll();
						StartFall();
					}
				}
			}
		}


		/// アニメ用便利関数
		private void StartWalk() { mHero.Animator().SetBool("Walk", true); }
		private void StopWalk()  { mHero.Animator().SetBool("Walk", false); }
		private void StartJump() { mHero.Animator().SetBool("Jump", true); }
		private void StopJump()  { mHero.Animator().SetBool("Jump", false); }
		private void StartFall() { mHero.Animator().SetBool("Fall", true); }
		private void StopFall()  { mHero.Animator().SetBool("Fall", false); }

		private void StartChange() { mHero.Animator().SetTrigger("Change"); }

		private void StopAll()
		{
			StopWalk();
			StopFall();
			StopJump();
		}

		/// ---------------------------------------------------
		/// データ(仮)
		Hero mHero;
		GameObject mObj;
		Animator mAnimator;

	}
}
