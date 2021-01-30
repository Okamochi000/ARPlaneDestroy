using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// ARPlane変更ログ表示
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
    /// ARPlane変更検知
    /// </summary>
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // ARPlane追加検知
        foreach (ARPlane plane in args.added)
        {
            string objectName = plane.gameObject.name;
            Debug.Log("[ARPlane added] " + plane.gameObject.name);
        }

        // ARPlane削除検知
        foreach (ARPlane plane in args.removed)
        {
            string objectName = plane.gameObject.name;
            Debug.Log("[ARPlane remove] " + plane.gameObject.name);
        }
    }
}
