using System;
using Avalonia.Animation;
using Ursa.Controls;

namespace Ursa.Demo.Controls;

public class CustomDisplayer: NumberDisplayer<string?>
{
    protected override Type StyleKeyOverride { get; } = typeof(NumberDisplayerBase);
    
    protected override InterpolatingAnimator<string?> GetAnimator()
    {
        return new StringAnimator();
    }
    private class StringAnimator : InterpolatingAnimator<string?>
    {
        public override string? Interpolate(double progress, string? oldValue, string? newValue)
        {
            int oldLength = oldValue?.Length ?? 0;
            int newLength = newValue?.Length ?? 0;
            if (progress == 0) return oldValue;
            else if (progress == 1) return newValue;
            int start = (int)(oldLength * progress);
            int length = Math.Min(oldLength, newLength);
            return (oldValue + newValue)?.Substring(start, newLength);
        }
    }
    protected override string GetString(string? value)
    {
        return value??string.Empty;
    }
}