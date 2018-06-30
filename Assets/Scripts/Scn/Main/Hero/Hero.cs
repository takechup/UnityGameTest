using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main.Hero
{
	/// メインプレイヤーにアタッチして使用してください
	[RequireComponent(typeof(Collision2D))]
	public partial class Hero : MonoBehaviour
	{
		// 歩行の閾値
		private const float thresholdWalk = 0.20f;

		public void Awake()
		{
			mStateMachine = StateMachine<State>.Initialize(this);
			ChangeState(State.Init);
		}

		/// -----------------------------------------------
		public void Start()
		{
			mController2D = GetComponent<Controller2D>();

			//入力
			mInput = new Input();
			mInput.Initialize(mController2D);

			// アニメ
			mAnim = new Animation();
			mAnim.Initialize(this.GetComponent<Animator>());
		
		}

		/// -----------------------------------------------
		/// 更新
		public void Update()
		{
			mInput.Update();

			/// 向き変更
			if(mInput.Velocity().x > thresholdWalk){ this.transform.localScale = Vector3.one; }
			if(mInput.Velocity().x < -thresholdWalk){ this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); }
		}

		// ステート変更用共通関数
		public void ChangeState(State aState)
		{
			Debug.Log("ChangeState : " + mCurtState.ToString() + " -> " + aState.ToString());
			mCurtState = aState;
			mStateMachine.ChangeState(mCurtState);
		}

		/// -----------------------------------------------
		/// ぶつかった瞬間に呼び出される
		void OnTriggerEnter2D (Collider2D c)
		{
			if(c.tag == "Enemy")
			{
				// 弾の削除
				Debug.Log("Destroy");
			}
		}

		/// -----------------------------------------------
		/// データ

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

		StateMachine<State> mStateMachine;
		State mCurtState;

		Controller2D mController2D;
		Input mInput;
		Animation mAnim;
	}
}
