using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public float lerpRate = 2.0f;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

        private Vector3 idealPosition;

        private void LateUpdate()
        {
	    idealPosition= target.position + offset;
            transform.position = Vector3.Lerp(transform.position, idealPosition, lerpRate * Time.deltaTime);
        }
    }
}
