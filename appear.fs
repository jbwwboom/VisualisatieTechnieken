#version 330
uniform float time;
uniform sampler2D s_texture;

in vec3 normal;
in vec3 color;
in vec2 texCoord;

float random (in vec2 st) {
    return fract(sin(dot(st.xy,
                         vec2(12.9898,78.233)))
                 * 43758.5453123);
}

float noise (in vec2 st) {
    vec2 i = floor(st);
    vec2 f = fract(st);

    float a = random(i);
    float b = random(i + vec2(1.0, 0.0));
    float c = random(i + vec2(0.0, 1.0));
    float d = random(i + vec2(1.0, 1.0));

    vec2 u = f*f*(3.0-2.0*f);
    return mix(a, b, u.x) +
            (c - a)* u.y * (1.0 - u.x) +
            (d - b) * u.x * u.y;
}

void main()
{
		float noise = noise(texCoord);
		float threshold = 0.8 - (mod(time, 10) / 5.0);
		if (noise > threshold){
			gl_FragColor = texture2D(s_texture, texCoord);
		}
		else{
			discard;
		}
}