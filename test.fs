#version 330
uniform float time;

in vec2 texCoord;

 void main()
        {
            vec2 p =  texCoord * 8.0 - vec2(20.0);
            vec2 i = p;
            float c = 1.0;
            float inten = .05;

            for (int n = 0; n < 4; n++)
            {
                float t = time * (2.0 - (3.0 / float(n+1)));

                i = p + vec2(cos(t - i.x) + sin(t + i.y),
                sin(t - i.y) + cos(t + i.x));
		    
                c += 1.0/length(vec2(p.x / (sin(i.x+t)/inten),
                p.y / (cos(i.y+t)/inten)));
            }

            c /= float(4);
            c = 1.5 - sqrt(c);

            vec4 texColor = vec4(0.02, 0.15, 0.50, 1.);

            texColor.rgb *= (1.0/ (1.05 - (c + 0.05)));

            gl_FragColor = texColor;
        }