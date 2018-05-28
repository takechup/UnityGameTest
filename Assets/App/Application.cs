using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.App
{
	public class Application : MonoBehaviour 
	{
		public static Application Instance()
		{
			return sInstance;
		}

		/// シーン読み込み時に必ず呼ばれる
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void OnLoad()
		{
			GameObject app = Instantiate(Resources.Load("Prefabs/App/Application")) as GameObject;
			DontDestroyOnLoad(app);
			app.name = "App";
		}

		/// アクセサ
		// public SampleManager SampleManager()
		// {
		// 	return mSampleManager;
		// }

		public Save.SaveManager SaveManager()
		{
			return mSaveManager;
		}

		void Awake()
		{
			mSaveManager = new Save.SaveManager();
			mSaveManager.Initialize();
		}

		// Update is called once per frame
		void Update () 
		{
			
		}

		/// 各種データ
		static Application sInstance;

		/// セーブ
		Save.SaveManager mSaveManager;
	}
}