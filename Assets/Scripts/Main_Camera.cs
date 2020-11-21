using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    public GameObject Soldier;
    public GameObject Archer;
    public GameObject Destination;
    public GameObject cube;
    public GameObject Selected;
    public static GameObject TargetTower;
    public GameObject Arrow;
    void Start()
    {
        Selected = Soldier;
        TargetTower = cube;
        Debug.Log("" + Vector3.SqrMagnitude(Vector3.zero));
    }

    void Update()
    {
        
    }
    public void Put()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit) && hit.point.y < 0.5f && hit.point.y > -0.5f)
        {
            Debug.Log(hit.point);
            GameObject g = Instantiate(Selected, hit.point, Quaternion.identity);
            g.GetComponent<Soldier>().Destination = TargetTower;
            g.GetComponent<Soldier>().destination = TargetTower.name;
            //her bir cubeün farklı navmeshagentı olcak
        }
    }
}
