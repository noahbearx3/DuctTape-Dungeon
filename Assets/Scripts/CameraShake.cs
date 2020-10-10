using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    Vector3 cameraStartPosition;
    public float shakeMagnititude = 0.05f, shakeTime = 0.1f;
    public Camera mainCamera;

    void Start(){
        cameraStartPosition = mainCamera.transform.position;
    }


    public void ShakeCamera(){
        cameraStartPosition = mainCamera.transform.position;
        InvokeRepeating ("StartCameraShake", 0f, 0.005f);
        Invoke("StopCameraShake", shakeTime);
    }

    void StartCameraShake()
    {
        float cameraShakeOffsetX = Random.value * shakeMagnititude * 2 - shakeMagnititude;
        float cameraShakeOffsetY = Random.value * shakeMagnititude * 2 - shakeMagnititude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;
        cameraIntermediatePosition.x += cameraShakeOffsetX;
        cameraIntermediatePosition.y += cameraShakeOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopCameraShake(){
        CancelInvoke ("StartCameraShaking");
        mainCamera.transform.position = cameraStartPosition;

    }
}
