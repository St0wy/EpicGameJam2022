using UnityEngine;
using UnityEngine.Serialization;

namespace EpicGameJam
{
	public class CameraFollow : MonoBehaviour
	{
		[FormerlySerializedAs("player")] [SerializeField]
		private Transform _target;
		[SerializeField] private float _smoothing;
		[SerializeField] private Vector3 _offset;

		private void Update()
		{
			if (_target == null) return;
			Vector3 newPosition = Vector3.Lerp(transform.position, _target.transform.position + _offset, _smoothing);
			transform.position = newPosition;
		}
	}
}