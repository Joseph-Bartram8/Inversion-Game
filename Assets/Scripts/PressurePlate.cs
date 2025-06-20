using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    public Transform gateToOpen;
    public float gateOpenDelay = 3f;
    public float plateSinkAmount = 0.3f;
    public float plateSinkSpeed = 2f;
    public float gateMoveAmount = 7f;
    public float gateMoveSpeed = 2f;

    private Vector3 originalPlatePos;
    private Vector3 sunkPlatePos;

    private Vector3 originalGatePos;
    private Vector3 raisedGatePos;

    private bool cubeOnPlate = false;
    private float timer = 0f;
    private Coroutine gateMoveCoroutine;

    private void Start()
    {
        originalPlatePos = transform.position;
        sunkPlatePos = originalPlatePos - new Vector3(0, plateSinkAmount, 0);

        if (gateToOpen != null)
        {
            originalGatePos = gateToOpen.position;
            raisedGatePos = originalGatePos + new Vector3(0, gateMoveAmount, 0);
        }
    }

    private void Update()
    {
        // Animate plate position
        if (cubeOnPlate)
        {
            transform.position = Vector3.Lerp(transform.position, sunkPlatePos, Time.deltaTime * plateSinkSpeed);
            timer += Time.deltaTime;

            // Trigger gate opening after delay
            if (timer >= gateOpenDelay && gateMoveCoroutine == null)
            {
                gateMoveCoroutine = StartCoroutine(MoveGate(gateToOpen.position, raisedGatePos));
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPlatePos, Time.deltaTime * plateSinkSpeed);
            timer = 0f;

            // If gate is open and cube left, close it
            if (gateToOpen != null && gateToOpen.position != originalGatePos && gateMoveCoroutine == null)
            {
                gateMoveCoroutine = StartCoroutine(MoveGate(gateToOpen.position, originalGatePos));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzleCube"))
        {
            cubeOnPlate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PuzzleCube"))
        {
            cubeOnPlate = false;
        }
    }

    private IEnumerator MoveGate(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = Mathf.Abs(to.y - from.y) / gateMoveSpeed;

        while (elapsed < duration)
        {
            gateToOpen.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        gateToOpen.position = to;
        gateMoveCoroutine = null;
    }
}
