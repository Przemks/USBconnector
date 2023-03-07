using System;
using System.IO.Ports;
using System.Windows.Forms;

class Program : Form
{
    private SerialPort port;
    private Button button;

    public Program()
    {
        port = new SerialPort(); // otwieramy port COM1 z prędkością 9600 bps
        port.PortName = "COM1";
        port.BaudRate = 19200;
        port.DataBits = 8;
        port.Parity = Parity.None;
        port.StopBits = StopBits.One;

        port.Open(); // otwieramy port

        button = new Button();
        button.Text = "Wyslij sygnal 5V przez USB";
        button.Click += new EventHandler(Button_Click);

        this.Controls.Add(button);
    }

    private void Button_Click(object sender, EventArgs e)
    {
        port.Write("1"); // wysyłamy sygnał 5V
        System.Threading.Thread.Sleep(500); // opóźnienie 500ms
        port.Write("0"); // zatrzymujemy wysyłanie sygnału 5V
    }

    static void Main(string[] args)
    {
        Application.Run(new Program());
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        port.Close(); // zamykamy port
    }
}
