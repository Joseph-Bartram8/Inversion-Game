using UnityEngine;
using System.Collections.Generic;

public class WorldMaterialSwitcher : MonoBehaviour
{
    public Material lightWorldMaterial;
    public Material darkWorldMaterial;

    private List<Renderer> renderers = new List<Renderer>();

    void Start()
    {
        
        renderers.AddRange(GetComponentsInChildren<Renderer>());

        // Register for world state changes
        WorldStateManager.Instance.OnWorldStateChanged += HandleWorldChange;

        // Set initial material
        HandleWorldChange(WorldStateManager.Instance.CurrentState);
    }

    private void HandleWorldChange(WorldState state)
    {
        Material targetMaterial = (state == WorldState.Light) ? lightWorldMaterial : darkWorldMaterial;

        foreach (var rend in renderers)
        {
            rend.material = targetMaterial;
        }
    }

    private void OnDestroy()
    {
        if (WorldStateManager.Instance != null)
        {
            WorldStateManager.Instance.OnWorldStateChanged -= HandleWorldChange;
        }
    }
}
