using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// ARPlane�ύX���O�\��
/// </summary>
public class ARPlaneLog : MonoBehaviour
{
    [SerializeField] private ARPlaneManager arPlaneManager = null;

    private void OnEnable()
    {
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged += OnPlanesChanged;
        }
    }

    private void OnDisable()
    {
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged -= OnPlanesChanged;
        }
    }

    /// <summary>
    /// ARPlane�ύX���m
    /// </summary>
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // ARPlane�ǉ����m
        foreach (ARPlane plane in args.added)
        {
            string objectName = plane.gameObject.name;
            Debug.Log("[ARPlane added] " + plane.gameObject.name);
        }

        // ARPlane�폜���m
        foreach (ARPlane plane in args.removed)
        {
            string objectName = plane.gameObject.name;
            Debug.Log("[ARPlane remove] " + plane.gameObject.name);
        }
    }
}
