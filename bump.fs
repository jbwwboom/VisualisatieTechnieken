#version 330
uniform sampler2D s_texture;  
uniform sampler2D s_texture2;  

in vec2 texCoord;
in vec3 normal;
  
void main() {  
  
// Extract the normal from the normal map  
vec3 normal = normalize(texture2D(s_texture, texCoord).rgb * 2.0 - 1.0);  
  
// Determine where the light is positioned (this can be set however you like)  
vec3 light_pos = normalize(vec3(1.0, 1.0, 1.5));  
  
// Calculate the lighting diffuse value  
float diffuse = max(dot(normal, light_pos), 0.0);  
  
vec3 color = diffuse * texture2D(s_texture2, texCoord).rgb;  
  
// Set the output color of our current pixel  
gl_FragColor = vec4(color, 1.0);  
}  