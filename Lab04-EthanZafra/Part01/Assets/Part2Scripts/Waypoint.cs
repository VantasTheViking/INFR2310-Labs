using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waypoint : MonoBehaviour
{
    
    [SerializeField] public Vector3 pos;
    private void Start()
    {
        pos = transform.position;
    }

    public void SetPos(Vector3 newPos)
    {
        pos = newPos;
    }

    public Vector3 GetPos(){
        return pos;
    }
    // Update is called once per frame
    public Waypoint(){
        pos = new Vector3(0,0,0);
    }
}
