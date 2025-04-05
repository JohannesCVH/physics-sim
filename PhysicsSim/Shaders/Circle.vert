#version 330 core

in vec3 position;

uniform mat3 transform;

void main()
{
    gl_Position = vec4(position * transform, 1.0);
}