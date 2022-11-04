using System.Collections.Generic;
using UnityEngine;

public class PlayerInAreaActivator : MonoBehaviour
{
    public List<Collider> colliders;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //Player left area
        {
            foreach (var c in colliders)
            {
                c.gameObject.SetActive(true);
            }
        }

        colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //Player left area
        {
            colliders.Remove(other);
            foreach (var c in colliders)
            {
                c.gameObject.SetActive(false);
            }
        }
        colliders.Remove(other);
    }
}
