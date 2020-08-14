using UnityEngine;

public static class ColorExtensions 
{
	public static Color DesaturatedAt(this Color color, float percents) 
	{
		percents /= 100;
		float luma  = 0.3f * color.r + 0.6f * color.g + 0.1f * color.b;
//		var luma = color.grayscale;
		
		var newColor = color;
		newColor.r += percents * (luma - color.r);
		newColor.g += percents * (luma - color.g);
		newColor.b += percents * (luma - color.b);

		return newColor;
	}
}