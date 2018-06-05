using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main
{
	/// メインプレイヤーにアタッチして使用してください
	[RequireComponent (typeof (Controller2D))]
	public class Hero : MonoBehaviour 
	{
		public float jumpHeight = 0.01f;
    	public float timeToJumpApex = 0.2f;
    	float accelerationTimeAirborne = 0.15f;
    	float accelerationTimeGrounded = 0.1f;

    	float jumpVelocity;
    	Vector3 velocity;
    	float velocityXSmoothing;

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
    	}


		/// アクセサ
		public Vector3 Velocity() 		     { return mVelocity; }
		public Controller2D Controller2D()   { return mController; }
		public Animator Animator() { return mAnimator; }

		/// --------------------------------------------
		/// データ
		private Controller2D mController;
		private HeroAnimation mHeroAnim;
		private Animator mAnimator;

		private GameObject mObj;

		private float mSpeed;
		private float mGravity;
		private Vector3 mVelocity;


	}
}