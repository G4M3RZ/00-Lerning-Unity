using UnityEngine;

public class AutoValace : MonoBehaviour
{
    [Range(0, 2)] public float _rayDistance;
    [Range(0, 10)] public float _smothSpeed;
    public LayerMask _layerDetection;

    public void Valance(Vector3 playerPos)
    {
        Ray ray = new Ray(playerPos, -transform.up * _rayDistance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, _rayDistance, _layerDetection))
        {
            //show ray
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * _rayDistance);

            //set player pos
            transform.position = hitInfo.point + (transform.up / 2);

            //Get player Y Rot
            Quaternion playerRot = Quaternion.Euler(0, transform.localEulerAngles.y, 0);

            //Get up position and smoth vector speed
            Quaternion getRot = Quaternion.FromToRotation(Vector3.up, hitInfo.normal) * playerRot;
            //Quaternion setRot = Quaternion.Lerp(transform.localRotation, getRot, Time.deltaTime * _smothSpeed);

            //Set smoth Rotation
            transform.rotation = getRot;
        }
    }
}