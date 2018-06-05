using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Take.Scn.Main
{
    /// Heroの動きを管理する人
    [RequireComponent (typeof (BoxCollider2D))]
    public class Controller2D : MonoBehaviour 
    {
        private const float fSkinWidth = 0.015f;
        
        /// データ
        /// @note これはInspectorで制御したい
        public LayerMask collisionMask;
        public CollisionInfo collisions;

        /// -------------------------------------------------------
        void Start() 
        {
            // 初期値
            mHorizontalRayCount = 4;
            mVerticalRayCount = 4;

            // 衝突コライダー設定・計算
            mCollider = GetComponent<BoxCollider2D> ();
            CalculateRaySpacing ();
        }

        /// -------------------------------------------------------
        public void Move(Vector3 aVelocity) {
            UpdateRaycastOrigins ();
            collisions.Reset ();

            if (aVelocity.x != 0) {
                HorizontalCollisions (ref aVelocity);
            }
            if (aVelocity.y != 0) {
                VerticalCollisions (ref aVelocity);
            }

            transform.Translate (aVelocity);
        }

        /// -------------------------------------------------------
        void HorizontalCollisions(ref Vector3 velocity) {
            float directionX = Mathf.Sign (velocity.x);
            float rayLength = Mathf.Abs (velocity.x) + fSkinWidth;

            for (int i = 0; i < mHorizontalRayCount; i ++) {
                Vector2 rayOrigin = (directionX == -1)?mRaycastOrigins.bottomLeft:mRaycastOrigins.bottomRight;
                rayOrigin += Vector2.up * (mHorizontalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

                Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength,Color.red);

                if (hit) {
                    velocity.x = (hit.distance - fSkinWidth) * directionX;
                    rayLength = hit.distance;

                    collisions.left = directionX == -1;
                    collisions.right = directionX == 1;
                }
            }
        }

        /// -------------------------------------------------------
        void VerticalCollisions(ref Vector3 velocity) {
            float directionY = Mathf.Sign (velocity.y);
            float rayLength = Mathf.Abs (velocity.y) + fSkinWidth;

            for (int i = 0; i < mVerticalRayCount; i ++) {
                Vector2 rayOrigin = (directionY == -1) ? mRaycastOrigins.bottomLeft : mRaycastOrigins.topLeft;
                rayOrigin += Vector2.right * (mVerticalRaySpacing * i + velocity.x);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

                Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength,Color.red);

                if (hit) {
                    velocity.y = (hit.distance - fSkinWidth) * directionY;
                    rayLength = hit.distance;

                    collisions.below = directionY == -1;
                    collisions.above = directionY == 1;
                }
            }
        }

        /// -------------------------------------------------------
        void UpdateRaycastOrigins() {
            Bounds bounds = mCollider.bounds;
            bounds.Expand (fSkinWidth * -2);

            mRaycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
            mRaycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
            mRaycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
            mRaycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        }

        /// -------------------------------------------------------
        void CalculateRaySpacing() {
            Bounds bounds = mCollider.bounds;
            bounds.Expand (fSkinWidth * -2);

            mHorizontalRayCount = Mathf.Clamp(mHorizontalRayCount, 2, int.MaxValue);
            mVerticalRayCount = Mathf.Clamp(mVerticalRayCount, 2, int.MaxValue);

            mHorizontalRaySpacing = bounds.size.y / (mHorizontalRayCount - 1);
            mVerticalRaySpacing = bounds.size.x / (mVerticalRayCount - 1);
        }

        /// -------------------------------------------------------
        private struct RaycastOrigins {
            public Vector2 topLeft, topRight;
            public Vector2 bottomLeft, bottomRight;
        }

        public struct CollisionInfo 
        {
            public bool above, below;
            public bool left, right;

            public void Reset() 
            {
                above = below = false;
                left = right = false;
            }
        }


        /// ------------------------------------------------
        /// データ
        public LayerMask mCollisionMask;

        private int mHorizontalRayCount;
        private int mVerticalRayCount;

        private float mHorizontalRaySpacing;
        private float mVerticalRaySpacing;

        private BoxCollider2D mCollider;
        private RaycastOrigins mRaycastOrigins;

    }
}