using UnityEngine;
using UnityEngine.AI;

public class PlayerTracker : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public bool track = true;
    public float range = 100;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //var raycast = Physics.Raycast(transform.position + new Vector3(0, 1, 0), target.transform.root.position, out RaycastHit hit, 10000);
        //Debug.Log(raycast);
        //Debug.DrawRay(transform.position, target.position, new Color(1.0f, 0, 0));
        agent.isStopped = Vector3.Distance(transform.position, target.position) > range;

        if (track && !agent.isStopped)
        {
            //if (hit.collider.transform.root.tag == "Player")
            //{
            agent.destination = target.position;
            //}
        }

    }
}
