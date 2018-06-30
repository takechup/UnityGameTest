using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.Hero
{
	public partial class Hero
	{
		// 入った瞬間
		public void Jump_Enter()
		{
			mAnim.StopAll();
			mAnim.StartJump();
		}

		// 実行中
		public void Jump_Update()
		{
			var vel = mInput.Velocity();
			bool grounded = mController2D.collisions.below;
			
			// 空中
			if(!grounded)
			{
				/// 落下
				if(vel.y < 0){ ChangeState(State.Fall); return; }
			}
			
			// 地上
			if(grounded)
			{
				if(Mathf.Abs(mInput.Velocity().x) > thresholdWalk) { ChangeState(State.Walk);}
				
				ChangeState(State.Wait);
				return;
			}

			// 入力
			if(UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
			{
				ChangeState(State.Attack);
			}
		}

		// 終了時
		public void Jump_Exit()
		{
			mAnim.StopAll();
		}

	}
}
