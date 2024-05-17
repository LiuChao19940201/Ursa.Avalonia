using System;
using Avalonia.Animation;
using Ursa.Controls;

namespace Ursa.Demo.Controls;

public class CustomDisplayer: NumberDisplayer<double>
{
    protected override Type StyleKeyOverride { get; } = typeof(NumberDisplayerBase);
    
    protected override InterpolatingAnimator<double> GetAnimator()
    {
        return new DoubleAnimator();
    }
    private class DoubleAnimator : InterpolatingAnimator<double>
    {
        public override double Interpolate(double progress, double oldValue, double newValue)
        {
            return oldValue + (newValue - oldValue) * progress;
        }
    }
    protected override string GetString(double value)
    {
        return value.ToString(StringFormat);
    }
}