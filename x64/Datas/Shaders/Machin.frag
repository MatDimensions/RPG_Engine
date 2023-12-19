#version 120
uniform sampler2D texture;

void main()
{
	// récupère le pixel dans la texture
	vec2 texCoord = gl_TexCoord[0].xy;
	vec4 pixel = texture2D(texture, texCoord);

	gl_FragColor = pixel;
}