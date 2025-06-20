using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float pushStrength = 5f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // Don't push objects without rigidbody or if kinematic
        if (body == null || body.isKinematic) return;

        // Only push horizontally
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.AddForce(pushDir * pushStrength, ForceMode.Force);
    }
}
