// Smooth change of the given 'current' value towards 'target' with
// acceleration at the beginning and deceleration to the end,
// args:
// float current - the value to change
// float target - the finish value
// ref float velocity - to store current velocity between the method calls
// float accel - how fast the 'current' will be increased/decreased on every call
// float maxVelocity - the maximum speed to move to the 'target'
public static float SmoothTowards(float current, float target, ref float velocity, float accel, float maxVelocity = float.PositiveInfinity)
{
    // The calculations need to be made in positive absolute values,
    // in the end we'll set the result sign to the original change direction sign.	
    int sign = (target - current) > 0 ? 1 : -1;

    float distance = target - current;
    // Make the values positive for the calculations:
    if (velocity < 0) velocity = -velocity;
    if (distance < 0) distance = -distance;

    // d: the distance that is required to decelerate over time and to stop
    // at the target position with
    // the given aceleration/deceleration and current velocity values.
    float t = velocity / accel;
    float d = velocity * t + accel * (t * t) / 2f;

    if (distance < d)
        velocity -= accel;
    else
        velocity += accel;

    if (velocity > maxVelocity) velocity = maxVelocity;

    // Set velocity to the original change direction sign:
    velocity *= sign;

    float result = current + velocity;
	
    // Prevent overshooting:
	if (current < target && target <= result ||
        current <= target && target < result)
        return target;
    else
        return result;
}
