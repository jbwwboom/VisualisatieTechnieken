#version 330
uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;

void main()
{
    float o = time/2048.0;

/*    vec4 color = (5 * texture2D(s_texture, texCoord) -
                texture2D(s_texture, texCoord + vec2(-o, 0)) -
                texture2D(s_texture, texCoord + vec2( o, 0)) -
                texture2D(s_texture, texCoord + vec2(0, o)) -
                texture2D(s_texture, texCoord + vec2(0, -o)));
				*/

	//vec4 color = texture2D(s_texture, texCoord + 0.01 * vec2(sin(time + texCoord.y * 10), sin(time*0.5 + texCoord.x * 12)));
	vec4 color = texture2D(s_texture, texCoord);

	gl_FragColor = color;
}