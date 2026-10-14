using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


[RequireComponent(typeof(Collider))]
public class ChainSetup : MonoBehaviour
{
    [Header("Anchor")]
    public Transform anchorPoint;   // The transform used as the joint's anchor point

    [Header("Movement Limits")]
    public float linearLimit = 0.3f;   // Maximum distance the object can move from its anchor

    [Header("Physics")]
    public float mass = 2f;         // Mass of the chain
    public float drag = 1f;         // Linear air resistance
    public float angularDrag = 2f;  // Rotational air resistance

    private Rigidbody rb;
    private ConfigurableJoint joint;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;


    // Calls each setup method on startup
    void Awake()
    {
        SetupRigidbody();
        SetupJoint();
        SetupGrabInteractable();
    }


    // Sets up a Rigidbody and applies the physics settings
    void SetupRigidbody()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.mass = mass;
        rb.drag = drag;
        rb.angularDrag = angularDrag;
        rb.useGravity = true;

        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }


    // Sets up a ConfigurableJoint and constrains the object's movement around the anchor
    void SetupJoint()
    {
        joint = GetComponent<ConfigurableJoint>();

        if (joint == null)
            joint = gameObject.AddComponent<ConfigurableJoint>();

        joint.connectedBody = null;

        if (anchorPoint != null)
        {
            Vector3 localAnchor = transform.InverseTransformPoint(anchorPoint.position);
            joint.anchor = localAnchor;
        }

        // Allow limited linear movement
        joint.xMotion = ConfigurableJointMotion.Limited;
        joint.yMotion = ConfigurableJointMotion.Limited;
        joint.zMotion = ConfigurableJointMotion.Limited;

        SoftJointLimit limit = new SoftJointLimit();
        limit.limit = linearLimit;

        joint.linearLimit = limit;

        // Lock all/any axial rotation
        joint.angularXMotion = ConfigurableJointMotion.Locked;
        joint.angularYMotion = ConfigurableJointMotion.Locked;
        joint.angularZMotion = ConfigurableJointMotion.Locked;

        joint.autoConfigureConnectedAnchor = true;
    }


    // Uses Kinematic movement to avoid physics conflicts while chain is grabbed
    void SetupGrabInteractable()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (grab == null)
            grab = gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grab.movementType = XRBaseInteractable.MovementType.Kinematic;
        grab.throwOnDetach = false;
    }
}
