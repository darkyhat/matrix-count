﻿namespace Net
{
    public class NetResult
    {
        public float[] Net1 { get; set; }
        public float[] Out1 { get; set; }
        public float[] Net2 { get; set; }
        public float[] Out2 { get; set; }

        public NetResult(int size)
        {
            Net1 = new float[size];
            Net2 = new float[size];
            Out1 = new float[size];
            Out2 = new float[size];
        }
    }
}
