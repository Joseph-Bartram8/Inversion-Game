using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldStateManager : MonoBehaviour
{
    public static WorldStateManager Instance { get; private set; }

    public WorldState CurrentState { get; private set; } = WorldState.Light;

    public event Action<WorldState> OnWorldStateChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleWorld();
        }
    }

    public void ToggleWorld()
    {
        CurrentState = (CurrentState == WorldState.Light) ? WorldState.Dark : WorldState.Light;
        Debug.Log("World state changed to: " + CurrentState);
        OnWorldStateChanged?.Invoke(CurrentState);
    }
}
