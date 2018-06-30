using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Take.Scn.Station
{
	public class Scene : MonoBehaviour
	{
		public void Start()
		{
			mScrollButton = GameObject.Find("Canvas/ScrollScene").GetComponent<UnityEngine.UI.Button>();
			mScrollButton.onClick.AddListener(OnClickScroll);

		}

		public void Update()
		{
		}

		private void OnClickScroll()
		{
			SceneManager.LoadScene("SampleScene");
		}

		/// ---------------------------------------
		UnityEngine.UI.Button mScrollButton;

	}
}
