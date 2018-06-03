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

			mMasterDataRepository = Resources.Load<MasterDataRepository>("MasterDataRepository");

			Item.Item item = new Item.Item();
			item.Initialize(mMasterDataRepository.GetMstTest(1));

		}

		/// アクセサ
		public Pikachu Pikachu()
		{
			return mPikachu;
		}

		public MasterDataRepository MasterDataRepository()
		{
			return mMasterDataRepository;
		}

		/// -------------------------------------------------
		Pikachu mPikachu;

		MasterDataRepository mMasterDataRepository;

	}
}