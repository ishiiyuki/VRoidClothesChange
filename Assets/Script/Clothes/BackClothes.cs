using System;
using UniGLTF;
using UnityEngine;


using static Clothes_Params.ClothesParam;

public class BackClothes : MonoBehaviour
{
	// Start is called before the first frame update

	private Transform body;

	public Transform Body
	{
		get { return body; }
		set { body = value; }

	}

	private Texture clothesTex;

	private Texture bottomsTex;
	private Texture shoesTex;
	private Texture skinTex;


	private bool isVRoid = false;

	public bool IsVRoid
	{
		get { return isVRoid; }
		set
		{
			isVRoid = value;
		}
	}

	private ClothesTyep myClothesTyep;

	public ClothesTyep IsClothesTyep
	{
		get { return myClothesTyep; }
	}

	private BottomType myClothesBottomTyep;

	public BottomType IsClothesBottomTyep
	{
		get { return myClothesBottomTyep; }
	}

	private ShoesType myShoesType;

	public ShoesType IsShoesType
	{
		get { return myShoesType; }
	}

	private BodyType myBodyType;

	public BodyType IsBodyTypep
	{
		get { return myBodyType; }
	}
	private AccessoryNeck myAccessoryNeck;

	public AccessoryNeck IsAccessoryNeck
	{
		get { return myAccessoryNeck; }
	}


	void Start()
    {
		/*
		//上半身
		this.UpdateAsObservable()
			.Where(_ => Input.GetKey(KeyCode.X))
			.ThrottleFirst(TimeSpan.FromSeconds(2))
			.Subscribe(_ => ReClothes());
		//下半身
		this.UpdateAsObservable()
			.Where(_ => Input.GetKey(KeyCode.C))
			.ThrottleFirst(TimeSpan.FromSeconds(2))
			.Subscribe(_ => ReClothesBottom());
		*/
	}

