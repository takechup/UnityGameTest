using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.Hero
{
	public partial class Hero
	{
		// 入った瞬間
		public void Fall_Enter()
		{
			mAnim.StopAll();
			mAnim.StartFall();
		}

		// 実行中
		public void Fall_Update()
		{
			var vel = mInput.Velocity();
			
			// 地上
			if(mController2D.collisions.below) 
			{
				// if(vel.y < 0){ ChangeState(State.Fall); return; }
				if(Mathf.Abs(mInput.Velocity().x) > thresholdWalk)
				{
					ChangeState(State.Walk);
					return;
				}

				ChangeState(State.Wait);
			}

			// 入力
			if(UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
			{
				ChangeState(State.Attack);
			}
		}

		// 終了時
		public void Fall_Exit()
		{
			mAnim.StopAll();
		}

	}
}
