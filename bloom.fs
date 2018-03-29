#version 330
uniform sampler2D s_texture;
uniform vec2 resolution;

in vec2 texCoord;

vec4 bloomEffect(in vec2 coords) {
   

  vec4 bloom = vec4(0.0);
  int j;
  int i;
  float bloomLevel = 20;

  for( i = -4 ; i < 4; i++) {
    for (j = -3; j < 3; j++) {
      bloom += texture2D(s_texture, coords + vec2((j * 1.0 / resolution.x), (i * 1.0 / resolution.y))) * (bloomLevel * 0.01);
    }
  }
    
  if (texture2D(s_texture, coords).r < 0.3) {
    bloom = bloom * bloom * 0.012;
  } else if (texture2D(s_texture, coords).r < 0.5) {
    bloom = bloom * bloom * 0.009;
  } else {
    bloom = bloom * bloom *0.0075;
  }
  
  return bloom + texture2D(s_texture, coords);
}

void main(){
  gl_FragColor = bloomEffect(texCoord);
}