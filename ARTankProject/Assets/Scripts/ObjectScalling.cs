﻿using UnityEngine;
using System.Collections;
public class ObjectScalling : MonoBehaviour
{
    public ParticleSystem Lsmoke;
    public ParticleSystem Rsmoke;
    public float sensitivity = 0.001f;
    // Update is called once per frame
    void Update()
    {

        
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = (prevTouchDeltaMag - touchDeltaMag) * sensitivity;
            float newScaleObject = transform.localScale.x - deltaMagnitudeDiff;
            float newSmokeScaleObject = Lsmoke.transform.localScale.x - deltaMagnitudeDiff;

            //The object can not in opposite direction.
            if (newScaleObject > 0.4f || newSmokeScaleObject > 0.4f){
                transform.localScale = new Vector3(newScaleObject, newScaleObject, newScaleObject);
                Lsmoke.transform.localScale = new Vector3(newSmokeScaleObject, newSmokeScaleObject, newSmokeScaleObject);
                Rsmoke.transform.localScale = new Vector3(newSmokeScaleObject, newSmokeScaleObject, newSmokeScaleObject);
            }

        }
    }
}