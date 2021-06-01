using UnityEngine;

namespace Take.Save
{
	/// データ保存用便利関数
	public class SaveUtil {
		

		/// 指定されたオブジェクトの情報を保存
		public static void SetObject<T>( string key, T obj)
		{
			var json = JsonUtility.ToJson(obj);
			PlayerPrefs.SetString(key, json);
		}

		/// 指定されたオブジェクトの情報を読み込む
		public static T GetObject<T>(string key)
		{
			var json = PlayerPrefs.GetString(key);
			var obj = JsonUtility.FromJson<T>(json);
			return obj;
		}
	}
}