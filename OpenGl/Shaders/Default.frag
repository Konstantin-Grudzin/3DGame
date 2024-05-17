#version 330 core

in vec2 texCoord;

out vec4 FragColor;

uniform sampler2D texture0;

uniform float brightness;

void main() 
{
	 vec4 tmp = texture(texture0, texCoord);
	 FragColor = vec4(tmp.r*brightness,tmp.g*brightness,tmp.b*brightness,tmp.a);
}