using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRM
{
    public class ChangeBaseBody : MonoBehaviour
    {

        public float minSize;//調整後の最小サイズ
        public float maxSize;//調整後の最大サイズ
        private GameObject VRMModel;//自分
        private Transform transSelf;
        private Animator anime;
        private Transform transHead;
        private Transform transFoot;
        private float defaultHeight;

        private bool isBodyHit = false;



        private GameObject playerObject;
        private ChangeMyBody playerBody = null;

        private float playerHeight;
        void Start()
        {
            
        }

        //顔なしのBodyを作る
        private void SetChangeBody()
        {
            GameObject copied = Object.Instantiate(this.gameObject) as GameObject;
            copied.transform.rotation = playerObject.transform.rotation;
            copied.transform.position = playerObject.transform.position;

            SetScaleBody(copied);
        }

        //UniTaskを使う方向で
        private void SetScaleBody(GameObject copyBody)
        {
            VRMModel = copyBody;
            anime = VRMModel.GetComponent<Animator>();
            transSelf = VRMModel.GetComponent<Transform>();
            transHead = anime.GetBoneTransform(HumanBodyBones.Head);
            transFoot = anime.GetBoneTransform(HumanBodyBones.RightFoot);
            maxSize = playerHeight + 0.01f;
            minSize = playerHeight;
            //身長を
            defaultHeight = transHead.position.y - transFoot.position.y;
            Debug.Log(defaultHeight);
            float multiply = 1.0f;
            Debug.Log(defaultHeight);
            if (defaultHeight < minSize)
            {
                multiply = minSize / defaultHeight;
                transSelf.localScale = new Vector3(multiply, multiply, multiply);
            }
            else if (defaultHeight > maxSize)
            {
                multiply = maxSize / defaultHeight;
                transSelf.localScale = new Vector3(multiply, multiply, multiply);

            }

            //スプリングボーンもスケールさせる
            ScaleSpringBone(multiply);

            //顔無し処理へ

            SetNoface(VRMModel);
        }

        private void SetNoface(GameObject copyBody)
        {

            var face = copyBody.transform.Find("Face")?.transform;

            var faceobj = face.gameObject;

            var hair = copyBody.transform.Find("Hair")?.transform;

            var hairobj = hair.gameObject;

            if (face == null)
            {
                Debug.LogError("Not Face");
                return;
            }
            else if(hair == null)
            {
                Debug.LogError("Not Hair");
                return;
            }


            SkinnedMeshRenderer face_meshRenderer = faceobj.GetComponent<SkinnedMeshRenderer>();
            face_meshRenderer.enabled = false;

            SkinnedMeshRenderer hair_meshRenderer = hairobj.GetComponent<SkinnedMeshRenderer>();
            hair_meshRenderer.enabled = false;
            //face.SetActive(false);
            //hair.SetActive(false);


            playerBody.CopyBody = copyBody;
            playerBody.BodyNoActive();


        }

        private void ScaleSpringBone(float _offset)
        {
            var colliders = this.VRMModel.GetComponentsInChildren<VRMSpringBoneColliderGroup>();

            foreach (var c in colliders)
            {

                var collider = c.Colliders;
                foreach (var scaleCollider in collider)
                {
                    scaleCollider.Radius *= _offset;
                }

            }

        }


 


        void OnTriggerStay(Collider other)
        {

            if (isBodyHit)
            {
                return;
            }
            else if(playerBody != null)
            {
                return;
            }
            //レイヤーでフィルタかけたほうが安全です
            {
                

                playerObject = other.gameObject;
                if (playerObject != null)
                {
                    if (playerObject.GetComponent<ChangeMyBody>())
                    {
                        playerBody = playerObject.GetComponent<ChangeMyBody>();
                        if(playerBody.IsChanged)
                        {
                            return;
                        }

                        playerHeight = playerBody.DefaultHeight;

                        playerBody.playerChangeBaseBody = this;
                        isBodyHit = true;


                    }

                }

            }
        }

        void OnTriggerExit(Collider other)
        {
            isBodyHit = false;
            playerBody = null;
        }



        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SetChangeBody();
            }
        }



    }
}