using Chat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chat
{
    /// <summary>
    /// Interaction logic for SomeWindow.xaml
    /// </summary>
    public partial class SomeWindow : Window
    {
        EFContext context = new EFContext();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer1 = new DispatcherTimer();
        int _id;
        int _idother;
        string Name;
        string otherName;
        public SomeWindow(int id)
        {
            InitializeComponent();
          _id = id;
            foreach(var item in context.Users)
            {
                if(_id==item.ID)
                {
                    Name = item.FirstName;
                }
            }
           

            foreach (var item in context.Messesages.ToList())
            {
              listbox.Items.Add($"{item.Userof.FirstName}: {item.Text}");
            }
            foreach(var item in context.Users)
            {

                listUsers.Items.Add($"{item.FirstName}");
            }
            
            timer.Interval = new TimeSpan(0, 0,1);
            timer.Start();
            timer.Tick += Timer_Tick;
           
            
           
        }

       
        private void Timer_Tick(object sender, EventArgs e)
        {
            listUsers.Items.Clear();
            listbox.Items.Clear();
            foreach (var item in context.Users)
            {
                listUsers.Items.Add($"{item.FirstName}");             
            }
          
            foreach (var item in context.Messesages.ToList())
            {
                listbox.Items.Add($"{item.Userof.FirstName}: {item.Text}");
            }
            
          
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Messesage messesage = new Messesage() {
            Text = text.Text,
            User_ID=_id
            };
            context.Messesages.Add(messesage);
            context.SaveChanges();
            text.Clear();




        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Enter_Click(sender, e);
            }
        }

        private void ListUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {                    
                if(listUsers.SelectedValue.ToString()!=Name)
                {
                 MiniChat mini = new MiniChat(listUsers.SelectedValue.ToString(),_id);
                 mini.ShowDialog();
               
            }
            

        }
    }
}
