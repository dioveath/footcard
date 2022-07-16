using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    public bool _isGrabbed = false;
    private Vector3 _initialPosition;
    
    void Start(){
        _initialPosition = transform.position;
    }
    
   void Update(){
    if(_isGrabbed){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objectPos;
    } else { 
        transform.position = _initialPosition;
    }
   }


    public void OnMouseDown(){
        _isGrabbed = true;
    }

    public void OnMouseUp(){
        _isGrabbed = false;
    }
    

}