using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFanimationFuncProgram
{
    public class LambdaCollection<T> : Collection<T>
      where T : DependencyObject, new()
    {
        public LambdaCollection(int count)
        {
            while (count-- > 0)
            {
                Add(new T());
            }
        }

        public LambdaCollection<T> WithProperty<TU>(DependencyProperty property, Func<int, TU> generator)
        {
            for (var i = 0; i < Count; i++)
            {
                this[i].SetValue(property, generator(i));
            }

            return this;
        }

        public LambdaCollection<T> WithXy<TU>(Func<int, TU> xGen, Func<int, TU> yGen)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].SetValue(Canvas.LeftProperty, xGen(i));
                this[i].SetValue(Canvas.TopProperty, yGen(i));
            }

            return this;
        }
    }
}