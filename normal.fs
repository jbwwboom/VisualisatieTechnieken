#version 330
in VS_OUT {
    vec3 FragPos;
    vec2 TexCoords;
    vec3 TangentLightPos;
    vec3 TangentViewPos;
    vec3 TangentFragPos;
    vec3 normal;
    mat3 TBN;
} fs_in;

uniform sampler2D s_texture;
uniform sampler2D s_texture2;
vec3 cameraPos = vec3(0.0,0.0,3.0);

void main()
{
    vec3 viewPos = vec3(cameraPos.x, cameraPos.y, cameraPos.z);
    vec3 lightPos = vec3(0.0f, 1.0f, 1.0f);

    vec3 normal = texture(s_texture2, fs_in.TexCoords).rgb;
    normal = normalize(normal * 2.0 - 1.0);

   // Lightning
    vec3 color = texture(s_texture, fs_in.TexCoords).rgb;

    // Ambient
    vec3 ambient = 0.5 * color;

    // Diffuse
    vec3 lightDir = normalize(fs_in.TangentLightPos - fs_in.TangentFragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * color;

    // Specular
    vec3 viewDir = normalize(fs_in.TangentViewPos - fs_in.TangentFragPos);
    vec3 reflectDir = reflect(-lightDir, normal);
    vec3 halfwayDir = normalize(lightDir + viewDir);
    float spec = pow(max(dot(reflectDir, halfwayDir), 0.0), 32.0);
    vec3 specular = vec3(0.3) * spec;

    gl_FragColor = vec4(ambient + diffuse + specular, 1.0);
}