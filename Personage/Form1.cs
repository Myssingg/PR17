using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        List<Weapon> _weapons = new List<Weapon> { };
        List<Personage> _pers = new List<Personage>{};
        string _pathWeapon;
        string _pathChar;
        int _countWeapon=0;
        int _countChar = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*. BMP, *.JPG," + "*.GIF, *.PNG) |*.bmp; *.jpg; *.gif; *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    Bitmap bmp = new Bitmap(image);
                    pictureBox1.Image = bmp;
                    _pathChar = Path.GetFileName(dialog.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string charName = textBox2.Text;
                int charLvl = Convert.ToInt32(textBox3.Text);
                int charStr = Convert.ToInt32(textBox4.Text);
                int charDex = Convert.ToInt32(textBox5.Text);
                int charInt = Convert.ToInt32(textBox6.Text);
                int index = comboBox1.SelectedIndex;
                string pathCH = _pathChar;
                Weapon weapon = _weapons[index];
                Personage per = new Personage(charName, charLvl, charStr, charDex, charInt, weapon,pathCH, weapon.lvl, weapon.damage);
                _pers.Add(per);
                int lastCount = _pers.Count() - 1;
                comboBox6.Items.Add(_pers[lastCount].GetInfo());
                button2.Enabled = true;
                StaticMetodsForPersonage_.Dexterity = charDex;
                StaticMetodsForPersonage_.Intellegence = charInt;
                StaticMetodsForPersonage_.Lvl = charLvl;
                StaticMetodsForPersonage_.Strength = charStr;
                StaticMetodsForPersonage_.Weapon = weapon;
                button8.Enabled = true;
                _countChar++;
                if(_countChar>=1)
                {
                    button7.Enabled = true;
                }

            }
            catch
            {
                int lastCountWeapon = _weapons.Count() - 1;
                int lastCountPers = _pers.Count();
                Weapon weapon = _weapons[lastCountWeapon];
                Personage per = new Personage(weapon);
                _pers.Add(per);
                comboBox6.Items.Add(_pers[lastCountPers].GetInfo());
                button8.Enabled = true;
                _countChar++;
                if (_countChar >= 1)
                {
                    button7.Enabled = true;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
            {
            try
            {
                string name = textBox7.Text;
                int lvl = Convert.ToInt32(textBox8.Text);
                int damage = Convert.ToInt32(textBox9.Text);
                string typeOfWeapon = comboBox4.Text;
                string path = _pathWeapon;
                Weapon weapon = new Weapon(name, lvl, damage, typeOfWeapon, path);
                _weapons.Add(weapon);
                int lastCount = _weapons.Count() - 1;
                listBox1.Items.Add(weapon.GerInfo());
                comboBox1.Items.Add(_weapons[lastCount].GerInfo());
                comboBox2.Items.Add(_weapons[lastCount].GerInfo());
                comboBox3.Items.Add(_weapons[lastCount].GerInfo());
                comboBox5.Items.Add(_weapons[lastCount].GerInfo());
                button2.Enabled = true;
                _countWeapon++;
                if (_countWeapon >= 2)
                {
                    button6.Enabled = true;
                    button4.Enabled = true;
                }
            }
            catch
            {             
                Weapon weapon = new Weapon();
                _weapons.Add(weapon);
                int lastCount = _weapons.Count() - 1;
                listBox1.Items.Add(_weapons[lastCount].GerInfo());
                comboBox1.Items.Add(_weapons[lastCount].GerInfo());
                comboBox2.Items.Add(_weapons[lastCount].GerInfo());
                comboBox3.Items.Add(_weapons[lastCount].GerInfo());
                comboBox5.Items.Add(_weapons[lastCount].GerInfo());
                button2.Enabled = true;
                _countWeapon++;
                if (_countWeapon >= 2)
                {
                    button6.Enabled = true;
                    button4.Enabled = true;
                }
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int index = comboBox2.SelectedIndex;
                int index2 = comboBox3.SelectedIndex;
                if (_weapons[index].typeWeapon == _weapons[index2].typeWeapon)
                {
                    _weapons.Add(_weapons[index] += _weapons[index2]);
                    int lastCount = _weapons.Count() - 1;
                    listBox1.Items.Add(_weapons[lastCount].GerInfo());
                    comboBox1.Items.Add(_weapons[lastCount].GerInfo());
                    comboBox2.Items.Add(_weapons[lastCount].GerInfo());
                    comboBox3.Items.Add(_weapons[lastCount].GerInfo());
                    comboBox5.Items.Add(_weapons[lastCount].GerInfo());
                }
                else
                {
                    MessageBox.Show("Типы оружия не совпадают");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*. BMP, *.JPG," + "*.GIF, *.PNG) |*.bmp; *.jpg; *.gif; *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    Bitmap bmp = new Bitmap(image);
                    pictureBox2.Image = bmp;                    
                    _pathWeapon = Path.GetFileName(dialog.FileName);
                    button3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = comboBox5.SelectedIndex;
            Image image = Image.FromFile(_weapons[index].pathWeapon);
            Bitmap bmp = new Bitmap(image);
            pictureBox2.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = comboBox6.SelectedIndex;
            Image image = Image.FromFile(_pers[index].pathChar);
            Bitmap bmp = new Bitmap(image);
            pictureBox1.Image = bmp;
            int power_pers = (((_pers[index].strenght + _pers[index].dexterity + _pers[index].intellegence) * _pers[index].lvl) + (_pers[index].weapons.lvl * _pers[index].weapons.damage));
            
            MessageBox.Show($"Звание персонажа:  {StaticMetodsForPersonage_.Power(_pers[index])} Мощность равна:{power_pers}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            string result = StaticMetodsForPersonage_.StrongPers(_pers);
           
                MessageBox.Show(result);
            
        }
    }
}
