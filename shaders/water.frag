// Based on: https://www.shadertoy.com/view/Xdl3W7

#define PI 3.14159265359
#define MAX_RAYMARCH_ITER 80
#define MAX_BINARY_ITERS 11

const float precis = 0.001;
const float waterHeight = 100.0;
const vec3 lightDir = normalize(vec3(0.0, 0.5, 0.5));
const float LOG2 = 1.442695;

// By iq

float hash(float n)
{
    return fract(sin(n)*43758.5453123);
}

float noise(in vec2 x)
{
    vec2 p = floor(x);
    vec2 f = fract(x);

    f = f*f*(3.0-2.0*f);

    float n = p.x + p.y*57.0;
    float res = mix(mix(hash(n+  0.0), hash(n+  1.0), f.x),
                    mix(hash(n+ 57.0), hash(n+ 58.0), f.x), f.y);
    return res;
}

float noise(in vec3 x)
{
    vec3 p = floor(x);
    vec3 f = fract(x);

    f = f*f*(3.0-2.0*f);

    float n = p.x + p.y*57.0 + 113.0*p.z;
    float res = mix(mix(mix(hash(n+  0.0), hash(n+  1.0), f.x),
                        mix(hash(n+ 57.0), hash(n+ 58.0), f.x), f.y),
                    mix(mix(hash(n+113.0), hash(n+114.0), f.x),
                        mix(hash(n+170.0), hash(n+171.0), f.x), f.y), f.z);
    return res;
}

// End iq

// Rotate a vector on the X axe.
// http://en.wikipedia.org/wiki/Rotation_(mathematics)
vec3 rotateX(vec3 p, float a) 
{
    float c = cos(a); float s = sin(a);
    return vec3(p.x, c * p.y - s * p.z, s * p.y + c * p.z);
}

// Rotate a vector on the Y axe.
// http://en.wikipedia.org/wiki/Rotation_(mathematics)
vec3 rotateY(vec3 p, float a) 
{
    float c = cos(a); float s = sin(a);
    return vec3(c * p.x + s * p.z, p.y, -s * p.x + c * p.z);
}

vec3 fogColor(vec3 rd)
{
	vec3 col = mix(vec3(0.3, 0.6, 0.9), vec3(0.0, 0.05, 0.2), clamp(rd.y * 2.5, 0.0, 1.0));
	col += pow(dot(lightDir, rd) * 0.5 + 0.5, 2.0) * vec3(0.5, 0.5, 0.5);	
	return col;
}

float displacement(vec3 p)
{ 
    float final = noise(p);
	p *= 2.94; final += noise(p.xz) * 0.4;
	p *= 2.87; final += noise(p.xz) * 0.1;
	final += final * 0.005; // Compensate for mssing noise on low quality version
	return pow(final, 1.5) - 1.0;
}

float displacementHigh(vec3 p) 
{
	float final = noise(p); 
	p *= 2.94; final += noise(p.xz) * 0.1;
	p *= 2.87; final += noise(p.xz) * 0.1;
	p *= 2.97; final += noise(p) * final * 0.02;
	final = pow(final, 1.5);
	p *= 1.97; final += noise(p) * final * 0.007;
	p *= 1.99; final += noise(p) * final * 0.002;
	p *= 1.91; final += noise(p) * final * 0.0008;
	return final - 1.0;
}

float mapTerrain(vec3 p)
{
    return p.y - displacement(p * 0.006) * 80.0 + 55.0;
}

float mapTerrainHigh(vec3 p)
{
    return p.y - displacementHigh(p * 0.006) * 80.0 + 55.0;
}

float raymarchTerrain(vec3 ro, vec3 rd)
{
    float maxd = (ro.y - 200.0) / rd.y;
    float precis = 0.001;
    float h = 1.0;
    float t = (ro.y - 10.0) / rd.y;
    vec3 p = vec3(0.0);

    for(int i=0;i<MAX_RAYMARCH_ITER;i++)
    {
        if(abs(h) < precis || t > maxd) 
            break;
       
        p = ro + rd * t;
        h = mapTerrain(p);
        t += h;
    }

    float st = t*0.5;
    float bt = st;
    for (int i = 0; i < MAX_BINARY_ITERS; i++) 
    {
        p = ro + rd * bt;
        h = mapTerrain(p);
        if (abs(h) < 0.0001) break;
        st *= sign(h) * sign(st) * 0.5;
        bt += st;
    }

    if(bt > maxd || bt > 3000.0) t=-1.0;
    return bt;
}

