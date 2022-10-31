using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Third Person")]
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineFreeLook freeLookCamera;
    [SerializeField] private float thirdPersonMouseLookSensitivity;

    [Header("First Person")]
    [SerializeField] private CinemachineVirtualCamera fpsCamera;
    [SerializeField] private float fpsMouseLookSensitivity;


    private CinemachineComposer aim;
    private float vertical;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            freeLookCamera.Priority = 100;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            freeLookCamera.Priority = 0;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }

        if(Input.GetMouseButton(1) == false)
        {
            vertical = Input.GetAxis("Mouse Y") * thirdPersonMouseLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -5f, 5f);
        }

        var fpsVertical = Input.GetAxis("Mouse Y") * fpsMouseLookSensitivity;
        fpsCamera.transform.Rotate(Vector3.right, -fpsVertical);
    }
}
