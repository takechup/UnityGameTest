using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main
{
	/// メインプレイヤーにアタッチして使用してください
	[RequireComponent (typeof (Controller2D))]
	public class Hero : MonoBehaviour 
	{

		public void Start() 
		{
			mSpeed = 1.0f;
			mGravity = -10.0f;
			mController = GetComponent<Controller2D> ();
		}

		public void Update() 
		{
			/// 移動
        	Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        	mVelocity.x = input.x * mSpeed;
        	mVelocity.y += mGravity * Time.deltaTime;
        	mController.Move(mVelocity * Time.deltaTime);
    	}

		/// --------------------------------------------
		/// データ
		private Controller2D mController;

		private float mSpeed;
		private float mGravity;
		private Vector3 mVelocity;


	}
}