using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragmentFun
{
    public struct GLSLTrack
    {
        public readonly List<DotRocket.Track> Tracks;

        public readonly string Name;

        public GLSLTrack(string name, DotRocket.Device rocket, params string []trackValues)
        {
            Name = name;
            Tracks = new List<DotRocket.Track>();
            foreach(var trackValue in trackValues)
            {
                Tracks.Add(rocket.GetTrack(Name + '.' + trackValue));
            }
        }
    }
}
