namespace Move_a_single_image_using_paint_MOO_ICT
{

    // Made by MOO ICT
    // For educational Purpose Only

    public partial class Form1 : Form
    {

        Image card;
        Point position = new Point(200,200);
        bool dragging;
        Rectangle rect;
        int height = 200, width = 100;



        public Form1()
        {
            InitializeComponent();

            card = Image.FromFile("guts.jpg");
            rect = new Rectangle(position.X, position.Y, width, height);

        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point(e.X, e.Y);
            if (rect.Contains(mousePosition))
            {
                dragging = true;
                label1.Text = "Dragging Image";
            }
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                position.X = e.X - (width / 2);
                position.Y = e.Y - (height / 2);
            }
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                dragging = false;
                rect.Location = new Point(e.X, e.Y);
                label1.Text = "Image dropped @ " + rect.Location.ToString();
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Pen outline;

            if (dragging)
            {
                outline = new Pen(Color.Yellow, 6);
            }
            else
            {
                outline = new Pen(Color.Plum, 6);
            }

            e.Graphics.DrawRectangle(outline, rect);
            e.Graphics.DrawImage(card, position.X, position.Y, width, height);

        }

        private void FormTimerEvent(object sender, EventArgs e)
        {
            rect.X = position.X;
            rect.Y = position.Y;

            this.Invalidate();
        }
    }
}