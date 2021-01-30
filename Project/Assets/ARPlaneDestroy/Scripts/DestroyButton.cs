using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Runtime.InteropServices;

/// <summary>
/// �폜�{�^��
/// </summary>
public class DestroyButton : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void destroyARPlane(IntPtr sessionPtr, IntPtr arPlanePtr);

    [SerializeField] private ARSession session = null;
    [SerializeField] private float rayDistance = 100.0f;

    /// <summary>
    /// �폜�{�^��
    /// </summary>
    public void OnButtonCallback()
    {
        if (session == null)
        {
            Debug.LogError("ARSession���ݒ肳��Ă��܂���");
            return;
        }

        if (Camera.main == null)
        {
            Debug.LogError("MainCamera���ݒ肳��Ă��܂���");
            return;
        }

        Transform transform = Camera.main.transform;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, rayDistance);
        if (hit.transform != null)
        {
            ARPlane plane = hit.transform.GetComponent<ARPlane>();
            if (plane != null)
            {
                destroyARPlane(session.subsystem.nativePtr, plane.nativePtr);
            }
        }
    }
}
