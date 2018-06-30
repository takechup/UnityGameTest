using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main
{
	public class Weapon : MonoBehaviour{

		// コンストラクタ
		public Weapon () 
		{
		}
		
		// 初期化
		public void Initialize(GameObject aObj)
		{
			mHeroObj = aObj;
			mCount = 0.0f;
			mIsTimer = false;

			mWeapon = null;
		}

		/// 更新
		public void Update()
		{
			/// キー
			if(Input.GetKeyDown(KeyCode.UpArrow) && !mIsTimer)
			{
				// タイマー
				mIsTimer = true;
				mCount = 0.8f;
				// 攻撃開始
				var weapon = Resources.Load("Prefabs/Attack") as GameObject;
				mWeapon = Instantiate(weapon, mHeroObj.transform.position, Quaternion.identity);	
				//mWeapon.transform.parent = mHeroObj.transform;

			}

			// タイマー不使用中は不要
			if(!mIsTimer){ return; }

			if(mCount > 0.0f)
			{
				mCount -= Time.deltaTime;
			}

			if(mCount <= 0.0f)
			{
				mIsTimer = false;
				mCount = 0.0f;
				Debug.Log("Timer is End");
				Destroy(mWeapon);
			}
		}


		/// --------------------------------------------------------------------
		/// データ
		GameObject mHeroObj;
		GameObject mWeapon;

		/// タイマー
		bool mIsTimer;
		float mCount;
		

	}
}
