using System;
using System.Collections;

using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;

using static Clothes_Params.ClothesParam;

/// <summary>
/// 下半身服用の着せ替え機能
/// </summary>
public class ChangeClothesAccessoryNeck : MonoBehaviour
{
	// Start is called before the first frame update

	[Header("アクセサリのメッシュパターン")]
	[SerializeField]
	AccessoryNeck accessoryNeckType;

	public AccessoryNeck MyAccessoryNeckType
	{
		get { return accessoryNeckType; }
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
	private Texture clothesNeckAcse;

	private bool isVRoid = false;

	public bool IsVRoid {
		get { return isVRoid; }
		set
		{
			isVRoid = value;
		}
	}

	private bool isBodyHit = false;

	AccessoryNeck bodyAcceeoryType;

	void Start()
    {

		material = this.GetComponent<Renderer>().material;

		material.SetTexture("_MainTex", clothesNeckAcse);


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
			if(Player != null)
			{
				if(Player.GetComponent<BackClothes>())
				{
					var backClothes = Player.GetComponent<BackClothes>();
					Body = backClothes.Body;
					isVRoid = backClothes.IsVRoid;
					bodyAcceeoryType = backClothes.IsAccessoryNeck;
				}
				
			}
			



		}
	}

	void OnTriggerExit(Collider other)
	{
		
		
		isBodyHit = false;
		Body = null;
		
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
		if(bodyAcceeoryType != accessoryNeckType)
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
			if (material.name.IndexOf("AccessoryNeckk", StringComparison.Ordinal) >= 0)
			{
				if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0 &&
					(bodyAcceeoryType == AccessoryNeck.Tie))
				{
					
					material.mainTexture = clothesNeckAcse;
					
					material.SetTexture("_ShadeTexture", clothesNeckAcse);
					
				}


			}
			else if (material.name.IndexOf("Accessory", StringComparison.Ordinal) >= 0)
			{
				if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0 &&
					(bodyAcceeoryType == AccessoryNeck.Ribbon))
				{
					
					material.mainTexture = clothesNeckAcse;
					
					material.SetTexture("_ShadeTexture", clothesNeckAcse);
					
				}

			}
		}
	}



}
