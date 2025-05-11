float normalizedTintAmount;
float3 colorToTintTowards;
sampler uImage0 : register(s0);

float4 tintShader(float4 color : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 currentColor = tex2D(uImage0, coords);
    float4 red = float4(colorToTintTowards.r, colorToTintTowards.g, colorToTintTowards.b, currentColor.a);
    currentColor = lerp(currentColor, red, normalizedTintAmount);
    return currentColor;
}

technique Technique1
{
    pass ShaderPass
    {
        PixelShader = compile ps_3_0 tintShader();
    }
}