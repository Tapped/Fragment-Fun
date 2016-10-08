using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragmentFun
{
	public enum GLSLType
	{
		INVALID,
		SINGLE,
		VEC2,
		VEC3,
		VEC4,
	}

	public struct GLSLTrack
	{
		public readonly List<DotRocket.Track> Tracks;

		public readonly string Name;
		public readonly GLSLType Type;

		public GLSLTrack(string name, GLSLType type, DotRocket.Device rocket)
		{
			Name = name;
			Type = type;
			Tracks = new List<DotRocket.Track>();

			switch (type)
			{
				case GLSLType.SINGLE:
					Tracks.Add(rocket.GetTrack(Name));
					break;
				case GLSLType.VEC2:
					Tracks.Add(rocket.GetTrack(Name + ".x"));
					Tracks.Add(rocket.GetTrack(Name + ".y"));
					break;
				case GLSLType.VEC3:
					Tracks.Add(rocket.GetTrack(Name + ".x"));
					Tracks.Add(rocket.GetTrack(Name + ".y"));
					Tracks.Add(rocket.GetTrack(Name + ".z"));
					break;
				case GLSLType.VEC4:
					Tracks.Add(rocket.GetTrack(Name + ".x"));
					Tracks.Add(rocket.GetTrack(Name + ".y"));
					Tracks.Add(rocket.GetTrack(Name + ".z"));
					Tracks.Add(rocket.GetTrack(Name + ".w"));
					break;
				default:
					break;
			}
		}
	}
}
