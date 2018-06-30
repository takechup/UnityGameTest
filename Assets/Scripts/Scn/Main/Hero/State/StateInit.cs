using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.Hero
{
	public partial class Hero
	{
		// 入った瞬間
		public void Init_Enter()
		{
		}

		// 実行中
		public void Init_Update()
		{
			ChangeState(State.Wait);
		}

		// 終了時
		public void Init_Exit()
		{
		}

	}
}
