using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.HeroTrue.State
{
	public partial class StateManager
	{
		// 入った瞬間
		public void Wait_Enter()
		{
			Animation().StopAll();
			Animation().StartWait();
		}

		// 実行中
		public void Wait_Update()
		{
			var vel = Input().Velocity();

			// 空中
			if(!Controller2D().collisions.below) 
			{
				if(vel.y > 0){ ChangeState(State.Jump); return;}
				if(vel.y < 0){ ChangeState(State.Fall); return; }
			}

			// 地上
			if(Mathf.Abs(Input().Velocity().x) > Obj.thresholdWalk)
			{
				ChangeState(State.Walk);
			}

			// 入力
			if(UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
			{
				ChangeState(State.Attack);
			}
			
		}

		// 終了時
		public void Wait_Exit()
		{
		}

	}
}
