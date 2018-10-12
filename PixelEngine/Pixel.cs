﻿using System;

namespace PixelEngine
{
	public struct Pixel
	{
		public byte R { get; private set; }
		public byte G { get; private set; }
		public byte B { get; private set; }
		public byte A { get; private set; }

		public Pixel(byte red, byte green, byte blue, byte alpha = 255)
		{
			R = red;
			G = green;
			B = blue;
			A = alpha;
		}

		public enum Mode
		{
			Normal,
			Mask,
			Alpha
		}

		public static Pixel Random()
		{
			byte[] vals = MathHelper.RandomBytes(3);
			return new Pixel(vals[0], vals[1], vals[2]);
		}
		public static Pixel RandomAlpha()
		{
			byte[] vals = MathHelper.RandomBytes(4);
			return new Pixel(vals[0], vals[1], vals[2], vals[3]);
		}

		#region Presets
		public enum Presets : uint
		{
			White = 0xffffff,
			Grey = 0xa9a9a9,
			Red = 0xff0000,
			Yellow = 0xffff00,
			Green = 0x00ff00,
			Cyan = 0x00ffff,
			Blue = 0x0000ff,
			Magenta = 0xff00ff,
			Brown = 0x9a6324,
			Orange = 0xf58231,
			Purple = 0x911eb4,
			Lime = 0xbfef45,
			Pink = 0xfabebe,
			Teal = 0x469990,
			Lavender = 0xe6beff,
			Beige = 0xfffac8,
			Maroon = 0x800000,
			Mint = 0xaaffc3,
			Olive = 0x808000,
			Apricot = 0xffd8b1,
			Navy = 0x000075,
			Black = 0x000000,
		} 

		public static readonly Pixel Empty = new Pixel(0, 0, 0, 0);
		#endregion

		public static bool operator ==(Pixel a, Pixel b) => (a.A == b.A) && (a.R == b.R) && (a.G == b.G) && (a.B == b.B);
		public static bool operator !=(Pixel a, Pixel b) => !(a == b);

		public static implicit operator Pixel(Presets p)
		{
			string hex = p.ToString("X");

			byte r = (byte)Convert.ToUInt32(hex.Substring(2, 2), 16);
			byte g = (byte)Convert.ToUInt32(hex.Substring(4, 2), 16);
			byte b = (byte)Convert.ToUInt32(hex.Substring(6, 2), 16);

			return new Pixel(r, g, b);
		}

		public override bool Equals(object obj)
		{
			if (obj is Pixel p)
				return this == p;
			return false;
		}
		public override int GetHashCode()
		{
			int hashCode = 1960784236;
			hashCode = hashCode * -1521134295 + R.GetHashCode();
			hashCode = hashCode * -1521134295 + G.GetHashCode();
			hashCode = hashCode * -1521134295 + B.GetHashCode();
			hashCode = hashCode * -1521134295 + A.GetHashCode();
			return hashCode;
		}
	}
}