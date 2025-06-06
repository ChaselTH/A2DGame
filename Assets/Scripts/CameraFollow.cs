using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // 玩家
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothSpeed = 5f;

    public float minX, maxX;
    public float minY, maxY;

    void LateUpdate()
    {
        if (target == null) return;

        // 1. 计算目标位置
        Vector3 desiredPosition = target.position + offset;

        // 2. 平滑插值
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 3. 限制摄像机不出边界
        float clampedX = Mathf.Clamp(smoothed.x, minX, maxX);
        float clampedY = Mathf.Clamp(smoothed.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, smoothed.z);
    }
}
