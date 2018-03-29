#version 330
uniform sampler2D s_texture;
in vec2 texCoord;

void main(void) {
	float pixelWidth = 1.0/float(256);

   float x = floor(texCoord.x/pixelWidth)*pixelWidth + pixelWidth/2.0;
   float y = floor(texCoord.y/pixelWidth)*pixelWidth + pixelWidth/2.0;

   gl_FragColor = texture2D(s_texture, vec2(x, y));
}