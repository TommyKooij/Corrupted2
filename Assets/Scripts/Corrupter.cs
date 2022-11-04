using UnityEngine;

public class Corrupter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        ICorruptible corruptible = other.gameObject.GetComponent<ICorruptible>();

        if (corruptible == null)
            return;

        corruptible.Corrupt();
    }
}
