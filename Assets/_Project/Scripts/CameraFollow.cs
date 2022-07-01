using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace EpicGameJam
{
	public class CameraFollow : MonoBehaviour
	{
		[FormerlySerializedAs("player")] [SerializeField]
		private Transform target;
		[SerializeField] private float smoothing;
		[SerializeField] private Vector3 offset;

		private void Update()
		{
			if (target == null) return;

			Vector3 newPosition = Vector3.Lerp(transform.position, target.transform.position + offset, smoothing);
			transform.position = newPosition;
		}
	}
}