using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    private void Start()
    {
        // Save the starting position as the respawn point
        respawnPoint = transform.position;
    }

    public void Respawn()
    {
        // Reset position and optionally reset velocity
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = respawnPoint;
            controller.enabled = true;
        }
        else
        {
            transform.position = respawnPoint;
        }

        Debug.Log("Player respawned.");
    }
}
