using UnityEngine;

public class PlatformLinear : MonoBehaviour
{
    public Vector3 Move;

    private bool goingBack = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goingBack)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (Move.z / 1));
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Move.z / 1));
        if (transform.position.z >= Move.z)
            goingBack = true;
    }
}
