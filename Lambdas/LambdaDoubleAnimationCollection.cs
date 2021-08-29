using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPFanimationFuncProgram
{
    public class LambdaDoubleAnimationCollection : Collection<LambdaDoubleAnimation>
    {
        public LambdaDoubleAnimationCollection(int count, Func<int, double> from, Func<int, double> to,
            Func<int, Duration> duration, Func<int, Func<double, double>> valueGenerator)
        {
            for (var i = 0; i < count; i++)
            {
                var lda = new LambdaDoubleAnimation
                {
                    From = from(i),
                    To = to(i),
                    Duration = duration(i),
                    ValueGenerator = valueGenerator(i)
                };
                Add(lda);
            }
        }

        public void BeginApplyAnimation(UIElement[] targets, DependencyProperty property)
        {
            for (var i = 0; i < Count; i++)
            {
                targets[i].BeginAnimation(property, Items[i]);
            }
        }
    }
}