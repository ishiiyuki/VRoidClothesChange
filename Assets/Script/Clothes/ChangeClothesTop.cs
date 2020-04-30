using System;
using System.Collections;

using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;

using static Clothes_Params.ClothesParam;

/// <summary>
/// 上半身服用の着せ替え機能
/// </summary>
public class ChangeClothesTop : MonoBehaviour
{
	// Start is called before the first frame update

	[Header("服のメッシュパターン")]
	[SerializeField]
	ClothesTyep myClothesTyep;

	public ClothesTyep MyClothesTyep
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

	[Header("着替える服のテクスチャ")]
	[SerializeField]
	private Texture clothesTexture;


	private bool isVRoid = false;

	public bool IsVRoid {
		get { return isVRoid; }
		set
		{
			isVRoid = value;
		}
	}

	private bool isBodyHit = false;

	private ClothesTyep bodyClothesType;

	//多分いつか使うので
	private BodyType myBodyType;

	void Start()
    {

		material = this.GetComponent<Renderer>().material;

		//自分のテクスチャをメタデータから引っ張ってくる

		material.SetTexture("_MainTex", clothesTexture);
	}


	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Z))
		{
			ChangeCloth();
		}
	}

	//ヒット判定
	void OnTriggerStay(Collider other)
	{
		
		if (isBodyHit)
		{
			return;
		}
		//レイヤーでフィルタかけたほうが安全です
		{
			isBodyHit = true;

			var Player = other.gameObject;
			if (Player != null)
			{
				if (Player.GetComponent<BackClothes>())
				{
					var backClothes = Player.GetComponent<BackClothes>();
					Body = backClothes.Body;
					isVRoid = backClothes.IsVRoid;
					bodyClothesType = backClothes.IsClothesTyep;
				}

			}

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


	public void ChangeCloth()
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
		if(bodyClothesType != myClothesTyep)
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
			
			if (material.name.IndexOf("_CLOTH", StringComparison.Ordinal) >= 0)
			{
				if(myClothesTyep == ClothesTyep.Onepice
					|| myClothesTyep == ClothesTyep.Onepicehalf
					|| myClothesTyep == ClothesTyep.Onepiceshort
					|| myClothesTyep == ClothesTyep.OnepicePencil)
				{
					//Onepice型
					if (material.name.IndexOf("_Onepice", StringComparison.Ordinal) >= 0)
					{
						//ワンピース型
						
						material.mainTexture = clothesTexture;
	
						
						material.SetTexture("_ShadeTexture", clothesTexture);
						

					}
					
				}
				else
				{
					if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0 && 
						(myClothesTyep == ClothesTyep.School || myClothesTyep == ClothesTyep.SchoolLong))
					{
						//制服
						material.mainTexture = clothesTexture;
					
						
						material.SetTexture("_ShadeTexture", clothesTexture);
						
					}
		

					else if (material.name.IndexOf("_003", StringComparison.Ordinal) >= 0 && 
						(myClothesTyep == ClothesTyep.SchoolpantsShort || myClothesTyep == ClothesTyep.SchoolpantsShort))
					{

						//制服ズボン系
						material.mainTexture = clothesTexture;
						
						material.SetTexture("_ShadeTexture", clothesTexture);
						
					}
					else if (material.name.IndexOf("_004", StringComparison.Ordinal) >= 0 && myClothesTyep == ClothesTyep.MiniTshirt)
					{
						//ミニTシャツ
						material.mainTexture = clothesTexture;
						
						material.SetTexture("_ShadeTexture", clothesTexture);
						
					}
					
					else if (material.name.IndexOf("_005", StringComparison.Ordinal) >= 0 && myClothesTyep == ClothesTyep.Tshirt)
					{
						//Tshirt
						material.mainTexture = clothesTexture;
						
						material.SetTexture("_ShadeTexture", clothesTexture);
						
					}
					else if (material.name.IndexOf("_006", StringComparison.Ordinal) >= 0 && myClothesTyep == ClothesTyep.Parker)
					{
						//パーカー
						
						material.mainTexture = clothesTexture;
						
						material.SetTexture("_ShadeTexture", clothesTexture);
						
					}
					else if (material.name.IndexOf("_008", StringComparison.Ordinal) >= 0 &&
						(myClothesTyep == ClothesTyep.Longcoat || myClothesTyep == ClothesTyep.LongcoatShirt || myClothesTyep == ClothesTyep.LongcoatHi))
					{
						//ロングコート
						material.mainTexture = clothesTexture;
						
						material.SetTexture("_ShadeTexture", clothesTexture);
					
					}
				}
				
			}
		}
	}



}
