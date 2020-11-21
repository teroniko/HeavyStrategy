using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    GameObject Arrow;
    void Start()
    {
        Arrow = GameObject.Find("Main Camera").GetComponent<Main_Camera>().Arrow;
        //Debug.Log("j"+GetComponent<Soldier>().Destination.transform.position);
        //ThrowBallAtTargetLocation(GetComponent<Soldier>().Destination.transform.position + new Vector3(0, 15, 0), 1);
    }
    //doğru pozisyona atmayı kendin bul
    public void ThrowBallAtTargetLocation(Vector3 targetLocation, float initialVelocity)
    {
        Vector3 direction = (targetLocation - transform.position).normalized;
        float distance = Vector3.Distance(targetLocation, transform.position);

        float firingElevationAngle = FiringElevationAngle(Physics.gravity.magnitude, distance, initialVelocity);
        Vector3 elevation = Quaternion.AngleAxis(firingElevationAngle, transform.right) * transform.up;
        float directionAngle = AngleBetweenAboutAxis(transform.forward, direction, transform.up);
        Vector3 velocity = Quaternion.AngleAxis(directionAngle, transform.up) * elevation * initialVelocity;
        GameObject arrow = Instantiate(Arrow, Arrow.transform.position, Quaternion.identity);
        // ballGameObject is object to be thrown
        //arrow.GetComponent<Rigidbody>().velocity = velocity;
        arrow.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Acceleration);
    }

    // Helper method to find angle between two points (v1 & v2) with respect to axis n
    public static float AngleBetweenAboutAxis(Vector3 v1, Vector3 v2, Vector3 n)
    {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

    // Helper method to find angle of elevation (ballistic trajectory) required to reach distance with initialVelocity
    // Does not take wind resistance into consideration.
    private float FiringElevationAngle(float gravity, float distance, float initialVelocity)
    {
        float angle = 0.5f * Mathf.Asin((gravity * distance) / (initialVelocity * initialVelocity)) * Mathf.Rad2Deg;
        return angle;
    }
}
