using Microsoft.Maui.Controls;

namespace EngeTerraPlan.Behaviors
{
    public class DateFormatBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry == null)
                return;

            // Validação e formatação
            if (DateTime.TryParse(e.NewTextValue, out DateTime parsedDate))
            {
                entry.Text = parsedDate.ToString("dd/MM/yyyy");
            }
        }
    }
}
