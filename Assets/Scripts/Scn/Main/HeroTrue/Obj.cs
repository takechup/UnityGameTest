using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main.HeroTrue
{
	/// メインプレイヤーにアタッチして使用してください
	[RequireComponent(typeof(Collision2D))]
	[RequireComponent(typeof(State.StateManager))]
	public class Obj : MonoBehaviour
	{
		// 歩行の閾値
		public const float thresholdWalk = 0.20f;

		public void Awake()
		{
		}

		/// -----------------------------------------------
		public void Start()
		{
			mController2D = GetComponent<Controller2D>();
			// ステート
			mStateManager = GetComponent<State.StateManager>();
			mStateManager.Initialize(this);

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

		/// アクセサ
		public Animation Animation()       { return mAnim; }
		public Input Input()         	   { return mInput; }
		public Controller2D Controller2D() { return mController2D; }
		public State.StateManager StateManager() { return mStateManager; }

		/// -----------------------------------------------
		/// データ


		Controller2D mController2D;
		Input mInput;
		Animation mAnim;

		State.StateManager mStateManager;
	}
}
