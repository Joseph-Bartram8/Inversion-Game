using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushableCube : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Mass Settings")]
    public float lightWorldMass = 1000f;
    public float darkWorldMass = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Subscribe to world changes
        if (WorldStateManager.Instance != null)
        {
            WorldStateManager.Instance.OnWorldStateChanged += HandleWorldChange;
            HandleWorldChange(WorldStateManager.Instance.CurrentState); // Set initial mass
        }
        else
        {
            Debug.LogWarning("WorldStateManager.Instance is null in PushableCube.");
        }
    }

    private void HandleWorldChange(WorldState state)
    {
        if (rb == null) return;

        if (state == WorldState.Light)
        {
            rb.mass = lightWorldMass;
        }
        else
        {
            rb.mass = darkWorldMass;
        }

        Debug.Log($"[PushableCube] World changed to {state}. New mass: {rb.mass}");
    }

    void OnDestroy()
    {
        if (WorldStateManager.Instance != null)
        {
            WorldStateManager.Instance.OnWorldStateChanged -= HandleWorldChange;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Cube collided with: " + collision.gameObject.name);
    }
}
