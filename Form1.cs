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

        List<Weapon> weapons = new List<Weapon> { };
        List<Personage> pers = new List<Personage>{};
        string pathWeapon;
        string path_char;
        int countWeapon=0;
        int countChar = 0;
   
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
                    path_char = Path.GetFileName(dialog.FileName);
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
                int charStrength = Convert.ToInt32(textBox4.Text);
                int charDexterity = Convert.ToInt32(textBox5.Text);
                int charIntellegence = Convert.ToInt32(textBox6.Text);
                int index = comboBox1.SelectedIndex;
                string pathChar = path_char;
                Weapon weapon = weapons[index];
                Personage per = new Personage(charName, charLvl, charStrength, charDexterity, charIntellegence, weapon,pathChar, weapon.Lvl, weapon.Damage);
                pers.Add(per);
                int lastCount = pers.Count() - 1;
                comboBox6.Items.Add(pers[lastCount].GetInfo());
                button2.Enabled = true;
                StaticMetodsForPersonage.Dexterity = charDexterity;
                StaticMetodsForPersonage.Intelligence = charIntellegence;
                StaticMetodsForPersonage.Lvl = charLvl;
                StaticMetodsForPersonage.Strength = charStrength;
                StaticMetodsForPersonage.Weapons = weapon;
                button8.Enabled = true;
                countChar++;
                if(countChar>=1)
                {
                    button7.Enabled = true;
                }

            }
            catch
            {
                int last_count_w = weapons.Count() - 1;
                int last_count_p = pers.Count();
                Weapon weapon = weapons[last_count_w];
                Personage per = new Personage(weapon);
                pers.Add(per);
                comboBox6.Items.Add(pers[last_count_p].GetInfo());
                button8.Enabled = true;
                countChar++;
                if (countChar >= 1)
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
                string Type_of_weapon = comboBox4.Text;
                string path = pathWeapon;
                Weapon weapon = new Weapon(name, lvl, damage, Type_of_weapon, path);
                weapons.Add(weapon);
                int lastCount = weapons.Count() - 1;
                listBox1.Items.Add(weapon.GerInfo());
                comboBox1.Items.Add(weapons[lastCount].GerInfo());
                comboBox2.Items.Add(weapons[lastCount].GerInfo());
                comboBox3.Items.Add(weapons[lastCount].GerInfo());
                comboBox5.Items.Add(weapons[lastCount].GerInfo());
                button2.Enabled = true;
                countWeapon++;
                if (countWeapon >= 2)
                {
                    button6.Enabled = true;
                    button4.Enabled = true;
                }
            }
            catch
            {             
                Weapon weapon = new Weapon();
                weapons.Add(weapon);
                int lastCount = weapons.Count() - 1;
                listBox1.Items.Add(weapons[lastCount].GerInfo());
                comboBox1.Items.Add(weapons[lastCount].GerInfo());
                comboBox2.Items.Add(weapons[lastCount].GerInfo());
                comboBox3.Items.Add(weapons[lastCount].GerInfo());
                comboBox5.Items.Add(weapons[lastCount].GerInfo());
                button2.Enabled = true;
                countWeapon++;
                if (countWeapon >= 2)
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
                if (weapons[index].TypeWeapon == weapons[index2].TypeWeapon)
                {
                    weapons.Add(weapons[index] += weapons[index2]);
                    int lastCount = weapons.Count() - 1;
                    listBox1.Items.Add(weapons[lastCount].GerInfo());
                    comboBox1.Items.Add(weapons[lastCount].GerInfo());
                    comboBox2.Items.Add(weapons[lastCount].GerInfo());
                    comboBox3.Items.Add(weapons[lastCount].GerInfo());
                    comboBox5.Items.Add(weapons[lastCount].GerInfo());
                }
                else
                {
                    MessageBox.Show("Типы оружия не совпадают");
                }
            }

            catch(Exception ex)
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
                    pathWeapon = Path.GetFileName(dialog.FileName);
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
            Image image = Image.FromFile(weapons[index].PathWeapon);
            Bitmap bmp = new Bitmap(image);
            pictureBox2.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = comboBox6.SelectedIndex;
            Image image = Image.FromFile(pers[index].PathChar);
            Bitmap bmp = new Bitmap(image);
            pictureBox1.Image = bmp;
            int powerPers = ((pers[index].Strength + pers[index].Dexterity + pers[index].Intelligence) * pers[index].Lvl) + (pers[index].Weapons.Lvl * pers[index].Weapons.Damage);
            
            MessageBox.Show($"Звание персонажа:  {StaticMetodsForPersonage.Power(pers[index])} Мощность равна:{powerPers}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            string result = StaticMetodsForPersonage.StrongPersonage(pers);
           
                MessageBox.Show(result);
            
        }
    }
}
