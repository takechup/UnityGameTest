using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Save
{
	public class SaveManager {

		public SaveManager()
		{
		}

		public void Initialize()
		{
			// セーブテスピカチュウ
			mPikachu = new Pikachu();
			mPikachu.Initialize();
			mPikachu = SaveUtil.GetObject<Pikachu>("Pikachu");
			//SaveUtil.SetObject<Pikachu>("Pikachu", pika);
		}

		/// アクセサ
		public Pikachu Pikachu()
		{
			return mPikachu;
		}

		/// -------------------------------------------------
		Pikachu mPikachu;

	}
}