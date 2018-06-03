using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Item
{
	public class Item {

		// コンストラクタ
		public Item () 
		{
		}
		
		// 初期化
		public void Initialize(TestMstEntity mEntity)
		{
			name = mEntity.name;
			price = mEntity.price;

			Debug.Log("名前：" + name);
			Debug.Log("プライス：" + price.ToString());
		}


	public string name { get; private set;}
	public int price   { get; private set; }


	}
}
