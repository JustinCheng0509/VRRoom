using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{

    public GameObject Cover;
    public HingeJoint Hinge;
    // Start is called before the first frame update
    void Start()
    {   
        var Hinge = Cover.GetComponent<HingeJoint>();
        
        Hinge.useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {

        Hinge.useMotor = true;
        Debug.Log("Open Book");    
    }

    
}
