using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VRM
{
    public class VRMSizeFixer : MonoBehaviour
    {
        public float minSize;//調整後の最小サイズ
        public float maxSize;//調整後の最大サイズ
        public GameObject VRMModel;//対象のモデル
        private Transform transSelf;
        private Animator anime;
        private Transform transHead;
        private Transform transFoot;
        private float defaultHeight;
        // Use this for initialization
        void Start()
        {

        }


        private void SetChangeBody()
        {
            anime = VRMModel.GetComponent<Animator>();
            transSelf = VRMModel.GetComponent<Transform>();
            transHead = anime.GetBoneTransform(HumanBodyBones.Head);
            transFoot = anime.GetBoneTransform(HumanBodyBones.RightFoot);
            defaultHeight = transHead.position.y - transFoot.position.y;
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
        }


        private void ScaleSpringBone(float _offset)
        {
            var colliders = this.VRMModel.GetComponentsInChildren<VRMSpringBoneColliderGroup>();

            foreach (var c in colliders)
            {

                var collider = c.Colliders;
                foreach(var scaleCollider in collider)
                {
                    scaleCollider.Radius *= _offset;
                }

            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}