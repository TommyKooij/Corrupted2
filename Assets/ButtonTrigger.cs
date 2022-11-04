using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public List<GameObject> ToTrigger;
    public bool TriggerManually = false;
    public float coolDownTimeAfterTrigger = 1f;
    float elapsedTimeAfterLastTrigger = 0;

    private bool firstTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            if (CheckCooldown())
                ToTrigger.ForEach(t => t.GetComponent<ITriggerable>()?.Trigger());
    }

    private void Update()
    {
        elapsedTimeAfterLastTrigger += Time.deltaTime;

        if (TriggerManually)
        {
            ToTrigger.ForEach(t => t.GetComponent<ITriggerable>()?.Trigger());
            TriggerManually = false;
        }
    }

    private bool CheckCooldown()
    {
        if (elapsedTimeAfterLastTrigger >= coolDownTimeAfterTrigger)
        {
            elapsedTimeAfterLastTrigger = 0f;
            return true;
        }

        if (firstTrigger)
        {
            firstTrigger = false;
            return true;
        }

        return false;
    }
}
