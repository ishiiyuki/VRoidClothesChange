using System;
using UniGLTF;
using UnityEngine;

using static Clothes_Params.ClothesParam;
public class MaterialChange10 : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform body;

    public Transform Body
    {
        get { return body; }
        set { body = value; }

    }


	private Texture mainTexture;
	private Texture2D subTexture;



	[SerializeField]
	private Texture2D addTexture2D;

	private Texture sTexture;


    void Start()
    {

		//Body持ってるか？
		Transform body = this.transform.Find("Body")?.transform;
        if (body != null)
        {
            Body = body;
            
        }
    }

	public void Init()
	{
		if (!body)
		{
			return;
		}
		//今のテクスチャを保持しながらタイプチェック

		Material[] sharedMaterials = body.GetSharedMaterials();

		foreach (Material material in sharedMaterials)
		{
			//服

			if (material.name.IndexOf("_CLOTH", StringComparison.Ordinal) >= 0)
			{
				mainTexture = material.mainTexture;
			
				subTexture = (Texture2D)mainTexture;


			}//服を来ていない場合にも対応する
			else
			{
			

			}
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
