using System;
using System.Windows.Media.Animation;

namespace WPFanimationFuncProgram
{
    public class LambdaDoubleAnimation : DoubleAnimation
    {
        public Func<double, double> ValueGenerator { get; set; }
        protected override double GetCurrentValueCore(double defaultOriginValue, double defaultDestinationValue, AnimationClock animationClock)
        {
            return ValueGenerator(base.GetCurrentValueCore(defaultOriginValue, defaultDestinationValue, animationClock));
        }
    }
}