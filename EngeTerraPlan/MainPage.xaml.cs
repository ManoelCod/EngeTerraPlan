namespace EngeTerraPlan;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} tese";
		else
			CounterBtn.Text = $"Clicked {count} teste";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

