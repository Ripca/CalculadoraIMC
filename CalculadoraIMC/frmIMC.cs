using System.Data;

namespace CalculadoraIMC
{
    public partial class frmIMC : Form
    {
        public frmIMC()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
                double Estatura, Peso, IMC;
                string rangoDePeso = "", imcRango = "", NivelDePeso = "";

                Estatura = double.Parse(txtEstatura.Text);
                Peso = double.Parse(txtPeso.Text);

                IMC = Math.Round(Peso / (Math.Pow(Estatura, 2)), 2);

                lblResultado.Text = "Tu imc es: " + IMC;

                if (IMC < 18.5)
                {
                    rangoDePeso = "124 lb o menos";
                    imcRango = "Por debajo de 18.5";
                    NivelDePeso = "Bajo peso";
                }
                else if (IMC >= 18.5 && IMC <= 24.9)
                {
                    rangoDePeso = "125 a 168 lb";
                    imcRango = "18.5 a 24.9 ";
                    NivelDePeso = "Normal";
                }
                else if (IMC >= 25 && IMC <= 29.9)
                {
                    rangoDePeso = "169 lb a 202 lb";
                    imcRango = "25.0 a 29.9";
                    NivelDePeso = "Sobrepaso";
                }
                else if (IMC >= 30)
                {
                    rangoDePeso = "203 lb o mas";
                    imcRango = "30 o más";
                    NivelDePeso = "Obesidad";
                }

                //Creacion de tabla para luego colocarse al DataGridView


                DataTable tabla = new DataTable();
                tabla.Columns.Add("Estatura", typeof(string));
                tabla.Columns.Add("Rango de peso", typeof(string));
                tabla.Columns.Add("IMC", typeof(string));
                tabla.Columns.Add("Nivel de peso", typeof(string));

                tabla.Rows.Add(Estatura + " m", rangoDePeso, imcRango, NivelDePeso);
                dgvIMC.DataSource = tabla;
            }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile("imc.png");
            ptbImage.Image = image;
            ptbImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}