using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.Hero
{
	public partial class Hero
	{
		// 入った瞬間
		public void Attack_Enter()
		{
			mAnim.StopAll();
			mAnim.StartAttack();

			/// 入力受付無効
			mInput.mIsInput = false;
		}

		// 実行中
		public void Attack_Update()
		{ 
			Debug.Log(mAnim.Animator().GetCurrentAnimatorStateInfo(0).normalizedTime.ToString());

			if(mAnim.IsAnimEnd())
			{
				ChangeState(State.Wait);
			}
		}

		// 終了時
		public void Attack_Exit()
		{
			/// 入力受付有効			
			mInput.mIsInput = true;
		}

	}
}
