using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ParentScriptForTrigger : MonoBehaviour {

    List<GameObject> Object;
    private Vector3[] OriginPosition;
    [SerializeField]
    public bool LogFell = false;

    void Start ()
    {
        Object = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.tag == "Boulder")
                Object.Add(child.gameObject);
        }
        OriginPosition = new Vector3[Object.Count];
        for (int i = 0; i < Object.Count; i++)
            OriginPosition[i] = Object[i].transform.position;      
    }

    public void Fall()
    {
        LogFell = true;
        for (int i = 0; i < Object.Count; i++)
        {
            Object[i].transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Object[i].GetComponent<Rigidbody>().useGravity = true;
        }          
    }

    public void ResetTrap()
    {
        for (int i = 0; i < Object.Count; i++)
        {
            Object[i].transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Object[i].transform.position = OriginPosition[i];
            Object[i].transform.rotation = Quaternion.identity;
            Object[i].GetComponent<Rigidbody>().useGravity = false;
        }
        LogFell = false;
    }
}
