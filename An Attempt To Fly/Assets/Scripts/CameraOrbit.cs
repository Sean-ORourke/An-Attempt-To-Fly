using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform parentObject; // The parent object to orbit around
    public float rotationSpeed = 100f; // Speed of rotation
    public float distance = 5f; // Distance from the parent object

    private Vector3 offset; // Initial offset from the parent

    void Start()
    {
        if (parentObject == null)
        {
            Debug.LogError("Parent Object not assigned!");
            return;
        }

        // Calculate the initial offset based on the camera's position
        offset = transform.position - parentObject.position;
    }

    void Update()
    {
        if (parentObject == null) return;

        // Get input for camera rotation
        float horizontalInput = 0f;
        float verticalInput = 0f;

        //if (Input.GetKey(KeyCode.I)) verticalInput = 1f; // Up 
        //if (Input.GetKey(KeyCode.K)) verticalInput = -1f; // Down
        if (Input.GetKey(KeyCode.L)) horizontalInput = -1f; // Left
        if (Input.GetKey(KeyCode.J)) horizontalInput = 1f; // Right

        // Calculate rotation around the parent
        Quaternion horizontalRotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
        Quaternion verticalRotation = Quaternion.Euler(verticalInput * rotationSpeed * Time.deltaTime, 0f, 0f);

        // Rotate the offset vector
        offset = horizontalRotation * verticalRotation * offset;

        // Update the camera's position and keep it focused on the parent
        transform.position = parentObject.position + offset;
        transform.LookAt(parentObject.position);
    }
}
