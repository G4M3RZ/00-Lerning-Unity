using UnityEngine;

public class AutoValace : MonoBehaviour
{
    [Range(0, 2)] public float _rayDistance;
    [Range(0, 10)] public float _smothSpeed;
    public LayerMask _layerDetection;

    public void Valance(Vector3 playerPos)
    {
        Ray ray = new Ray(playerPos, -transform.up * _rayDistance);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * _rayDistance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, _layerDetection))
        {
            transform.position = new Vector3(playerPos.x, hitInfo.point.y + 0.5f, playerPos.z);

            //Get player Y Rot
            Quaternion playerRot = Quaternion.Euler(0, transform.localEulerAngles.y, 0);

            //Get up position and smoth vector speed
            Quaternion getRot = Quaternion.FromToRotation(Vector3.up, hitInfo.normal) * playerRot;
            Quaternion setRot = Quaternion.Lerp(transform.localRotation, getRot, Time.deltaTime * _smothSpeed);

            //Set smoth Rotation
            transform.rotation = setRot;
        }
    }
}