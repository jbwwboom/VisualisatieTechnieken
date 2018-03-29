#version 330
uniform sampler2D s_texture;
uniform vec2 resolution;

in vec2 texCoord;

const float sampleDist = 1.0;
const float sampleStrength = 2.2;


vec4 radialBlur(in vec2 coords) {
  float samples[10] = float[](-0.08,-0.05,-0.03,-0.02,-0.01,0.01,0.02,0.03,0.05,0.08);

  vec2 dir = 0.5 - coords;
  float distance = length(dir);

  dir = normalize(dir);

  vec4 color =  texture2D(s_texture, coords);
  vec4 blurredcolor = color;

  for (int i = 0; i < 10; i++) {
    blurredcolor += texture2D( s_texture, coords + dir * samples[i] * sampleDist );
  }

  blurredcolor *= 1.0/11.0;

  float t = distance * sampleStrength;
  t = clamp( t ,0.0,1.0);

  return mix( color, blurredcolor, t );
}

void main (){
  gl_FragColor = radialBlur(texCoord);
}