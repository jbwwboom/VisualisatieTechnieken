uniform sampler2D s_texture;
uniform mat4 projectionMatrix;
uniform mat4 modelViewMatrix;

in vec3 normal;
in vec3 color;
in vec2 texCoord;
// The width and height of each pixel in texture coordinates
float pixelWidth = 256;
float pixelHeight = 256;



void main()
{

	// Current texture coordinate

	vec2 texel = texCoord;

	vec4 pixel = vec4(texture2D(s_texture, texel));

	

	// Larger constant = bigger glow

	float glow = 4.0 * ((pixelWidth + pixelHeight) / 2.0);

	

	// The vector to contain the new, "bloomed" colour values

	vec4 bloom = vec4(0);

	

	// Loop over all the pixels on the texture in the area given by the constant in glow

	int count = 0;

	for(float x = texel.x - glow; x < texel.x + glow; x += pixelWidth)

	{

		for(float y = texel.y - glow; y < texel.y + glow; y += pixelHeight)

		{

			// Add that pixel's value to the bloom vector

			bloom += (texture2D(s_texture, vec2(x, y)) - 0.4) * 30.0;

			// Add 1 to the number of pixels sampled

			count++;

		}

	}

	// Divide by the number of pixels sampled to average out the value

	// The constant being multiplied with count here will dim the bloom effect a bit, with higher values

	// Clamp the value between a 0.0 to 1.0 range

	bloom = clamp(bloom / (count * 30), 0.0, 1.0);

	

	// Set the current fragment to the original texture pixel, with our bloom value added on

	gl_FragColor = pixel + bloom;

}