	public void Init()
	{
		if(!body)
		{
			return;
		}
		//今のテクスチャを保持しながらタイプチェック

		Material[] sharedMaterials = body.GetSharedMaterials();

		foreach (Material material in sharedMaterials)
		{
			//Debug.Log(material.name);


			if (material.name.IndexOf("_CLOTH", StringComparison.Ordinal) >= 0)
			{

				ClothesTypeCheck( material);

			}//服を来ていない場合にも対応する
			else
			{

				
				if (material.name.IndexOf("_SKIN", StringComparison.Ordinal) >= 0)
				{
					if (material.name.IndexOf("M0", StringComparison.Ordinal) >= 0)
					{
						myBodyType = BodyType.Man;
					}
					else
					{
						myBodyType = BodyType.Woman;
					}
						
					//スキン情報があればVRoidにしておこう
					isVRoid = true;
					continue;
					
				}
				else if (material.name.IndexOf("AccessoryNeckk", StringComparison.Ordinal) >= 0)
				{
					if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0)
					{
						myAccessoryNeck = AccessoryNeck.Tie;
					}

				}
				else if (material.name.IndexOf("Accessory", StringComparison.Ordinal) >= 0)
				{
					if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0 )
					{
						//
						myAccessoryNeck = AccessoryNeck.Ribbon;
					}


				}

			}
		}
	}

	void ClothesTypeCheck( Material material)
	{
		//靴の場合
		if (material.name.IndexOf("_Shoes", StringComparison.Ordinal) >= 0)
		{

			if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0)
			{

				shoesTex = material.mainTexture;

				myShoesType = ShoesType.Loafers;
			}
			else if (material.name.IndexOf("_002", StringComparison.Ordinal) >= 0)
			{

				shoesTex = material.mainTexture;

				myShoesType = ShoesType.Onepice;
			}
			else if (material.name.IndexOf("_003", StringComparison.Ordinal) >= 0)
			{

				shoesTex = material.mainTexture;

				myShoesType = ShoesType.LoafersPants;
			}
			else if (material.name.IndexOf("_004", StringComparison.Ordinal) >= 0)
			{

				shoesTex = material.mainTexture;

				myShoesType = ShoesType.Pumps;
			}
			else if (material.name.IndexOf("_005", StringComparison.Ordinal) >= 0)
			{

				shoesTex = material.mainTexture;

				myShoesType = ShoesType.Sneakers;
			}
			else if (material.name.IndexOf("_006", StringComparison.Ordinal) >= 0)
			{

				shoesTex = material.mainTexture;

				myShoesType = ShoesType.B_Shoes;
			}
			else if (material.name.IndexOf("_007", StringComparison.Ordinal) >= 0)
			{

				shoesTex = material.mainTexture;

				myShoesType = ShoesType.Hi_Cut;
			}
		}
		//Onepice型
		if (material.name.IndexOf("_Onepice", StringComparison.Ordinal) >= 0)
		{
			//ワンピース型
			

			if (material.name.IndexOf("_01", StringComparison.Ordinal) >= 0)
			{
				
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.Onepice;
			}
			else if (material.name.IndexOf("_02", StringComparison.Ordinal) >= 0)
			{

				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.Onepicehalf;
			}
			else if (material.name.IndexOf("_03", StringComparison.Ordinal) >= 0)
			{

				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.Onepiceshort;
			}
			else if (material.name.IndexOf("_04", StringComparison.Ordinal) >= 0)
			{

				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.OnepicePencil;
			}
		}
		else
		{

			//上
			if (material.name.IndexOf("_Tops", StringComparison.Ordinal) >= 0)
			{

				ClothesTypeCheckTop(material);

			}//下
			else if (material.name.IndexOf("_Bottoms", StringComparison.Ordinal) >= 0)
			{

				ClothesTypeCheckBottom(material);

			}
		}
	}

	void ClothesTypeCheckTop(Material material)
	{
		if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0)
		{
			if (material.name.IndexOf("_01", StringComparison.Ordinal) >= 0)
			{
				//制服
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.School;
			}
			else if (material.name.IndexOf("_02", StringComparison.Ordinal) >= 0)
			{
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.SchoolLong;
			}

		}
		else if (material.name.IndexOf("_002", StringComparison.Ordinal) >= 0)
		{
			return;
			//多分ワンピース

		}
		else if (material.name.IndexOf("_003", StringComparison.Ordinal) >= 0)
		{
			if (material.name.IndexOf("_01", StringComparison.Ordinal) >= 0)
			{
				//制服 ズボン
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.SchoolpantsShort;
			}
			else if (material.name.IndexOf("_02", StringComparison.Ordinal) >= 0)
			{
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.SchoolpantsLong;
			}
		}
		else if (material.name.IndexOf("_004", StringComparison.Ordinal) >= 0)
		{
			//ミニTシャツ
			clothesTex = material.mainTexture;

			myClothesTyep = ClothesTyep.MiniTshirt;
		}
		else if (material.name.IndexOf("_005", StringComparison.Ordinal) >= 0)
		{
			//Tシャツ
			clothesTex = material.mainTexture;

			myClothesTyep = ClothesTyep.Tshirt;
		}
		else if (material.name.IndexOf("_006", StringComparison.Ordinal) >= 0)
		{
			//パーカー

			clothesTex = material.mainTexture;

			myClothesTyep = ClothesTyep.Parker;
		}
		else if (material.name.IndexOf("_008", StringComparison.Ordinal) >= 0)
		{
			//ロングコート

			if (material.name.IndexOf("_01", StringComparison.Ordinal) >= 0)
			{
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.Longcoat;
			}
			else if (material.name.IndexOf("_02", StringComparison.Ordinal) >= 0)
			{
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.LongcoatShirt;
			}
			else if (material.name.IndexOf("_03", StringComparison.Ordinal) >= 0)
			{
				clothesTex = material.mainTexture;

				myClothesTyep = ClothesTyep.LongcoatHi;
			}
		}
	}

	void ClothesTypeCheckBottom( Material material)
	{
		if (material.name.IndexOf("_001", StringComparison.Ordinal) >= 0)
		{
			//制服型
			bottomsTex = material.mainTexture;
			myClothesBottomTyep = BottomType.Skirt;
		}
		else if (material.name.IndexOf("_002", StringComparison.Ordinal) >= 0)
		{
			return;
			
		}
		else if (material.name.IndexOf("_003", StringComparison.Ordinal) >= 0)
		{
			//ズボン
		
			bottomsTex = material.mainTexture;
			myClothesBottomTyep = BottomType.Pants;
		}
		else if (material.name.IndexOf("_004", StringComparison.Ordinal) >= 0)
		{
			//ペンシルスカート
		
			bottomsTex = material.mainTexture;
			myClothesBottomTyep = BottomType.PencilSkirt;
		}
		else if (material.name.IndexOf("_008", StringComparison.Ordinal) >= 0)
		{
			//ズボンロングコート
			bottomsTex = material.mainTexture;
			myClothesBottomTyep = BottomType.Pants_Longcoat;
		}
	}


	/// <summary>
	/// 以下戻す処理
	/// </summary>
	void ReClothes()
	{
		if (!isVRoid)
		{
			return;
		}
		if (!body)
		{
			return;
		}


		if(myClothesTyep == ClothesTyep.Onepice)
		{
			ReClothesOnepice();
		}
		else 
		{
			ReClothesTop();
		}
	}

	void ReClothesOnepice()
	{

		Material[] sharedMaterials = body.GetSharedMaterials();
		foreach (Material material in sharedMaterials)
		{
			Debug.Log(material.name);
			if (material.name.IndexOf("_CLOTH", StringComparison.Ordinal) >= 0)
			{
				if (material.name.IndexOf("_Onepice", StringComparison.Ordinal) >= 0)
				{
					Debug.Log("マテリアルの名前:" + material.shader.name);
					material.mainTexture = clothesTex;
					if (material.shader.name.Contains("VRM/MToon"))
					{
						material.SetTexture("_ShadeTexture", clothesTex);
					}
				}
				
			}
		}
	}
	void ReClothesTop()
	{

		Material[] sharedMaterials = body.GetSharedMaterials();
		foreach (Material material in sharedMaterials)
		{
			Debug.Log(material.name);
			if (material.name.IndexOf("_CLOTH", StringComparison.Ordinal) >= 0)
			{
				if (material.name.IndexOf("_Tops", StringComparison.Ordinal) >= 0)
				{
					Debug.Log("マテリアルの名前:" + material.shader.name);
					material.mainTexture = clothesTex;
					if (material.shader.name.Contains("VRM/MToon"))
					{
						material.SetTexture("_ShadeTexture", clothesTex);
					}
				}

			}
		}
	}

	void ReClothesBottom()
	{

		Material[] sharedMaterials = body.GetSharedMaterials();
		foreach (Material material in sharedMaterials)
		{
			Debug.Log(material.name);
			if (material.name.IndexOf("_CLOTH", StringComparison.Ordinal) >= 0)
			{
				if (material.name.IndexOf("_Shoes", StringComparison.Ordinal) >= 0)
				{
					continue;
				}
				if (material.name.IndexOf("_Bottoms", StringComparison.Ordinal) >= 0)
				{
					Debug.Log("マテリアルの名前:" + material.shader.name);
					material.mainTexture = bottomsTex;
					if (material.shader.name.Contains("VRM/MToon"))
					{
						material.SetTexture("_ShadeTexture", clothesTex);
					}
				}
			}
		}
	}
}
