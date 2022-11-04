using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player;
    public float Acceleration = 10;
    public float MaxSpeed = 100;
    public ForceMode forceMode;

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

            if (rigidbody == null)
            {
                Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

                if (Input.GetKey(KeyCode.W) && rigidbody2D.velocity.y < MaxSpeed)
                    rigidbody2D.AddForce(new Vector3(0, Acceleration, 0));

                if (Input.GetKey(KeyCode.S) && Mathf.Abs(rigidbody2D.velocity.y) < MaxSpeed)
                    rigidbody2D.AddForce(new Vector3(0, -Acceleration, 0));

                if (Input.GetKey(KeyCode.D) && rigidbody2D.velocity.x < MaxSpeed)
                    rigidbody2D.AddForce(new Vector3(Acceleration, 0, 0));

                if (Input.GetKey(KeyCode.A) && Mathf.Abs(rigidbody2D.velocity.x) < MaxSpeed)
                    rigidbody2D.AddForce(new Vector3(-Acceleration, 0, 0));
            }
            else
            {
                if (Input.GetKey(KeyCode.W) && rigidbody.velocity.z < MaxSpeed)
                    rigidbody.AddForce(new Vector3(0, 0, Acceleration), forceMode);

                if (Input.GetKey(KeyCode.S) && Mathf.Abs(rigidbody.velocity.z) < MaxSpeed)
                    rigidbody.AddForce(new Vector3(0, 0, -Acceleration), forceMode);

                if (Input.GetKey(KeyCode.D) && rigidbody.velocity.x < MaxSpeed)
                    rigidbody.AddForce(new Vector3(Acceleration, 0, 0), forceMode);

                if (Input.GetKey(KeyCode.A) && Mathf.Abs(rigidbody.velocity.x) < MaxSpeed)
                    rigidbody.AddForce(new Vector3(-Acceleration, 0, 0), forceMode);
            }




        }

        if (transform.position.y <= RespawnIfAtHeight)
            transform.position = RespawnLocation.position;

    }
}
