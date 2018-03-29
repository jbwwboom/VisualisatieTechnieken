#version 330

uniform sampler2D s_texture;
uniform float time;
in vec2 texCoord;
in vec3 color;

void main()
{
	float f = 1+0.5*cos(texCoord.x*200) + 0.5*sin(texCoord.y*200);
	gl_FragColor = vec4(f/0.8,f/0.6,f/0.4,1);
}