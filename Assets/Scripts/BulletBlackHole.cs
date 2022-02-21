using UnityEngine;

public class BulletBlackHole : MonoBehaviour
{
    private float pullForce = 250f;
    private void OnTriggerStay(Collider targetObject)
    {
        if (targetObject.GetComponent<ObjectPulled>() != null)
        {
            Rigidbody targetRigidBody = targetObject.GetComponent<Rigidbody>();
            Vector3 pullDirection = gameObject.transform.position - targetObject.transform.position;
            targetRigidBody.AddForce(pullDirection.normalized * pullForce, ForceMode.Force);
        }
    }
}
