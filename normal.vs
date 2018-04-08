#version 330
layout (location = 0) in vec3 a_position;
layout (location = 1) in vec3 a_color;
layout (location = 2) in vec2 a_texcoord;
layout (location = 3) in vec3 a_normal;
layout (location = 4) in vec3 a_tangent;
layout (location = 5) in vec3 a_bitangent;

uniform mat4 projectionMatrix;
uniform mat4 modelViewMatrix;

out VS_OUT {
    vec3 FragPos;
    vec2 TexCoords;
    vec3 TangentLightPos;
    vec3 TangentViewPos;
    vec3 TangentFragPos;
    vec3 normal;
    mat3 TBN;
} vs_out;

vec3 cameraPos = vec3(0.0,0.0,3.0);

void main()
{
    vec3 viewPos = vec3(cameraPos.x, cameraPos.y, cameraPos.z);
    vec3 lightPos = vec3(0.0f, 1.0f, 1.0f);

    vs_out.FragPos = vec3(modelViewMatrix * vec4(a_position, 1.0));
    vs_out.TexCoords = a_texcoord;

    mat3 normalMatrix = mat3(modelViewMatrix);
    normalMatrix = transpose(inverse(normalMatrix));

    vec3 T = normalize(normalMatrix * a_tangent);
    vec3 N = normalize(normalMatrix * a_normal);
    T = normalize(T - dot(T, N) * N);
    vec3 B = cross(N, T);

    mat3 TBN = transpose(mat3(T, B, N));
    vs_out.TangentLightPos = TBN * lightPos;
    vs_out.TangentViewPos  = TBN * viewPos;
    vs_out.TangentFragPos  = TBN * vs_out.FragPos;

    vs_out.normal = N;
    vs_out.TBN = transpose(TBN);
    gl_Position = projectionMatrix * modelViewMatrix * vec4(a_position,1);
}