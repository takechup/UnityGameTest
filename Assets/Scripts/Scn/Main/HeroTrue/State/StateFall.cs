using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.HeroTrue.State
{
	public partial class StateManager
	{
		// 入った瞬間
		public void Fall_Enter()
		{
			Animation().StopAll();
			Animation().StartFall();
		}

		// 実行中
		public void Fall_Update()
		{
			var vel = Input().Velocity();
			
			// 地上
			if(Controller2D().collisions.below) 
			{
				// if(vel.y < 0){ ChangeState(State.Fall); return; }
				if(Mathf.Abs(Input().Velocity().x) > Obj.thresholdWalk)
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
			Animation().StopAll();
		}

	}
}
