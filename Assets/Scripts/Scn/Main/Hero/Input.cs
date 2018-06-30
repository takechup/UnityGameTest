using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main.Hero
{
	// 入力・移動を管理するひと
	public class Input {

		/// 各種パラメータ。今回は決め打ち
		public float jumpHeight = 0.7f;
    	public float timeToJumpApex = 0.4f;
    	float accelerationTimeAirborne = 0.15f;
    	float accelerationTimeGrounded = 0.1f;

    	float jumpVelocity;
    	Vector3 velocity;
    	float velocityXSmoothing;

		float mSpeed;
		float mGravity;
		Vector3 mVelocity;

		// コンストラクタ
		public Input () 
		{
		}
		
		// 初期化
		public void Initialize(Controller2D aController)
		{
			mControllerRef = aController; 

			mSpeed = 10.0f;
			mGravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
			jumpVelocity = Mathf.Abs(mGravity) * timeToJumpApex;

			// 入力受付
			mIsInput = true;
		}

		/// 更新
		public void Update()
		{
			if (mControllerRef.collisions.above || mControllerRef.collisions.below) 
			{
            	mVelocity.y = 0;
        	}

			/// 移動
        	Vector2 input = new Vector2 (UnityEngine.Input.GetAxisRaw ("Horizontal"), UnityEngine.Input.GetAxisRaw ("Vertical"));

			if(UnityEngine.Input.GetKeyDown(KeyCode.Space) && mControllerRef.collisions.below && mIsInput)
			{
				mVelocity.y = jumpVelocity;
			}

			float targetVelocityX = input.x * mSpeed;
        	mVelocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (mControllerRef.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        	mVelocity.y += mGravity * Time.deltaTime;
			mVelocity.x = mIsInput ? mVelocity.x : 0.0f;
        	mControllerRef.Move(mVelocity * Time.deltaTime);
		}

		/// アクセサ
		public Vector3 Velocity() { return mVelocity; }
		public bool mIsInput { get; set; }

		/// ---------------------------------------------
		private Controller2D mControllerRef;

	}
}
