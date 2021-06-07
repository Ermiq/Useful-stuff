/*
	Angular radius, aka angular size, apparent size/diameter/radius.
	For an object in the distance its angular diameter is the angle it takes in the observer's field of view.
*/

/*
I use these methods to render celestial bodies closer to the camera than they actually are.
Due to limited camera render distance a planet that is 1 light second (~299792 km) away from the camera, it won't be visible.
But when the planet is big enough, it actually should be visible at this distance. 
So, to make it visible I find the angular radius of the planet and then find what would be its radius if it was seen from some closer distance.
In a space sim I'm able to make the camera render distance 10000km because there's not much objects to render anyway,
so I find the visible radius for 10000km to the center and render the planet at 10000km and scale it to the resulting radius.
And when I approach the planet closer than 10000km I start to render it at its actual distance with it's real size.
*/

/// Given the real size of a spherical object and the distance to its center we can find the angular radius with the following method.
/// The resulting angular radius is in radians.
float GetAngularRadius(float realRadius, float distance)
{
	return Math.Asin(realRadius / (distance * 2f));
}

/// To find out what would be the radius of the sphere if it was observed from the distance D and has angular radius AR:
float GetVisibleRadiusByDistance(float D, float AR)
{
	return (D * 2f) * Math.Sin(AR);
}

/// For a flat circle object instead of Asin and Sin use Atan and Tan.