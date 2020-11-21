using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    Main_Camera MC;
    private void Awake()
    {
        MC = GetComponent<Main_Camera>();
    }
    public void Soldier()
    {
        MC.Selected = GetComponent<Main_Camera>().Soldier;
    }
    public void Archer()
    {
        MC.Selected = GetComponent<Main_Camera>().Archer;
    }
}
