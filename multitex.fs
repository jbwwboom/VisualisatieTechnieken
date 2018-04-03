#version 330
uniform sampler2D s_texture;
uniform sampler2D s_texture2;
uniform float time;

in vec2 texCoord;
in vec3 color;


void main()
{
	gl_FragColor = mix(	texture2D(s_texture, texCoord), 
						texture2D(s_texture2, texCoord), 0.5 + 0.5 * sin(time));
}