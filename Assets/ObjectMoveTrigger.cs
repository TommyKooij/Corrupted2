using UnityEngine;

public class ObjectMoveTrigger : MonoBehaviour, ITriggerable
{
    bool isTriggered = false;
    public Vector3 moveTo;

    private Vector3 originalPosition;

    private void Start() => originalPosition = transform.position;
    public void Trigger()
    {
        if (isTriggered)
            transform.position = moveTo;
        else
            transform.position = originalPosition;

        isTriggered = !isTriggered;
    }
}
