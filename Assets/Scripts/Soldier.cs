using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public GameObject Destination;
    int time = 0;
    bool isMoving = true;
    Vector3 location;
    Vector3 oldlocation;
    public string destination;
    GameObject Main_Camera;
    bool reached = false;
    void Start()
    {
        newDestination();
        Main_Camera = GameObject.Find("Main Camera");
        //gameObject.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        float Desw = Destination.GetComponent<MeshFilter>().mesh.bounds.size.x;
        float Desh = Destination.GetComponent<MeshFilter>().mesh.bounds.size.z;
        if (!reached && Vector3.Distance(Destination.transform.position, transform.position) < Mathf.Sqrt(Desw * Desw + Desh * Desh) * 4)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Destination.transform.position - transform.position, out hit, Mathf.Infinity) && hit.collider.gameObject.name == destination)
            {
                navMeshAgent.destination = hit.point;

                reached = true;
                //bir kere yap
            }
            //NavMeshHit hit;
            //if (navMeshAgent.FindClosestEdge(out hit) && hit.Equals(Destination))
            //{
            //    navMeshAgent.SetDestination(hit.position);
            //}




            //if (Vector3.Distance(hit.point, transform.position) + Destination.GetComponent<MeshFilter>().mesh.bounds.size.x/2 < 0.4f)
            //{
            //    navMeshAgent.enabled = false;
            //    reached = true;
            //}


            //NavMeshHit hit;
            //if (NavMesh.SamplePosition(Destination.transform.position, out hit, 1.0f, NavMesh.AllAreas))
            //{
            //    navMeshAgent.destination = hit.position;
            //}
            //NavMeshHit hit;
            //if (navMeshAgent.FindClosestEdge(out hit))
            //{
            //    navMeshAgent.SetDestination(hit.position);
            //}
        }

        //time++;
        //if (time > 500)
        //{
        //    isMoving = !isMoving;
        //    if (isMoving)
        //    {
        //        location = transform.position;
        //    }
        //    else
        //    {

        //        oldlocation = transform.position;
        //        if (Vector3.Distance(location, oldlocation) < 1)
        //        {
        //            navMeshAgent.enabled = false;
        //            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        //        }
        //    }
        //    Debug.Log(navMeshAgent.enabled);
        //}
    }
    void newDestination()
    {
        //navMeshAgent.isStopped = false;


        navMeshAgent.enabled = false;
        navMeshAgent.enabled = true;

        navMeshAgent.destination = Destination.transform.position;


        //navMeshAgent.stoppingDistance = Destination.transform.localScale.x;
        //navMeshAgent.SetDestination(Destination.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == destination)
        {
            navMeshAgent.enabled = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
    }
    void ApplyHitPoints(Vector3 explosionPos, float radius)
    {
        // The distance from the explosion position to the surface of the collider.
        Vector3 closestPoint = Main_Camera.GetComponent<Collider>().ClosestPointOnBounds(explosionPos);
        float distance = Vector3.Distance(closestPoint, explosionPos);

        // The damage should decrease with distance from the explosion.
        float damage = 1.0F - Mathf.Clamp01(distance / radius);
        
    }
}
