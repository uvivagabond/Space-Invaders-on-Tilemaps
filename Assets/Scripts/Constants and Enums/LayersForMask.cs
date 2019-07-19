using System;

public static class LayersForMask
{
	public const int Everything = -1;
	public const int Nothing = 0;
	public const int Default  = 1<<0;
	public const int TransparentFX  = 1<<1;
	public const int IgnoreRaycast  = 1<<2;
	public const int Water  = 1<<4;
	public const int UI  = 1<<5;

	public const int Enemies  = 1<<8;
	public const int Player  = 1<<9;
	public const int Borders  = 1<<10;
	public const int MissileStarship  = 1<<11;
	public const int MissileEnemy  = 1<<12;
	public const int Barriers  = 1<<13;
}
