using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {

        int divideByZeroFlag = 0;
        int errorFlag = 0;
        public Form1()
        {
            InitializeComponent();
            this.textBox1.Text = "0";
            this.symbols = new List<char> { '+', '/', '-', '(', ')', '^', '!', '-', 'x', '*' };
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(form1_KeyDown);


        }
        void form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 48:
                    button23.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 49:
                    button20.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 50:
                    button19.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 51:
                    button17.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 52:
                    button16.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 53:
                    button15.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 54:
                    button13.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 55:
                    button12.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 56:
                    button11.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 57:
                    button9.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 127:
                case 8:
                    button8.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 42:
                    button10.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 45:
                    button14.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 40:
                    button26.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 41:
                    button25.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 47:
                    button7.PerformClick();  // This will call the button1_Click event handler
                    break;
                case 43:
                    button18.PerformClick();  // This will call the button1_Click event handler
                    break;

    
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int length = this.textBox1.Text.Length - 1;
            foreach (char symbol in symbols)
            {
                if (this.textBox1.Text[length] == symbol && symbol != ')')
                {
                    this.textBox1.Text += "Sqrt(";
                    return;
                }
            }
            string text = getNum();
            this.textBox1.Text += "Sqrt(" + text + ")";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newOperator();
            this.textBox1.Text += "^2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newOperator();
            this.textBox1.Text += "^";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newOperator();
            string text = getNum(); this.textBox1.Text += "1/" + text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear();
            isTextBoxEmpty();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (isOpenParantheses())
            {
                this.textBox1.Text += "0";
            }
            newOperator();
            checkForDot();
            this.textBox1.Text += "-";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length >= 1)
            {
                if (this.textBox1.Text[0] == '-')
                {
                    this.textBox1.Text = this.textBox1.Text.Insert(0, "0");
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.textBox2.Text += this.textBox1.Text + Environment.NewLine;
            string text = this.textBox1.Text;
            text = SQRT(text);
            text = text.Replace("+", " + ");
            text = text.Replace("-", " - ");
            text = text.Replace("/", " / ");
            text = text.Replace("*", " * ");
            text = text.Replace("(", " ( ");
            text = text.Replace(")", " ) ");
            text = text.Replace("^", " ^ ");
            this.textBox1.Text = evaluate(text).ToString();

            if (divideByZeroFlag == 1)
            {
                this.textBox1.Text = "0";
                divideByZeroFlag = 0;
            }
            if (errorFlag == 1)
            {
                this.textBox1.Text = "0";
                this.textBox2.Text += "Error" + Environment.NewLine;
                errorFlag = 0;
            }
           
        
        }


        
       
        private int paranthesesCount()
        {
            int length = this.textBox1.Text.Length - 1;
            int numOfParanthesis = 0;
            while (true)
            {
                length--;
                if (length > -1)
                {
                    if (this.textBox1.Text[length] == ')')
                    {
                        numOfParanthesis--;
                    }
                    else if (this.textBox1.Text[length] == '(')
                    {
                        numOfParanthesis++;
                    }

                }
                else
                {
                    return numOfParanthesis;
                }
            }
        }

        private int paranthesesCheck()
        {
            int length = this.textBox1.Text.Length - 1;
            if (this.textBox1.Text[length] == ')')
            {
                int paranthesesCount = -1;
                while (paranthesesCount != 0)
                {
                    length--;
                    if (length > -1)
                    {
                        if (this.textBox1.Text[length] == ')')
                        {
                            paranthesesCount--;
                        }
                        else if (this.textBox1.Text[length] == '(')
                        {
                            paranthesesCount++;
                        }

                    }
                    else
                    {
                        return -1;
                    }
                }
                if (length > 0)
                {
                    if (this.textBox1.Text[length - 1] == 't')
                    {
                        length -= 4;
                    }
                }
                return length;
            }
            return -2;
        }

        private int paranthesesCheckForward(int position)
        {
            int length = 0;
            if (this.textBox1.Text[position + length] == '(')
            {
                int paranthesesCount = 1;
                while (paranthesesCount != 0)
                {
                    length++;
                    if (position + length < this.textBox1.Text.Length)
                    {
                        if (this.textBox1.Text[position + length] == ')')
                        {
                            paranthesesCount--;
                        }
                        else if (this.textBox1.Text[position + length] == '(')
                        {
                            paranthesesCount++;
                        }

                    }
                }
            }
            return length;
        }

        private string getNum()
        {
            newOperator();
            string num = "";
            int length = this.textBox1.Text.Length - 1;
            if (this.textBox1.Text[length] == ')')
            {

                int position = paranthesesCheck();
                num = getPosition(position);
                return num;
            }


            while (length > -1)
            {
                foreach (char symbol in this.symbols)
                {
                    if (this.textBox1.Text[length] == symbol)
                    {
                        deleteNum(length);
                        return new string(num.Reverse().ToArray());
                    }
                }
                num += this.textBox1.Text[length];
                length--;
            }
            deleteNum(length);
            return new string(num.Reverse().ToArray());
        }

        private void newOperator()
        {
            int length = (this.textBox1.Text.Length) - 1;
            if (this.textBox1.Text[length] == ')')
            {
                return;
            }

            foreach (char symbol in this.symbols)
            {
                if (this.textBox1.Text[length] == symbol)
                {
                    removeLastChar();
                    return;
                }
            }
        }

        private void clearNum()
        {
            int length = this.textBox1.Text.Length - 1;
            foreach (char symbol in symbols)
            {
                if (this.textBox1.Text[length] == symbol)
                {
                    removeLastChar();
                    return;
                }
            }
            getNum();
        }

        private void clear()
        {
            this.textBox1.Clear();
        }

        private void isTextBoxEmpty()
        {
            if (this.textBox1.Text == null || this.textBox1.Text == String.Empty)
            {
                this.textBox1.Text = "0";
            }
        }

        private void textBoxEmpty()
        {
            this.textBox1.Text = "";
        }

        private void removeLastChar()
        {
            int length = this.textBox1.Text.Length - 1;

            if (length > 0)
            {
                if (this.textBox1.Text[length - 1] == 't')
                {
                    deleteNum(length - 5);
                    return;
                }
            }

            this.textBox1.Text = this.textBox1.Text.Remove(length);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearNum();
            isTextBoxEmpty();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            removeLastChar();
            isTextBoxEmpty();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            checkForDot();
            if (replaceZero())
            {
                this.textBox1.Text = "(";
            }
            else
            {
                this.textBox1.Text += "(";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int length = this.textBox1.Text.Length - 1;
            if (this.textBox1.Text[length] == '(') {
                this.textBox1.Text += "0";
            }
            newOperator();
            checkForDot();
            this.textBox1.Text += ")";
        }

        private bool isOpenParantheses()
        {
            int length = this.textBox1.Text.Length - 1;
            if (this.textBox1.Text[length] == '(')
                return true;
            return false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isOpenParantheses())
            {
                this.textBox1.Text += "0";

            }
            newOperator();
            checkForDot();

            this.textBox1.Text += "/";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isOpenParantheses())
            {
                this.textBox1.Text += "0";

            }
            newOperator();
            checkForDot();

            this.textBox1.Text += "*";

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (isOpenParantheses())
            {
                this.textBox1.Text += "0";

            }
            newOperator();
            checkForDot();

            this.textBox1.Text += "+";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "8";
            }
            else
            {
                this.textBox1.Text += "8";
            }
        }

        private bool replaceZero()
        {
            if (this.textBox1.Text == "0")
            {
                return true;
            }
            return false;
        }

        private void deleteNum(int position)
        {
            position++;
            if (position != -1)
            {
                this.textBox1.Text = this.textBox1.Text.Remove(position);
            }
            else
            {
                textBoxEmpty();
            }
        }

        private string getPosition(int position)
        {

            string text = this.textBox1.Text.Substring(position, (this.textBox1.Text.Length) - position);

            deleteNum(position - 1);
            return text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "7";
            }
            else
            {
                this.textBox1.Text += "7";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "9";
            }
            else
            {
                this.textBox1.Text += "9";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "4";
            }
            else
            {
                this.textBox1.Text += "4";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "5";
            }
            else
            {
                this.textBox1.Text += "5";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "6";
            }
            else
            {
                this.textBox1.Text += "6";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "1";
            }
            else
            {
                this.textBox1.Text += "1";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "2";
            }
            else
            {
                this.textBox1.Text += "2";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "3";
            }
            else
            {
                this.textBox1.Text += "3";
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (replaceZero())
            {
                this.textBox1.Text = "0";
            }
            else
            {
                this.textBox1.Text += "0";
            }
        }

 
        private void button21_Click(object sender, EventArgs e)
        {
            int length = this.textBox1.Text.Length - 1;
            foreach (char symbol in symbols)
            {
                if (this.textBox1.Text[length] == symbol)
                {
                    this.textBox1.Text += "0.";
                    return;
                }
            }
            string dotCheck = doubleDot();
            this.textBox1.Text += dotCheck;
        }

        private void checkForDot()
        {
            int length = this.textBox1.Text.Length - 1;
            if (this.textBox1.Text[length] == '.')
            {
                this.textBox1.Text += "0";
                return;
            }
        }

        private string doubleDot()
        {
            string text = getNum();
            foreach (char x in text)
            {
                if (x == '.')
                {
                    return text;
                }
            }

            return text + ".";
        }

        private string SQRT(string input)
        {
            int position = input.IndexOf("Sqrt");
            string text = "";
            int length;
            while (position > -1)
            {
                length = paranthesesCheckForward(position + 4);
                input = input.Remove(position, 4).Insert(position,"(");
                input = input.Insert(position+length+1, ")^(1/2)");
                position = input.IndexOf("Sqrt");
                this.textBox1.Text = input;
            }

            //            input

            return input;
        }

        private double evaluate(string expression)
        {
            char[] tokens = expression.ToCharArray();

            // Stack for numbers: 'values'  
            Stack<double> values = new Stack<double>();

            // Stack for Operators: 'ops'  
            Stack<char> ops = new Stack<char>();

            for (int i = 0; i < tokens.Length; i++)
            {
                // Current token is a whitespace, skip it  
                if (tokens[i] == ' ')
                {
                    continue;
                }

                // Current token is a number, push it to stack for numbers  
                if ((tokens[i] >= '0' && tokens[i] <= '9') || tokens[i] == '.')
                {
                    StringBuilder sbuf = new StringBuilder();
                    // There may be more than one digits in number  
                    while (i < tokens.Length && ((tokens[i] >= '0' && tokens[i] <= '9') || tokens[i] == '.'))
                    {
                        sbuf.Append(tokens[i++]);
                    }
                    values.Push(double.Parse(sbuf.ToString()));
                }

                // Current token is an opening brace, push it to 'ops'  
                else if (tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }

                // Closing brace encountered, solve entire brace  
                else if (tokens[i] == ')')
                {
                    try {
                        while (ops.Peek() != '(')
                        {
                            values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                        }
                        ops.Pop();
                    }
                    catch(Exception e)
                    {
                        errorFlag = 1;
                        return 0;
                    }
                }

                // Current token is an operator.  
                else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/' || tokens[i] == '^')
                {
                    // While top of 'ops' has same or greater precedence to current  
                    // token, which is an operator. Apply operator on top of 'ops'  
                    // to top two elements in values stack  
                    while (ops.Count > 0 && hasPrecedence(tokens[i], ops.Peek()))
                    {
                        values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }

                    // Push current token to 'ops'.  
                    ops.Push(tokens[i]);
                }
            }

            // Entire expression has been parsed at this point, apply remaining  
            // ops to remaining values  
            while (ops.Count > 0)
            {
                try
                {
                    values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                }
                catch(Exception error)
                {
                    values.Push(0);
                    errorFlag = 1;
                    break;
                }
            }

            // Top of 'values' contains result, return it  
            return values.Pop();
        }

        // Returns true if 'op2' has higher or same precedence as 'op1',  
        // otherwise returns false.  
        private static bool hasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if (op1 == '^' && (op2 == '*' || op2 == '/' || op2 == '+' || op2 == '-')) {
                return false;
            }
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private double applyOp(char op, double b, double a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        divideByZeroFlag = 1;
                        this.textBox2.Text += "Cannot Divide by zero" + Environment.NewLine;
                        return 0;
                    }
                    return a / b;
                case '^':
                    return Math.Pow(a,b);
            }
            return 0;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string text =  "(0-" + getNum() + ")";
            this.textBox1.Text += text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
