using UnityEngine;

public class MainCamera : MonoBehaviour
{
    
    public Transform player;
    public Transform fppPosition;
    public Transform tppArm;

    public float tppDistance = 4f;
    public float tppHeight =2f;
    public Vector3 tppOffset = new Vector3(0.5f, 0f, 0f);

    public float mouseSensitivity = 200f;
    public float minPitch = -40f;
    public float maxPitch = 60f;

    public float switchSpeed = 10f;
    public float rotationSmoothing = 8f;

    public float collisionRadius = 0.2f;
    public LayerMask collisionMask;

    private bool isFPP = false;
    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleCameraSwitch();
        HandleMouseLook();
    }

    void LateUpdate()
    {
        if (isFPP)
        {
            ApplyFPPCamera();
        }
        else
        {
            ApplyTPPCamera();
        }
    }

    void HandleCameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFPP = !isFPP;
            TogglePlayerMesh(!isFPP);
        }
    }

    void TogglePlayerMesh(bool visible)
    {
        Renderer[] renderers = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = visible;
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        player.rotation = Quaternion.Euler(0f, yaw, 0f);

    }

    void ApplyFPPCamera()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            fppPosition.position,
            Time.deltaTime * switchSpeed
        );

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(pitch, yaw, 0f),
            Time.deltaTime * rotationSmoothing
        );
    }

    void ApplyTPPCamera()
    {
        Quaternion camRotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredOffset = camRotation * new Vector3(
            tppOffset.x,
            tppHeight,
            -tppDistance
        );

        Vector3 desiredPosition = player.position + desiredOffset;

        Vector3 finalPosition = checkTPPCollision(player.position, desiredPosition);

        transform.position = Vector3.Lerp(
            transform.position,
            finalPosition,
            Time.deltaTime * switchSpeed
        );

        Vector3 lookTarget = player.position + Vector3.up * (tppHeight * 0.5f);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(lookTarget - transform.position),
            Time.deltaTime * rotationSmoothing
        );
    }   

    Vector3 checkTPPCollision(Vector3 origin, Vector3 desired)
    {
        RaycastHit hit;
        Vector3 direction = desired - origin;

        if (Physics.SphereCast(origin, collisionRadius, direction.normalized,
        out hit, direction.magnitude, collisionMask))
        {
            return hit.point + hit.normal * collisionRadius;
        }

        return desired;

    }
}   

