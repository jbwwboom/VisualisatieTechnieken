#version 330
layout(location=0) in vec3 a_position;
layout(location=1) in vec3 a_color;
layout(location=2) in vec2 a_texcoord;
layout(location=3) in vec3 a_normal;
layout(location=4) in vec3 aPos;
layout(location=5) in vec3 aNormal;
layout(location=6) in vec2 aTexCoords;
layout(location=7) in vec3 aTangent;
layout(location=8) in vec3 aBitangent;

uniform mat4 projectionMatrix;
uniform mat4 modelViewMatrix;

out VS_OUT {
    vec3 FragPos;
    vec2 TexCoords;
    vec3 TangentLightPos;
    vec3 TangentViewPos;
    vec3 TangentFragPos;
} vs_out;


void main()
{
	vec3 viewPos = vec3(0.0f, 0.0f, 3.0f);
	vec3 lightPos = vec3(0.5f, 1.0f, 0.3f);

    vs_out.FragPos = vec3(modelViewMatrix * vec4(aPos, 1.0));   
    vs_out.TexCoords = aTexCoords;

	mat3 normalMatrix = mat3(modelViewMatrix);
	normalMatrix = transpose(inverse(normalMatrix));

    vec3 T = normalize(normalMatrix * aTangent);
    vec3 N = normalize(normalMatrix * aNormal);
    T = normalize(T - dot(T, N) * N);
    vec3 B = cross(N, T);
    
    mat3 TBN = transpose(mat3(T, B, N));    
    vs_out.TangentLightPos = TBN * lightPos;
    vs_out.TangentViewPos  = TBN * viewPos;
    vs_out.TangentFragPos  = TBN * vs_out.FragPos;
		
	gl_Position = projectionMatrix * modelViewMatrix * vec4(a_position,1);
}