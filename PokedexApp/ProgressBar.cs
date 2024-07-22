namespace PokedexApp;
public class ProgressBar : Grid
{
    public static readonly BindableProperty ProgressProperty =
        BindableProperty.Create(nameof(Progress), typeof(double), typeof(ProgressBar), 0.0, propertyChanged: OnProgressChanged);

    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(MaxValue), typeof(double), typeof(ProgressBar), 200.0, propertyChanged: OnProgressChanged);

    public double Progress
    {
        get => (double)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    private ProgressBar _progressBar;
    private Label _label;

    public ProgressBar()
    {
        _progressBar = new ProgressBar();
        _label = new Label { HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center };

        Children.Add(_progressBar);
        Children.Add(_label);
    }

    private static void OnProgressChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ProgressBar)bindable;
        control.UpdateControl();
    }

    private void UpdateControl()
    {
        _progressBar.Progress = Progress / MaxValue;
        _label.Text = $"{Progress:F0}/{MaxValue:F0}";
    }
}