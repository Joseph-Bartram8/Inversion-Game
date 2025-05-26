using UnityEngine;

public class WorldAwareObject : MonoBehaviour
{
    public WorldState visibleIn = WorldState.Light;

    void Start()
    {
        WorldStateManager.Instance.OnWorldStateChanged += HandleWorldChange;
        HandleWorldChange(WorldStateManager.Instance.CurrentState); // Initial state
    }

    private void HandleWorldChange(WorldState state)
    {
        gameObject.SetActive(state == visibleIn);
    }

    private void OnDestroy()
    {
        if (WorldStateManager.Instance != null)
        {
            WorldStateManager.Instance.OnWorldStateChanged -= HandleWorldChange;
        }
    }
}
