using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRM
{
    public class ChangeMyBody : MonoBehaviour
    {
        private GameObject VRMModel;//自分
        private Transform transSelf;
        private Animator anime;
        private Transform transHead;
        private Transform transFoot;
        private float defaultHeight;

        public float DefaultHeight
        {
            get { return defaultHeight; }
        }

        //着せ替えしてる対象のBody
        private GameObject copyBody;

        public GameObject CopyBody
        {
            set { copyBody = value; }
           
        }


        //着せ替えしてる対象の制御クラス
        public ChangeBaseBody playerChangeBaseBody;
        public ChangeBaseBody PlayerChangeBaseBody
        {
            set { PlayerChangeBaseBody = value; }
        }

        //自分のBodyメッシュ
        private GameObject myBody;

        //着替えているかどうか
        private bool isChanged = false;

        public bool IsChanged
        {
            get { return isChanged; }
        }

        void Start()
        {
            Transform body = this.transform.Find("Body")?.transform;
            myBody = body.gameObject;
            if (myBody == null)
            {
                Debug.LogError("NotBody");
            }

            VRMModel = this.gameObject;
            anime = VRMModel.GetComponent<Animator>();
            transSelf = VRMModel.GetComponent<Transform>();
            transHead = anime.GetBoneTransform(HumanBodyBones.Head);
            transFoot = anime.GetBoneTransform(HumanBodyBones.RightFoot);
            //身長を
            defaultHeight = transHead.position.y - transFoot.position.y;
            Debug.Log(defaultHeight);
        }


        private void ReBody()
        {
            Destroy(copyBody);
            copyBody = null;
            playerChangeBaseBody = null;
            myBody?.SetActive(true);
            isChanged = false;
        }

        public void BodyNoActive()
        {
            isChanged = true;
            myBody?.SetActive(false);
        }


        // Update is called once per frame
        void Update()
        {
            //ボディを戻す処理
            if (Input.GetKeyDown(KeyCode.X))
            {
                ReBody();
            }

        }
    }
}