//Code from iq.
vec3 calcNormal(vec3 pos)
{
    vec3 eps = vec3(precis,0.0,0.0);
    vec3 nor;
    nor.x = mapTerrain(pos+eps.xyy) - mapTerrain(pos-eps.xyy);
    nor.y = mapTerrain(pos+eps.yxy) - mapTerrain(pos-eps.yxy);
    nor.z = mapTerrain(pos+eps.yyx) - mapTerrain(pos-eps.yyx);
    return normalize(nor);
}

//Code from iq.
vec3 calcNormalHigh(vec3 pos)
{
    vec3 eps = vec3(precis,0.0,0.0);
    vec3 nor;
    nor.x = mapTerrainHigh(pos+eps.xyy) - mapTerrainHigh(pos-eps.xyy);
    nor.y = mapTerrainHigh(pos+eps.yxy) - mapTerrainHigh(pos-eps.yxy);
    nor.z = mapTerrainHigh(pos+eps.yyx) - mapTerrainHigh(pos-eps.yyx);
    return normalize(nor);
}

vec3 terrainColor(vec3 ro, vec3 rd, float t, vec3 p)
{
    vec3 col = vec3(0.0);
    float waterT = (ro.y - waterHeight) / rd.y;

    vec3 fogColor = fogColor(rd);
    float fogT = min(waterT, t) / 1000.0;
    float density = 0.5;
    float fogFactor = clamp(exp2(-density * density * fogT * fogT * LOG2), 0.0, 1.0);

    if(fogFactor < 0.002)
    {
        return fogColor;
    }

    vec3 norm = calcNormalHigh(p);
    vec3 albedo = vec3(0.996, 0.835, 0.494);
    if (waterT > t) 
    {
		float snowThresh = 1.0 - smoothstep(-50.0, -40.0, p.y) * 0.4 + 0.1;
		float grassThresh = smoothstep(-70.0, -30.0, p.y) * 0.3 + 0.75;
		
		if (norm.y < 0.65)
			albedo = mix(albedo, vec3(1.0, 1.0, 1.0), smoothstep(0.65,0.55,norm.y));
		if (norm.y > grassThresh - 0.05)
			albedo = mix(albedo, vec3(0.027, 0.333, 0.192), smoothstep(grassThresh-0.05,grassThresh+0.05, norm.y));
		if (norm.y > snowThresh - 0.05)
			albedo = mix(albedo, vec3(0.5, 0.5, 0.5), smoothstep(snowThresh-0.05,snowThresh+0.05, norm.y));
	}

    float diff = clamp(dot(norm, lightDir), 0.0, 1.0);
    col += albedo * diff * vec3(1.0, 0.9, 0.8);
    col += mix(fogColor, col, fogFactor);

    if(t >= waterT)
    {
        float dist = t - waterT;
        col *= exp(-vec3(0.3, 0.15, 0.03)*dist);
    }

    return col;
}

vec4 render(vec3 screen)
{
    vec3 rayOrigin = vec3(0.0, 0.0, -1.0);
    vec3 rayPos = rayOrigin + vec3(iGlobalTime * 200.0, 5.0, cos(iGlobalTime * 0.5) * 800.0); 
    vec3 rayDir = normalize(screen - rayOrigin);
    rayDir = rotateY(rotateX(rayDir, 0.4), 0.0);

    vec4 finalCol = vec4(0.0);//textureCube(iChannel0, rayDir);

    float t = raymarchTerrain(rayPos, rayDir);
    if(t > 0.0)
    {
        finalCol = vec4(terrainColor(rayPos, rayDir, t, rayPos + rayDir * t), 1.0);
    }
    else
    {
        finalCol = vec4(fogColor(rayDir), 1.0);
    }

    return finalCol;
}

void main()
{
    vec2 uv = vec2((gl_FragCoord.x - iResolution.x *.5) / iResolution.y, 
                   (gl_FragCoord.y - iResolution.y *.5) / iResolution.y);
    

    gl_FragColor = render(vec3(uv, 0.0));
}