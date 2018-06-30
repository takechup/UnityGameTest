using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

namespace Take.Scn.Main
{
	/// メインプレイヤーにアタッチして使用してください
	[RequireComponent (typeof (Controller2D))]
	public class Hero : MonoBehaviour 
	{
		public enum State
		{
			Init,
			Play,
			Dead
		}

		public float jumpHeight = 0.01f;
    	public float timeToJumpApex = 0.2f;
    	float accelerationTimeAirborne = 0.15f;
    	float accelerationTimeGrounded = 0.1f;

    	float jumpVelocity;
    	Vector3 velocity;
    	float velocityXSmoothing;

		// 紙を折り曲げずにあかまるをみっつあおまるをよっつつくりつくったまるがあるへやのだけのもじだけをよもう

		public void Awake()
		{
			mStateMachine = StateMachine<State>.Initialize(this);
			mStateMachine.ChangeState(State.Init);
		}

		void Init_Enter()
		{
			Debug.Log("We are not Dead");
		}

		void Init_Update()
		{
		}

		public void Start() 
		{
			mSpeed = 10.0f;
			mController = GetComponent<Controller2D> ();

	        mGravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
	        jumpVelocity = Mathf.Abs(mGravity) * timeToJumpApex;

			/// アニメーション
			mObj = this.gameObject;
			mAnimator = this.GetComponent<Animator>();
			mHeroAnim = new HeroAnimation();
			mHeroAnim.Initialize(mObj);

			/// 攻撃
			mWeapon = new Weapon();
			mWeapon.Initialize(mObj);
		}

		public void Update() 
		{
			if (mController.collisions.above || mController.collisions.below) 
			{
            	mVelocity.y = 0;
        	}

			/// 移動
        	Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

			if(Input.GetKeyDown(KeyCode.Space) && mController.collisions.below)
			{
				mVelocity.y = jumpVelocity;
			}

			float targetVelocityX = input.x * mSpeed;
        	mVelocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (mController.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        	mVelocity.y += mGravity * Time.deltaTime;
        	mController.Move(mVelocity * Time.deltaTime);

			/// アニメーションの更新
			mHeroAnim.Update();

			/// 武器更新
			mWeapon.Update();
    	}

		// ぶつかった瞬間に呼び出される
		void OnTriggerEnter2D (Collider2D c)
		{
			if(c.tag == "Enemy")
			{
				// 弾の削除
				Debug.Log("Destroy");
			}
		}


		/// アクセサ
		public Vector3 Velocity() 		     { return mVelocity; }
		public Controller2D Controller2D()   { return mController; }
		public Animator Animator() 			 { return mAnimator; }
		public Hero HeroInfo()           		 { return this; }

		/// --------------------------------------------
		/// データ
		private Controller2D mController;
		private HeroAnimation mHeroAnim;
		private Animator mAnimator;

		private GameObject mObj;
		private Weapon mWeapon;

		private float mSpeed;
		private float mGravity;
		private Vector3 mVelocity;

		private StateMachine<State> mStateMachine;
	}
}