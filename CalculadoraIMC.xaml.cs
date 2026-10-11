namespace PracticaUI;

public partial class CalculadoraIMC : ContentPage
{
    public CalculadoraIMC()
    {
        InitializeComponent();
    }
    //Prueba
    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Validar peso y altura > 0
        if (!double.TryParse(txtPeso.Text, out double peso) || peso <= 0 ||
            !double.TryParse(txtAltura.Text, out double altura) || altura <= 0)
        {
            await DisplayAlert("ERROR...", "Por Favor, Ingrese Valores Numéricos Válidos (mayores que 0)...", "OK");
            return;
        }

        double IMC = peso / (altura * altura);
        lblValorIMC.Text = IMC.ToString("F1");

        if (IMC < 18.5)
        {
            lblDiagnostico.Text = "BAJO PESO.";
            lblDiagnostico.TextColor = Colors.DarkBlue;
            brResultado.BackgroundColor = Colors.LightBlue;
            brResultado.Stroke = Colors.Blue;
            lblRango.Text = "Menor a 18.5";
        }
        else if (IMC <= 24.9)
        {
            lblDiagnostico.Text = "Peso Normal.";
            lblDiagnostico.TextColor = Colors.DarkCyan;
            brResultado.BackgroundColor = Colors.LightGreen;
            brResultado.Stroke = Colors.Cyan;
            lblRango.Text = "Entre 18.5 y 24.9";
        }
        else if (IMC <= 29.9)
        {
            lblDiagnostico.Text = "Sobrepeso.";
            lblDiagnostico.TextColor = Colors.DarkOrange;
            brResultado.BackgroundColor = Colors.LightYellow;
            brResultado.Stroke = Colors.Orange;
            lblRango.Text = "Entre 25.0 y 29.9";
        }
        else
        {
            lblDiagnostico.Text = "Obesidad.";
            lblDiagnostico.TextColor = Colors.DarkRed;
            brResultado.BackgroundColor = Colors.LightPink;
            brResultado.Stroke = Colors.Red;
            lblRango.Text = "30.0 o más";
        }
        brResultado.IsVisible = true;
    }
}
