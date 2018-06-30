using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.HeroTrue.State
{
	public partial class StateManager
	{
		// 入った瞬間
		public void Attack_Enter()
		{
			Animation().StopAll();
			Animation().StartAttack();

			/// 入力受付無効
			Input().mIsInput = false;
		}

		// 実行中
		public void Attack_Update()
		{ 
			Debug.Log(Animation().Animator().GetCurrentAnimatorStateInfo(0).normalizedTime.ToString());

			if(Animation().IsAnimEnd())
			{
				ChangeState(State.Wait);
			}
		}

		// 終了時
		public void Attack_Exit()
		{
			/// 入力受付有効			
			Input().mIsInput = true;
		}

	}
}
