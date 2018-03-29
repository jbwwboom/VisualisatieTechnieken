#version 330

uniform vec3 diffuse_color;
uniform float alpha;

uniform float edge;
uniform float mid;

in vec3 normal;

void main()
{
	float intensity, factor;

	vec4 color;

	vec3 n = normalize(normal);
	vec3 lightDirection = normalize(vec3(1,1,1));
	intensity = max(dot(n,lightDirection), 0.0);
		
	vec3 r = reflect(-lightDirection, normalize(normal));

	if (intensity > 0.95)
		color = vec4(1.0,0.5,0.5,1.0);
	else if (intensity > 0.5)
		color = vec4(0.6,0.3,0.3,1.0);
	else if (intensity > 0.25)
		color = vec4(0.4,0.2,0.2,1.0);
	else
		color = vec4(0.2,0.1,0.1,1.0);


	gl_FragColor = color;

}