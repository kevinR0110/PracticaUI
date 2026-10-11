namespace PracticaUI;

public partial class CalculadoraIMC : ContentPage
{
    public CalculadoraIMC()
    {
        InitializeComponent();
    }

    //"async" porque DisplayAlert espera que el usuario toque el OK
    private async void Button_clicked(object sender, EventArgs e)
    {
        //TryParse intenta convertir el texto a numero
        //Tambien validamos que la altura sea mayor que 0 (evita dividir entre cero)
        if (!double.TryParse(txtPeso.Text, out double peso) ||
            !double.TryParse(txtAltura.Text, out double altura) || altura <= 0)
        {
            await DisplayAlert("Error", "Por favor ingrese valores numericos validos.", "OK");
            return;

        }
        //Formula del IMC: Peso/ (Altura^2)
        double imc = peso / (altura * altura);

        //Formato con 1 decimal (ejemplo 22.9)
        lblValorIMC.Text = imc.ToString("F1");

        //Clasificamos el imc y cambiamos texto y colores segun el rango
        if (imc < 18.5)
        {
            lblDiagnostico.Text = "Bajo Peso";
            lblDiagnostico.TextColor = Colors.DarkOrange;

            //color.FromArgb convierte un codigo hexadecimal en un color 
            brResultado.BackgroundColor = Color.FromArgb("0B8711");
            brResultado.Stroke = Colors.Orange;
        }
        else if (imc <= 24.9)
        {
            lblDiagnostico.Text = "Peso Normal";
            lblDiagnostico.TextColor = Colors.DarkCyan;

            //color.FromArgb convierte un codigo hexadecimal en un color 
            brResultado.BackgroundColor = Color.FromArgb("0B9011");
            brResultado.Stroke = Colors.Blue;
        }
        else if (imc <= 29.9)
        {
            lblDiagnostico.Text = "Sobrepeso";
            lblDiagnostico.TextColor = Colors.DarkMagenta;

            //color.FromArgb convierte un codigo hexadecimal en un color 
            brResultado.BackgroundColor = Color.FromArgb("0B7011");
            brResultado.Stroke = Colors.Magenta;
        }
        else
        {
            lblDiagnostico.Text = "Obesidad";
            lblDiagnostico.TextColor = Colors.DarkRed;

            //color.FromArgb convierte un codigo hexadecimal en un color 
            brResultado.BackgroundColor = Color.FromArgb("0B4011");
            brResultado.Stroke = Colors.Red;
        }

        //Por ultimo, muestra la tarjeta que estaba oculta 
        brResultado.IsVisible = true;
     }
}