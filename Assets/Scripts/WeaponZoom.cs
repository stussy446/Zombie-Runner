using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [Header("Camera Configurations")]
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] float zoomFov;
    [SerializeField] float zoomedMouseSensitivty;

    FirstPersonController fpsController;
    float startingMouseSensitivity;
    float startingFov;
    LensSettings lensSettings;

    // Start is called before the first frame update
    void Start()
    {
        lensSettings = playerCamera.m_Lens;
        startingFov = lensSettings.FieldOfView;

        fpsController = GetComponentInChildren<FirstPersonController>();
        startingMouseSensitivity = fpsController.RotationSpeed;

    }

    public void Zoom()
    {
        playerCamera.m_Lens.FieldOfView = zoomFov;
        fpsController.RotationSpeed = zoomedMouseSensitivty;
    }

    public void UnZoom()
    {
        playerCamera.m_Lens.FieldOfView = startingFov;
        fpsController.RotationSpeed = startingMouseSensitivity;
    }
}
