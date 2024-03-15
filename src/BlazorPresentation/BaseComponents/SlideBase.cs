using Microsoft.AspNetCore.Components;

namespace BlazorPresentation.BaseComponents;

public class SlideBase : ComponentBase
{
    public override Task SetParametersAsync(ParameterView parameters)
    {
        if (parameters.TryGetValue(nameof(SlideStopIndex), out int? value))
        {
            if (IsCurrent && value is not null)
            {
                if (value < 0)
                {
                    OnDecrementSlide.InvokeAsync();
                }
                else if (value > SlideStopMax)
                {
                    OnIncrementSlide.InvokeAsync();
                }
            }
        }

        return base.SetParametersAsync(parameters);
    }

    public virtual int SlideStopMax { get; set; } = 0;

    [Parameter]
    public bool IsCurrent { get; set; } = false;

    [Parameter]
    public int SlideStopIndex { get; set; } = 0;

    [Parameter]
    [EditorRequired]
    public EventCallback OnIncrementSlide { get; set; }

    [Parameter]
    [EditorRequired]
    public EventCallback OnDecrementSlide { get; set; }

    protected string ShowSlideStopElement(int index)
    {
        if (index <= SlideStopIndex)
        {
            return "stop-element show";
        }
        return "stop-element hide";
    }
}
