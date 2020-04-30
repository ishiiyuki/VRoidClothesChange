using System;
using System.Collections;

using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;

using static Clothes_Params.ClothesParam;

/// <summary>
/// 下半身服用の着せ替え機能
/// </summary>
public class ChangeClothesBottom : MonoBehaviour
{
	// Start is called before the first frame update

	[Header("服のメッシュパターン")]
	[SerializeField]
	BottomType myClothesTyep;

	public BottomType MyBottomTyepe
	{
		get { return myClothesTyep; }
	}


	private Transform body;

	public Transform Body
	{
		get { return body; }
		set { body = value; }

	}



	private Material material;

	[SerializeField]
	private Texture clothesBottom;

	private bool isVRoid = false;

	public bool IsVRoid {
		get { return isVRoid; }
		set
		{
			isVRoid = value;
		}
	}

	private bool isBodyHit = false;

	BottomType bodyBottomType;

	void Start()
    {

		material = this.GetComponent<Renderer>().material;


		material.SetTexture("_MainTex", clothesBottom);

	}


	//ヒット判定
	void OnTriggerStay(Collider other)
	{

		if(isBodyHit)
		{
			return;
		}
		if(other.gameObject.layer == 11)
		{
			isBodyHit = true;

			var backClothes = GameObject.Find("ChangeClothes").GetComponent<BackClothes>();
			Body = backClothes.Body;
			isVRoid = backClothes.IsVRoid;
			bodyBottomType = backClothes.IsClothesBottomTyep;



		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			isBodyHit = false;
			Body = null;
		}
	}





	void ChangeCloth()
	{
		if(!isVRoid)
		{
			return;
		}
		if (!body)
		{
			return;
		}

		//パーツの相性があっていること（一旦この流れで）
		if(bodyBottomType != myClothesTyep)
		{
			return;
		}

		//Onepice変更の処理
		ChangeTop();

	}

	void ChangeTop()
	{
		Material[] sharedMaterials = body.GetSharedMaterials();
		foreach (Material material in sharedMaterials)
		{
			Debug.Log(material.name);
			if (material.name.IndexOf("_Bottoms", StringComparison.Ordinal) >= 0)
			{
				if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0 &&
					(bodyBottomType == BottomType.Skirt))
				{
					//制服
					material.mainTexture = clothesBottom;
					if (material.shader.name.Contains("VRM/MToon"))
					{
						material.SetTexture("_ShadeTexture", clothesBottom);
					}
				}
				else if (material.name.IndexOf("_003", StringComparison.Ordinal) >= 0 &&
					(bodyBottomType == BottomType.Pants))
				{

					//制服ズボン系
					material.mainTexture = clothesBottom;
					if (material.shader.name.Contains("VRM/MToon"))
					{
						material.SetTexture("_ShadeTexture", clothesBottom);
					}
				}
				else if (material.name.IndexOf("_004", StringComparison.Ordinal) >= 0 && (bodyBottomType == BottomType.PencilSkirt))
				{
					//ペンシルスカート
					material.mainTexture = clothesBottom;
					if (material.shader.name.Contains("VRM/MToon"))
					{
						material.SetTexture("_ShadeTexture", clothesBottom);
					}
				}

				else if (material.name.IndexOf("_008", StringComparison.Ordinal) >= 0 &&
					(bodyBottomType == BottomType.PencilSkirt))
				{
					//ロングコートズボン
					material.mainTexture = clothesBottom;
					if (material.shader.name.Contains("VRM/MToon"))
					{
						material.SetTexture("_ShadeTexture", clothesBottom);
					}
				}


			}
		}
	}



}
