#version 330
uniform sampler2D s_texture;
in vec2 texCoord;

void main(void) {
  vec2 tex = texCoord;
  tex.x += sin(tex.y * 4*2*3.14159) / 100;
  gl_FragColor = texture2D(s_texture, tex);
}