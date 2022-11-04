using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    private GameObject player;
    //public float Acceleration = 10;
    //public float MaxSpeed = 100;
    public float Speed = 0.1f;

    public float RespawnIfAtHeight = -10;
    public Transform RespawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKey)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            if (Input.GetKey(KeyCode.W))
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);
            //rigidbody.AddForce(new Vector3(0, 0, Acceleration), forceMode);

            if (Input.GetKey(KeyCode.S))
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);

            if (Input.GetKey(KeyCode.D))
                transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);

            if (Input.GetKey(KeyCode.A))
                transform.position = new Vector3(transform.position.x - Speed, transform.position.y, transform.position.z);
        }

        if (transform.position.y <= RespawnIfAtHeight)
            transform.position = RespawnLocation.position;
    }
}
