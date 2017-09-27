using UnityEngine;

public class ExtensionNode : MonoBehaviour
{
	private float maxDistance = 20;

	private void OnDrawGizmos()
	{
		Debug.DrawRay(transform.position, transform.forward);
	}

	public bool CanExtend(float sizeObject)
	{
		RaycastHit hit;
		if (!Physics.Raycast(transform.position, transform.forward, out hit, maxDistance)) return true;
		if (Physics.CheckSphere(transform.position + transform.forward, 10)) return false;
		return !(hit.distance < sizeObject);
	}
}
