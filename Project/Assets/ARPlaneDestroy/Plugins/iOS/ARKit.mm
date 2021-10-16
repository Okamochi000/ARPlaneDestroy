 #import <ARKit/ARKit.h>

 extern "C" {
    typedef struct UnityXRNativeSessionPtr
    {
        int version;
        ARSession* session;
    } UnityXRNativeSessionPtr;
 
    typedef struct UnityXRNativeARPlaneAnchorPtr
    {
        int version;
        ARPlaneAnchor* anchor;
    } UnityXRNativeARPlaneAnchorPtr;
 
    void destroyARPlane(UnityXRNativeSessionPtr* sessionPtr, UnityXRNativeARPlaneAnchorPtr* arPlanePtr){
        [sessionPtr->session removeAnchor:arPlanePtr->anchor];
    }
}
