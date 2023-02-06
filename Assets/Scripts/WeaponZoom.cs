using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [Header("Camera Configurations")]
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] float zoomFov;

    float startingFov;
    LensSettings lensSettings;

    // Start is called before the first frame update
    void Start()
    {
        lensSettings = playerCamera.m_Lens;
        startingFov = lensSettings.FieldOfView;
    }

    public void Zoom()
    {
        playerCamera.m_Lens.FieldOfView = zoomFov;
    }

    public void UnZoom()
    {
        playerCamera.m_Lens.FieldOfView = startingFov;

    }
}
