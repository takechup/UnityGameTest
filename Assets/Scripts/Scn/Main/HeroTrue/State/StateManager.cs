using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.HeroTrue.State
{
	public partial class StateManager : MonoBehaviour{

		// コンストラクタ
		public StateManager () 
		{
		}
		
		// 初期化
		public void Initialize(Obj aObj)
		{
			mObj = aObj;

			mStateMachine = StateMachine<State>.Initialize(this);
			ChangeState(State.Init);
		}

		// ステート変更用共通関数
		public void ChangeState(State aState)
		{
			Debug.Log("ChangeState : " + mCurtState.ToString() + " -> " + aState.ToString());
			mCurtState = aState;
			mStateMachine.ChangeState(mCurtState);
		}

		// ステート
		public enum State
		{
			Init,
			Wait,
			Walk,
			Jump,
			Fall,
			Attack
		}

		/// 便利アクセサ
		private Animation Animation()       { return mObj.Animation(); }
		private Input Input()		        { return mObj.Input(); }
		private Controller2D Controller2D() {return mObj.Controller2D(); }

		/// -----------------------------------------------
		Obj mObj;

		StateMachine<State> mStateMachine;
		State mCurtState;

	}
}
