using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMugitu : MonoBehaviour
{
    public float xySpeed = 10f;
    public float RotationSpeed = 100f;
    public float TiltLimit = 15f;
    [SerializeField] 
    InputActionReference moveAction;

    public GameObject AimObject;
    public Transform Model;

    private void Update()
    {
        Vector2 xyVector = moveAction.action.ReadValue<Vector2>();

        LocalMove(xyVector.x, xyVector.y, xySpeed);
        ClampPosition();
        RotationLook(xyVector.x, xyVector.y, RotationSpeed);
        HorizontalTilt(Model, xyVector.x,TiltLimit, .1f);
    }

    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }

    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void HorizontalTilt(Transform target, float axis,float TiltLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis * TiltLimit, lerpTime));
    }

    void RotationLook(float h, float v, float speed)
    {
        AimObject.transform.localPosition = new Vector3(h, v, 1);
        gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(AimObject.transform.position), Mathf.Deg2Rad * speed *  Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, .5f);
        Gizmos.DrawSphere(transform.position, .15f);
    }

}
