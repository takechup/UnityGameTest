using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MasterDataRepository : ScriptableObject
{
	[SerializeField] testMstData testData;

	public TestMstEntity GetMstTest(int id)
	{
		return testData.Entities.Find(entity => entity.id == id);
	}

}