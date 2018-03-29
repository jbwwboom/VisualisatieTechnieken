#version 330
layout(location=0) in vec3 a_position;
layout(location=1) in vec3 a_color;
layout(location=2) in vec2 a_texcoord;
layout(location=3) in vec3 a_normal;

out vec3 normal;
out vec2 texCoord;
out mat3 TBNmatrix;
out vec3 worldpos;

uniform mat4 projectionMatrix;
uniform mat4 modelViewMatrix;

void main()
{
	normal = normalMatrix * a_normal;
	texCoord = a_texcoord;
	TBNMatrix mat3(vec3(modelViewMatrix * vec4(a_tangent,0)),
					vec3(modelViewMatrix * vec4(cross(a_tangent,a_normal),0)),
					vec3(modelViewMatrix * vec4(a_normal,0)));
	gl_Position = projectionMatrix * modelViewMatrix * vec4(a_position,1);
	worldpos = a_position;
}