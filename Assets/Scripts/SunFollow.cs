using UnityEngine;

public class SunFollow : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 initialOffset;

    void Start()
    {
        // Lưu khoảng cách ban đầu giữa mặt trời và camera
        initialOffset = transform.position - cameraTransform.position;
    }

    void LateUpdate()
    {
        // Giữ nguyên khoảng cách theo trục X nhưng bỏ qua dao động theo Y
        Vector3 newPos = cameraTransform.position + initialOffset;
        newPos.y = initialOffset.y+2f;
        transform.position = newPos;
    }
}
