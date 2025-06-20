using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;


public class FinishZone : MonoBehaviour
{
    public GameObject completePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            completePanel.SetActive(true);

            // Disable movement + input
            var controller = other.GetComponent<ThirdPersonController>();
            var input = other.GetComponent<PlayerInput>();

            if (controller != null) controller.enabled = false;
            if (input != null) input.enabled = false;

            // Pause game and show mouse
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
