using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Main_Camera.TargetTower = gameObject;

        //GameObjectUtility.SetStaticEditorFlags(gameObject, StaticEditorFlags.NavigationStatic);



        //NavMeshObstacle[] nmo = FindObjectsOfType<NavMeshObstacle>();
        //foreach(NavMeshObstacle n in nmo)
        //{
        //    n.carving = true;
        //}
        //GetComponent<NavMeshObstacle>().carving = false;




        //NavMeshSurface nms = GameObject.Find("NavMeshAgent").GetComponent<NavMeshSurface>();
        //nms.BuildNavMesh();
    }
}
