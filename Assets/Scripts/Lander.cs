using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    private Rigidbody2D langerRigidBody2D;

    private void Awake()
    {
        langerRigidBody2D = GetComponent<Rigidbody2D>();

        // Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(0, 1)));
        // Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(0.5f, 0.5f)));
        // Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(1, 0)));
        // Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(0, -1)));


    }

    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            float force = 700f;
            langerRigidBody2D.AddForce(force * transform.up * Time.deltaTime);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            float turnSpeedLeft = +100f;
            langerRigidBody2D.AddTorque(turnSpeedLeft * Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            float turnSpeedRight = -100f;
            langerRigidBody2D.AddTorque(turnSpeedRight * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (!collision2D.gameObject.TryGetComponent(out LandingPad landingPad))
        {
            Debug.Log("Crashed on the Terrain");
            return;
        }

        float softLandingVelocityMagnitude = 4f;
        float relativeVelocityMagnitude = collision2D.relativeVelocity.magnitude;

        if (relativeVelocityMagnitude > softLandingVelocityMagnitude)
        {
            // Landed to hard
            Debug.Log("Landed to hard");

            return;
        }

        float dotVector = Vector2.Dot(Vector2.up, transform.up);
        float minDotVector = 0.90f;

        if (dotVector < minDotVector)
        {
            // Landed on a too steep angle
            Debug.Log("Landed on a too steep angle");

            return;
        }

        Debug.Log("Successful landing");


        float maxScoreAmountLandingAngle = 100;
        float scoreDotVectorMultiplier = 10f;
        float landingAngleScore = maxScoreAmountLandingAngle - Mathf.Abs(dotVector - 1f) * scoreDotVectorMultiplier * maxScoreAmountLandingAngle;

        float maxScoreAmountLandingSpeed = 100;
        float landingSpeedScore = (softLandingVelocityMagnitude - relativeVelocityMagnitude) * maxScoreAmountLandingSpeed;


        Debug.Log("landingAngleScore: " + landingAngleScore);
        Debug.Log("landingSpeedScore: " + landingSpeedScore);


    }


}
