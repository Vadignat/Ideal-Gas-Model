namespace gas_model_ideal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            p = new Painter(10, pictureBox1.Size);
        }
        private bool isClicked = false;
        private Painter p;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            p.Paint(e.Graphics,pictureBox1.Size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isClicked = !isClicked;
            button1.Text = isClicked ? "Стоп" : "Старт";
            timer1.Enabled = !timer1.Enabled;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p.AddFigure(e.X, e.Y, pictureBox1.CreateGraphics(), pictureBox1.Size);
        }

        private void pictureBox1_Layout(object sender, LayoutEventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}