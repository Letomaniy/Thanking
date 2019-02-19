﻿using Thinking.Attributes;

namespace Thinking.Options
{
    public static class OptimizationOptions
    {
        [Save] public static int PacketRefreshRate = 50;
        [Save] public static int InputSamples;
    }
}