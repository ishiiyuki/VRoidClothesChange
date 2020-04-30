using System;
using System.Collections;
using UniGLTF;
using UnityEngine;

using UnityEngine.Networking;
using static Clothes_Params.ClothesParam;

/// <summary>
/// 下半身服用の着せ替え機能
/// </summary>
public class ChangeClothesShoes : MonoBehaviour
{
	// Start is called before the first frame update

	[Header("靴のメッシュパターン")]
	[SerializeField]
	ShoesType shoesType;

	public ShoesType MyShoesType 
	{
		get { return shoesType; }
	}


	private Transform body;

	public Transform Body
	{
		get { return body; }
		set { body = value; }

	}




	private Material material;

	[Header("Texture")]
	[SerializeField]
	private Texture clothesShoes;

	private bool isVRoid = false;

	public bool IsVRoid {
		get { return isVRoid; }
		set
		{
			isVRoid = value;
		}
	}

	private bool isBodyHit = false;

	ShoesType bodyShoesType;

	void Start()
    {

		material = this.GetComponent<Renderer>().material;
		material.SetTexture("_MainTex", clothesShoes);


	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			ChangeCloth();
		}
	}

	//ヒット判定
	void OnTriggerStay(Collider other)
	{

		if(isBodyHit)
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
					bodyShoesType = backClothes.IsShoesType;
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
		if(bodyShoesType != shoesType)
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
			
			if (material.name.IndexOf("_Shoes", StringComparison.Ordinal) >= 0)
			{
				if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0 &&
					(bodyShoesType == ShoesType.Loafers))
				{
					//ローファー
					material.mainTexture = clothesShoes;
					
					material.SetTexture("_ShadeTexture", clothesShoes);
					
				}
				else if (material.name.IndexOf("_002", StringComparison.Ordinal) >= 0 &&
					(bodyShoesType == ShoesType.Onepice))
				{

					//ワンピース
					material.mainTexture = clothesShoes;
					
					material.SetTexture("_ShadeTexture", clothesShoes);
					
				}
				else if (material.name.IndexOf("_003", StringComparison.Ordinal) >= 0 &&
					(bodyShoesType == ShoesType.LoafersPants))
				{
					//ローファーズボン系
					material.mainTexture = clothesShoes;
					
					material.SetTexture("_ShadeTexture", clothesShoes);
					
				}

				else if (material.name.IndexOf("_004", StringComparison.Ordinal) >= 0 &&
					(bodyShoesType == ShoesType.Pumps))
				{
					//パンプス
					material.mainTexture = clothesShoes;
					
					material.SetTexture("_ShadeTexture", clothesShoes);
					
				}
				else if (material.name.IndexOf("_005", StringComparison.Ordinal) >= 0 &&
					(bodyShoesType == ShoesType.Sneakers))
				{
					//スニーカー
					material.mainTexture = clothesShoes;
					
					material.SetTexture("_ShadeTexture", clothesShoes);
					
				}
				else if (material.name.IndexOf("_006", StringComparison.Ordinal) >= 0 &&
					(bodyShoesType == ShoesType.B_Shoes))
				{
					//バッシュ
					material.mainTexture = clothesShoes;
					
					material.SetTexture("_ShadeTexture", clothesShoes);
					
				}
				else if (material.name.IndexOf("_007", StringComparison.Ordinal) >= 0 &&
					(bodyShoesType == ShoesType.Hi_Cut))
				{
					//ハイカット
					material.mainTexture = clothesShoes;
					
					material.SetTexture("_ShadeTexture", clothesShoes);
					
				}


			}
		}
	}



}
