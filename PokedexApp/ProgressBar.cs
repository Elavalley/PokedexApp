using System.Numerics;
using Microsoft.Maui.Controls;


namespace PokedexApp
{
public class ProgressBar : Grid
{
private Microsoft.Maui.Controls.ProgressBar _progressBar;
private Label _label;

public static readonly BindableProperty ProgressProperty =
BindableProperty.Create(nameof(Progress), typeof(double), typeof(ProgressBar), 0.0, propertyChanged: OnProgressChanged);

public double Progress
{
get => (double)GetValue(ProgressProperty);
set => SetValue(ProgressProperty, value);
}
public double MaxValue
{
    get; set;
}


public ProgressBar()
{
_progressBar = new Microsoft.Maui.Controls.ProgressBar();
_label = new Label { HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center };

Children.Add(_progressBar);
Children.Add(_label);
}

private static void OnProgressChanged(BindableObject bindable, object oldValue, object newValue)
{
var control = (ProgressBar)bindable;
control.UpdateProgress();
}

private void UpdateProgress()
{
_progressBar.Progress = Progress;
_label.Text = $"{(Progress * 100):F0}%";
}
}
}